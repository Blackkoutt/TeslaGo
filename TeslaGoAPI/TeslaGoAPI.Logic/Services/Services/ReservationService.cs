using Serilog;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.DB.Entities.Abstract;
using TeslaGoAPI.Logic.Dto.Abstract;
using TeslaGoAPI.Logic.Dto.RequestDto;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Errors;
using TeslaGoAPI.Logic.Extensions;
using TeslaGoAPI.Logic.Helpers;
using TeslaGoAPI.Logic.Identity.Enums;
using TeslaGoAPI.Logic.Identity.Services.Interfaces;
using TeslaGoAPI.Logic.Mapper.Extensions;
using TeslaGoAPI.Logic.Query;
using TeslaGoAPI.Logic.Result;
using TeslaGoAPI.Logic.Services.Interfaces;
using TeslaGoAPI.Logic.Services.Services.Abstract;
using TeslaGoAPI.Logic.UnitOfWork;

namespace TeslaGoAPI.Logic.Services.Services
{
    public sealed class ReservationService(IUnitOfWork unitOfWork, IAuthService authService)
           : GenericService<
               Reservation,
               ReservationRequestDto,
               ReservationResponseDto,
               ReservationQuery>(unitOfWork, authService), IReservationService
    {
        public sealed override async Task<Result<ReservationResponseDto>> AddAsync(ReservationRequestDto? requestDto)
        {
            var validationResult = await Validate(requestDto);
            if(!validationResult.IsSuccessful)
                return Result<ReservationResponseDto>.Failure(validationResult.Error);

            var carModel = validationResult.Value.CarModel;
            var optServices = validationResult.Value.OptServices;
            var user = validationResult.Value.User;
            var pickupLocation = validationResult.Value.PickupLocation; 
            var returnLocation = validationResult.Value.ReturnLocation;

            var getCarResult = await GetCarsAvailableInSelectedDateRange(requestDto!.CarModelId, requestDto.StartDate, requestDto.EndDate);
            if(!getCarResult.IsSuccessful)
                return Result<ReservationResponseDto>.Failure(getCarResult.Error);

            var carsAvailableInDateRange = getCarResult.Value;

            var reservation = CreateReservation(requestDto, carModel, optServices.ToList(), user.Id);

            // If start date is tomorrow or day after tomorrow
            // Check if any car of selected model is available in selected location or will be available
            var isStartTommorowOrDayAfter = requestDto.StartDate.Date <= DateTime.Today.AddDays(2);
            Log.Information("requestDto.StartDate.Date {@requestDto.StartDate.Date}", requestDto.StartDate.Date);
            var futureDate = DateTime.Today.AddDays(2);
            Log.Information("2 days later {@FutureDate}", futureDate);

            Log.Information("isStartTommorowOrDayAfter {@isStartTommorowOrDayAfter}", isStartTommorowOrDayAfter);
            
            if (isStartTommorowOrDayAfter)
            {
                var availableCars = GetCarsAvailableInSelectedLocation(carsAvailableInDateRange, requestDto);

                Log.Information("availableCars {@availableCars}", availableCars.Count());

                var firstCar = availableCars.First();

                Log.Information("First available car {@FirstCar}", new
                {
                    firstCar.Id,
                    firstCar.VIN,
                    firstCar.RegistrationNr,
                    firstCar.ModelId,
                });

                // Make reservation for concrete car
                if (availableCars.Any())
                {
                    var car = availableCars.First();
                    reservation.CarId = availableCars.First().Id;

                    // Update Car Location
                    car.Locations.Add(new Car_Location
                    {
                        CarId = car.Id,
                        LocationId = reservation.ReturnLocationId,
                        FromDate = reservation.EndDate,
                    });

                    _unitOfWork.GetRepository<Car>().Update(car);

                }
                else return Result<ReservationResponseDto>.Failure(ReservationError.NoAvailableCarsInSelectedLocation);
            }

            // If reservation starts more than 2 days from current date
            // Make reservation only for specific model (propably it will be available in this location in future)

            await _repository.AddAsync(reservation);
            await _unitOfWork.SaveChangesAsync();

            return Result<ReservationResponseDto>.Success();
        }

        protected sealed override IEnumerable<ReservationResponseDto> MapAsDto(IEnumerable<Reservation> records) 
        {
            return records.Select(entity =>
            {
                var responseDto = entity.AsDto<ReservationResponseDto>();
                responseDto.User = entity.User.AsDto<UserResponseDto>();
                responseDto.User.Address = null;
                responseDto.CarModel = entity.CarModel.AsDto<CarModelResponseDto>();
                responseDto.CarModel.Brand = entity.CarModel.Brand.AsDto<BrandResponseDto>();
                responseDto.CarModel.ModelVersion = entity.CarModel.ModelVersion.AsDto<ModelVersionResponseDto>();
                responseDto.CarModel.DriveType = entity.CarModel.DriveType.AsDto<DriveTypeResponseDto>();
                responseDto.CarModel.CarModelDetails = null;
                responseDto.CarModel.Equipments = [];
                responseDto.PickupLocation = entity.PickupLocation.AsDto<LocationResponseDto>();
                responseDto.PickupLocation.Address = null;
                responseDto.ReturnLocation = entity.ReturnLocation.AsDto<LocationResponseDto>();
                responseDto.ReturnLocation.Address = null;  
                return responseDto;
            });
        }

        protected sealed override ReservationResponseDto MapAsDto(Reservation entity)
        {
            var responseDto = entity.AsDto<ReservationResponseDto>();
            responseDto.User = entity.User.AsDto<UserResponseDto>();
            responseDto.User.Address = null;
            responseDto.CarModel = entity.CarModel.AsDto<CarModelResponseDto>();
            responseDto.CarModel.Brand = entity.CarModel.Brand.AsDto<BrandResponseDto>();
            responseDto.CarModel.GearBox = entity.CarModel.GearBox.AsDto<GearBoxResponseDto>();
            responseDto.CarModel.FuelType = entity.CarModel.FuelType.AsDto<FuelTypeResponseDto>();
            responseDto.CarModel.BodyType = entity.CarModel.BodyType.AsDto<BodyTypeResponseDto>();
            responseDto.CarModel.ModelVersion = entity.CarModel.ModelVersion.AsDto<ModelVersionResponseDto>();
            responseDto.CarModel.DriveType = entity.CarModel.DriveType.AsDto<DriveTypeResponseDto>();
            responseDto.CarModel.CarModelDetails = null;
            responseDto.CarModel.Equipments = [];
            responseDto.Car = entity.Car?.AsDto<CarResponseDto>();
            if(responseDto.Car != null)
            {
                responseDto.Car.Model = null;
                responseDto.Car.Paint = null;
                responseDto.Car.Locations = [];
                responseDto.Car.ActualLocation = null;
            }
            responseDto.PaymentMethod = entity.PaymentMethod.AsDto<PaymentMethodResponseDto>();
            responseDto.OptServices = entity.OptServices.Select(opt => opt.AsDto<OptServiceResponseDto>()).ToList();
            responseDto.PickupLocation = entity.PickupLocation.AsDto<LocationResponseDto>();
            responseDto.PickupLocation.Address = null;
            responseDto.ReturnLocation = entity.ReturnLocation.AsDto<LocationResponseDto>();
            responseDto.ReturnLocation.Address = null;
            return responseDto;
        }

        private async Task<Result<IEnumerable<Car>>> GetCarsAvailableInSelectedDateRange(int modelId, DateTime startDate, DateTime endDate)
        {
            var carWithSelectedModel = await _unitOfWork.GetRepository<Car>()
                                            .GetAllAsync(q => q.Where(x =>
                                              x.ModelId == modelId));

            var carsOfModelThatIsAvailable = carWithSelectedModel
                            .Where(x => !x.Reservations
                                .Any(x => x.StartDate <= endDate &&
                                          x.EndDate >= startDate));

            if (!carsOfModelThatIsAvailable.Any())
                return Result<IEnumerable<Car>>.Failure(ReservationError.NoAvailableCarsIsSelectedDateRange);

            return Result<IEnumerable<Car>>.Success(carsOfModelThatIsAvailable);
        }
        private IEnumerable<Car> GetCarsAvailableInSelectedLocation(IEnumerable<Car> carsAvailableInDateRange, ReservationRequestDto requestDto)
        {
            return carsAvailableInDateRange
                .Where(car =>
                {
                    var lastLocation = car.Locations
                        .Where(l => l.FromDate <= requestDto.StartDate)
                        .OrderByDescending(l => l.FromDate)
                        .FirstOrDefault();

                    return lastLocation != null && lastLocation.Id == requestDto.PickupLocationId;
                });
        }

        private Reservation CreateReservation(ReservationRequestDto requestDto, CarModel model, List<OptService> optServices, int userId)
        {
            var reservation = MapAsEntity(requestDto!);
            reservation.ReservationDate = DateTime.Now;
            reservation.TotalCost = CalculateReservationCost(model!, reservation.StartDate, reservation.EndDate, optServices);
            reservation.OptServices = optServices.ToList();
            reservation.UserId = userId;

            return reservation;
        }

        private decimal CalculateReservationCost(CarModel carModel, DateTime startDate, DateTime endDate, IEnumerable<OptService> optServices)
        {
            var totalTime = endDate - startDate;
            int totalDays = (int)Math.Ceiling(totalTime.TotalDays);

            var totalCost = carModel.PricePerDay * totalDays;

            foreach (var optService in optServices)
            {
                totalCost += optService.Price;
            }

            return totalCost;
        }

        private async Task<Result<ReservationValidateWrapper>> Validate(ReservationRequestDto? requestDto, int ? id = null)
        {
            if (id != null && id < 0)
                return Result<ReservationValidateWrapper>.Failure(Error.RouteParamOutOfRange);

            if (requestDto == null)
                return Result<ReservationValidateWrapper>.Failure(Error.NullParameter);
            
            var locationRepository = _unitOfWork.GetRepository<Location>();
            var pickupLocation = await locationRepository.GetOneAsync(requestDto.PickupLocationId);
            if (pickupLocation == null)
                return Result<ReservationValidateWrapper>.Failure(LocationError.PickupLocationNotFound);

            var returnLocation = await locationRepository.GetOneAsync(requestDto.ReturnLocationId);
            if (returnLocation == null)
                return Result<ReservationValidateWrapper>.Failure(LocationError.ReturnLocationNotFound);

            var carModel = await _unitOfWork.GetRepository<CarModel>().GetOneAsync(requestDto.CarModelId);
            if (carModel == null)
                return Result<ReservationValidateWrapper>.Failure(CarModelError.NotFound);

            var paymentType = await _unitOfWork.GetRepository<PaymentMethod>().GetOneAsync(requestDto.PaymentMethodId);
            if (paymentType == null)
                return Result<ReservationValidateWrapper>.Failure(PaymentMethodError.NotFound);

            var optServices = await _unitOfWork.GetRepository<OptService>().GetAllAsync(q => q.Where(x => requestDto.OptServicesIds.Contains(x.Id)));
            if (requestDto.OptServicesIds.Count != optServices.Count())
                return Result<ReservationValidateWrapper>.Failure(OptServiceError.NotFound);

            var userResult = await _authService.GetCurrentUser();
            if (!userResult.IsSuccessful)
                return Result<ReservationValidateWrapper>.Failure(userResult.Error);

            var user = userResult.Value;

            if (id != null && !user.IsInRole(Roles.Admin))
                return Result<ReservationValidateWrapper>.Failure(AuthError.UserDoesNotHavePremissionToResource);

            return Result<ReservationValidateWrapper>.Success(
                new ReservationValidateWrapper(
                carModel,
                optServices,
                user,
                pickupLocation,
                returnLocation));
        }
    }
}
