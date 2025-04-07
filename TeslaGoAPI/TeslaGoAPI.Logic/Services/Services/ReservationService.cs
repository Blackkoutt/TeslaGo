using Microsoft.Extensions.Options;
using Serilog;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.DB.Entities.Abstract;
using TeslaGoAPI.Logic.Dto.Abstract;
using TeslaGoAPI.Logic.Dto.RequestDto;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Dto.UpdateRequestDto;
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
using TeslaGoAPI.Logic.Settings;
using TeslaGoAPI.Logic.UnitOfWork;

namespace TeslaGoAPI.Logic.Services.Services
{
    public sealed class ReservationService(IUnitOfWork unitOfWork, IAuthService authService, IOptions<ReservationSettings> settings)
           : GenericService<
               Reservation,
               ReservationRequestDto,
               ReservationUpdateRequestDto,
               ReservationResponseDto,
               ReservationQuery>(unitOfWork, authService), IReservationService
    {
        private readonly IOptions<ReservationSettings> _settings = settings;

        public sealed override async Task<Result<IEnumerable<ReservationResponseDto>>> GetAllAsync(ReservationQuery query)
        {
            UserResponseDto? user = default!;

            var userResult = await _authService.GetCurrentUser();
            if (!userResult.IsSuccessful)
                return Result<IEnumerable<ReservationResponseDto>>.Failure(userResult.Error);
            user = userResult.Value;

            if (user.IsInRole(Roles.Admin))
            {
                var allReservations = await _repository.GetAllAsync(q =>
                                                q.ByQuery(query)
                                                .GetPage(query.PageNumber, query.PageSize));

                var allReservationsDto = MapAsDto(allReservations);
                return Result<IEnumerable<ReservationResponseDto>>.Success(allReservationsDto);
            }
            else if (user.IsInRole(Roles.User))
            {
                var userReservations = await _repository.GetAllAsync(q =>
                                            q.ByQuery(query)
                                            .Where(r => r.User.Id == user.Id)
                                            .GetPage(query.PageNumber, query.PageSize));

                var userReservationsResponse = MapAsDto(userReservations);
                return Result<IEnumerable<ReservationResponseDto>>.Success(userReservationsResponse);
            }
            else
                return Result<IEnumerable<ReservationResponseDto>>.Failure(AuthError.UserDoesNotHaveSpecificRole);
        }

        public sealed override async Task<Result<ReservationResponseDto>> GetOneAsync(int id)
        {
            var reservationResult = await base.GetOneAsync(id);
            if (!reservationResult.IsSuccessful)
                return Result<ReservationResponseDto>.Failure(reservationResult.Error);

            var reservation = reservationResult.Value;
            var premissionResult = await CheckUserPremission(reservation.User!.Id);
            if (!premissionResult.IsSuccessful)
                return Result<ReservationResponseDto>.Failure(premissionResult.Error);

            return Result<ReservationResponseDto>.Success(reservation);
        }

        public sealed override async Task<Result<object>> AddAsync(ReservationRequestDto? requestDto)
        {
            var validationResult = await Validate(requestDto);
            if (!validationResult.IsSuccessful)
                return Result<object>.Failure(validationResult.Error);

            var carModel = validationResult.Value.CarModel;
            var optServices = validationResult.Value.OptServices;
            var user = validationResult.Value.User;
            var pickupLocation = validationResult.Value.PickupLocation;
            var returnLocation = validationResult.Value.ReturnLocation;

            var carsAvailableInDateRange = await GetCarsAvailableInSelectedDateRange(requestDto!.CarModelId, requestDto.StartDate, requestDto.EndDate);
            if (!carsAvailableInDateRange.Any())
                return Result<object>.Failure(ReservationError.NoAvailableCarsIsSelectedDateRange);

            var reservation = CreateReservation(requestDto, carModel, optServices.ToList(), user.Id);

            // If start date is tomorrow or day after tomorrow
            // Check if any car of selected model is available in selected location or will be available
            var isStartTommorowOrDayAfter = requestDto.StartDate.Date <= DateTime.Today.AddDays(2);
            var futureDate = DateTime.Today.AddDays(2);

            if (isStartTommorowOrDayAfter)
            {
                var availableCars = GetAvailableCarsInLocation(carsAvailableInDateRange, requestDto.StartDate, requestDto.PickupLocationId);

                Log.Information("availableCars {@availableCars}", availableCars.Count());

                // Make reservation for concrete car
                if (availableCars.Any())
                {
                    var car = availableCars.First();
                    AssignCarToReservation(reservation, car);

                }
                else return Result<object>.Failure(ReservationError.NoAvailableCarsInSelectedLocation);
            }

            // If reservation starts more than 2 days from current date
            // Make reservation only for specific model (propably it will be available in this location in future)

            await _repository.AddAsync(reservation);
            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }

        public sealed override async Task<Result<object>> UpdateAsync(int id, ReservationUpdateRequestDto? requestDto)
        {
            var validationResult = await Validate(requestDto, id);
            if (!validationResult.IsSuccessful)
                return Result<object>.Failure(validationResult.Error);

            var carModel = validationResult.Value.CarModel;
            var optServices = validationResult.Value.OptServices;
            var user = validationResult.Value.User;
            var pickupLocation = validationResult.Value.PickupLocation;
            var returnLocation = validationResult.Value.ReturnLocation;
            var reservationEntity = validationResult.Value.Reservation;

            var carsAvailableInDateRange = await GetCarsAvailableInSelectedDateRange(requestDto!.CarModelId, requestDto.StartDate, requestDto.EndDate, reservationEntity!.Id);
            if (!carsAvailableInDateRange.Any())
                return Result<object>.Failure(ReservationError.NoAvailableCarsIsSelectedDateRange);

            var updatedRes = UpdateReservation(reservationEntity, requestDto, carModel, optServices.ToList(), user.Id);

            var isStartTommorowOrDayAfter = requestDto.StartDate.Date <= DateTime.Today.AddDays(2);
            var futureDate = DateTime.Today.AddDays(2);

            var availableCars = GetAvailableCarsInLocation(carsAvailableInDateRange, requestDto.StartDate, requestDto.PickupLocationId);

            if (requestDto.CarId != null)
            {
                // Assign concrete car with id if it is available now
                var car = availableCars.FirstOrDefault(x => x.Id == requestDto.CarId);
                if (car != null)
                {
                    AssignCarToReservation(updatedRes, car);
                }
                else return Result<object>.Failure(ReservationError.NoAvailableConcreteCarInSelectedLocation);

            }
            else if (isStartTommorowOrDayAfter)
            {
                // Assign one of conrete cars available in location
                if (availableCars.Any())
                {
                    var car = availableCars.First();
                    AssignCarToReservation(updatedRes, car);
                }
                else return Result<object>.Failure(ReservationError.NoAvailableCarsInSelectedLocation);
            }

            _repository.Update(updatedRes);

            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }

        protected sealed override async Task<Result<Reservation>> ValidateBeforeDelete(int id)
        {
            if (id < 0)
                return Result<Reservation>.Failure(Error.RouteParamOutOfRange);

            var reservation = await _repository.GetOneAsync(id);

            if (reservation == null)
                return Result<Reservation>.Failure(ReservationError.NotFound);

            if (reservation.IsExpired)
                return Result<Reservation>.Failure(ReservationError.IsExpired);

            if (reservation.IsDeleted)
                return Result<Reservation>.Failure(ReservationError.IsDeleted);

            var timeUntilStart = reservation.StartDate - DateTime.Now;
            if (timeUntilStart.TotalSeconds > 0 && timeUntilStart.TotalHours <= _settings.Value.MinHoursBeforeCancellation)
                return Result<Reservation>.Failure(ReservationError.ReservationStartsSoon);

            int? entityUserId = null;
            if (reservation is IAuthEntity authEntity)
                entityUserId = authEntity.UserId;

            var premissionResult = await CheckUserPremission(entityUserId);
            if (!premissionResult.IsSuccessful)
                return Result<Reservation>.Failure(premissionResult.Error);

            return Result<Reservation>.Success(reservation);
        }

        public void AssignCarToReservation(Reservation res, Car car)
        {
            res.CarId = car.Id;
            Log.Information($"Assigned car for reservationId {res.Id}: CarId: {car.Id} Model: {car.Model.Name} VIN: {car.VIN}, RegisterNr: {car.RegistrationNr}");

            car.Locations.Add(new Car_Location
            {
                CarId = car.Id,
                LocationId = res.ReturnLocationId,
                FromDate = res.EndDate,
            });

            _unitOfWork.GetRepository<Car>().Update(car);
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

        public async Task<IEnumerable<Car>> GetCarsAvailableInSelectedDateRange(int modelId, DateTime startDate, DateTime endDate, int? resId = null)
        {
            return await _unitOfWork.GetRepository<Car>()
                .GetAllAsync(q => q.Where(x =>
                    x.ModelId == modelId &&
                    !x.Reservations.Any(x =>
                        x.Id != resId &&
                        !x.IsDeleted &&
                        x.StartDate <= endDate &&
                        x.EndDate >= startDate)));
        }


        public IEnumerable<Car> GetAvailableCarsInLocation(IEnumerable<Car> allAvailableCars, DateTime startDate, int locationId)
        {
            return allAvailableCars.Where(car =>
            {
                var lastLocation = car.Locations
                    .OrderByDescending(l => l.FromDate)
                    .FirstOrDefault(l => l.FromDate <= startDate);

                return lastLocation != null && lastLocation.LocationId == locationId;
            });
        }

        public async Task<IEnumerable<Reservation>> GetReservationsWithoutAssingedCarForRange(DateTime startRange, DateTime endRange)
        {
            return await _unitOfWork.GetRepository<Reservation>()
                .GetAllAsync(q => q.Where(reservation =>
                    reservation.CarId == null &&
                    !reservation.IsDeleted &&
                    reservation.StartDate >= startRange &&
                    reservation.StartDate <= endRange));
        }

        private Reservation UpdateReservation(Reservation res, ReservationUpdateRequestDto requestDto, CarModel model, List<OptService> optServices, int userId)
        {
            res.StartDate = requestDto.StartDate;
            res.EndDate = requestDto.EndDate;
            res.PickupLocationId = requestDto.PickupLocationId;
            res.ReturnLocationId = requestDto.ReturnLocationId;
            res.CarModelId = requestDto.CarModelId;
            res.TotalCost = CalculateReservationCost(model!, res.StartDate, res.EndDate, optServices);
            res.OptServices = optServices.ToList();
            res.IsUpdated = true;
            res.UpdateDate = DateTime.Now;
            return res;
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

        private async Task<Result<ReservationValidateWrapper>> Validate(ReservationRequestBaseDto? baseRequestDto, int ? id = null)
        {
            if (id != null && id < 0)
                return Result<ReservationValidateWrapper>.Failure(Error.RouteParamOutOfRange);

            if (baseRequestDto == null)
                return Result<ReservationValidateWrapper>.Failure(Error.NullParameter);
            
            var locationRepository = _unitOfWork.GetRepository<Location>();
            var pickupLocation = await locationRepository.GetOneAsync(baseRequestDto.PickupLocationId);
            if (pickupLocation == null)
                return Result<ReservationValidateWrapper>.Failure(LocationError.PickupLocationNotFound);

            var returnLocation = await locationRepository.GetOneAsync(baseRequestDto.ReturnLocationId);
            if (returnLocation == null)
                return Result<ReservationValidateWrapper>.Failure(LocationError.ReturnLocationNotFound);

            var carModel = await _unitOfWork.GetRepository<CarModel>().GetOneAsync(baseRequestDto.CarModelId);
            if (carModel == null)
                return Result<ReservationValidateWrapper>.Failure(CarModelError.NotFound);

            var optServices = await _unitOfWork.GetRepository<OptService>().GetAllAsync(q => q.Where(x => baseRequestDto.OptServicesIds.Contains(x.Id)));
            if (baseRequestDto.OptServicesIds.Count != optServices.Count())
                return Result<ReservationValidateWrapper>.Failure(OptServiceError.NotFound);

            var userResult = await _authService.GetCurrentUser();
            if (!userResult.IsSuccessful)
                return Result<ReservationValidateWrapper>.Failure(userResult.Error);

            if(baseRequestDto is ReservationRequestDto requestDto)
            {
                var paymentType = await _unitOfWork.GetRepository<PaymentMethod>().GetOneAsync(requestDto.PaymentMethodId);
                if (paymentType == null)
                    return Result<ReservationValidateWrapper>.Failure(PaymentMethodError.NotFound);
            }
            else if (baseRequestDto is ReservationUpdateRequestDto updateRequestDto && updateRequestDto.CarId != null)
            {
                if(await NotExistInDB<Car>((int)updateRequestDto.CarId))
                    return Result<ReservationValidateWrapper>.Failure(CarError.NotFound);
            }

            var user = userResult.Value;
            Reservation? reservation = null;

            if(id != null)
            {
                if (!user.IsInRole(Roles.Admin))
                    return Result<ReservationValidateWrapper>.Failure(AuthError.UserDoesNotHavePremissionToResource);

                reservation = await _repository.GetOneAsync((int)id);
                if (reservation == null)
                    return Result<ReservationValidateWrapper>.Failure(ReservationError.NotFound);

                if (reservation.IsExpired)
                    return Result<ReservationValidateWrapper>.Failure(ReservationError.IsExpired);

                if (reservation.IsDeleted)
                    return Result<ReservationValidateWrapper>.Failure(ReservationError.IsDeleted);

                var timeUntilStart = reservation.StartDate - DateTime.Now;
                if (timeUntilStart.TotalSeconds > 0 && timeUntilStart.TotalHours <= _settings.Value.MinHoursBeforeCancellation)
                    return Result<ReservationValidateWrapper>.Failure(ReservationError.ReservationStartsSoon);
            }

            return Result<ReservationValidateWrapper>.Success(
                new ReservationValidateWrapper(
                carModel,
                optServices,
                user,
                pickupLocation,
                returnLocation, 
                reservation));
        }
    }
}
