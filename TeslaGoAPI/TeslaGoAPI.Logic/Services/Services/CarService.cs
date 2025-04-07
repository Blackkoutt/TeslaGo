using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.DB.Entities.Abstract;
using TeslaGoAPI.Logic.Dto.Abstract;
using TeslaGoAPI.Logic.Dto.RequestDto;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Errors;
using TeslaGoAPI.Logic.Extensions;
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
    public sealed class CarService(IUnitOfWork unitOfWork, IAuthService authService)
           : GenericService<
               Car,
               CarRequestDto,
               CarRequestDto,
               CarResponseDto,
               CarQuery>(unitOfWork, authService), ICarService
    {
        public sealed override async Task<Result<IEnumerable<CarResponseDto>>> GetAllAsync(CarQuery query)
        {
            var records = await _repository.GetAllAsync(q =>
                                                q.ByQuery(query)
                                                .Where(x => !x.IsDeleted)
                                                .GetPage(query.PageNumber, query.PageSize));
            var response = MapAsDto(records);
            return Result<IEnumerable<CarResponseDto>>.Success(response);
        }

        public sealed override async Task<Result<object>> AddAsync(CarRequestDto? requestDto)
        {
            var result = await ValidateEntity(requestDto);
            if (!result.IsSuccessful)
                return Result<object>.Failure(result.Error);

            var entity = MapAsEntity(requestDto!);
            AdditionalMapping(entity, requestDto!.LocationId);

            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }

        public sealed override async Task<Result<object>> UpdateAsync(int id, CarRequestDto? requestDto)
        {
            var result = await ValidateEntity(requestDto, id);
            if (!result.IsSuccessful)
                return Result<object>.Failure(result.Error);

            var oldEntity = result.Value;
            if (oldEntity == null)
                return Result<object>.Failure(Error.NullObjectDetected);

            var newEntity = (Car)MapToEntity(requestDto!, oldEntity);
            AdditionalMapping(newEntity, requestDto!.LocationId);

            _repository.Update(newEntity);

            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }

        private void AdditionalMapping(Car car, int locationId)
        {
            car.Locations.Add(new Car_Location
            {
                CarId = car.Id,
                FromDate = DateTime.Now,
                LocationId = locationId,
            });
        }

        protected sealed override async Task<Result<bool>> IsSameEntityExistInDatabase(IRequestDto requestDto, int? id = null)
        {
            var carRequestDto = requestDto as CarRequestDto;
            if (carRequestDto == null)
                return Result<bool>.Failure(Error.BadParameterType);

            var entities = await _repository.GetAllAsync(q => 
                q.Where(car => 
                    car.Id != id &&
                    !car.IsDeleted &&
                    (car.VIN.ToLower() == carRequestDto.VIN.ToLower() ||
                    car.RegistrationNr.ToLower() == carRequestDto.RegistrationNr.ToLower())));

            return Result<bool>.Success(entities.Any());
        }

        protected sealed override async Task<Result<Car?>> ValidateEntity(IRequestDto? requestDto, int? id = null)
        {
            var carRequestDto = requestDto as CarRequestDto;
            if (carRequestDto == null)
                return Result<Car?>.Failure(Error.BadParameterType);

            if (id != null && id < 0)
                return Result<Car?>.Failure(Error.RouteParamOutOfRange);

            if (requestDto == null)
                return Result<Car?>.Failure(Error.NullParameter);

            var isExistResult = await IsSameEntityExistInDatabase(requestDto, id);
            if (!isExistResult.IsSuccessful)
                return Result<Car?>.Failure(isExistResult.Error);

            if (isExistResult.Value)
                return Result<Car?>.Failure(Error.SuchEntityExistInDb);

            if (await NotExistInDB<CarModel>(carRequestDto.ModelId))
                return Result<Car?>.Failure(CarModelError.NotFound);

            if (await NotExistInDB<Paint>(carRequestDto.PaintId))
                return Result<Car?>.Failure(PaintError.NotFound);

            if (await NotExistInDB<Location>(carRequestDto.LocationId))
                return Result<Car?>.Failure(LocationError.NotFound);

            var userResult = await _authService.GetCurrentUserAsEntity();
            if (!userResult.IsSuccessful)
                return Result<Car?>.Failure(userResult.Error);

            var user = userResult.Value;

            if (!user.IsInRole(Roles.Admin))
                return Result<Car?>.Failure(AuthError.UserDoesNotHavePremissionToResource);

            Car? car = null;
            if (id != null)
            {
                car = await _repository.GetOneAsync((int)id);
                if (car == null)
                    return Result<Car?>.Failure(Error.NotFound);

                if (car is ISoftDeleteable softDeleteableEntity && softDeleteableEntity.IsDeleted)
                    return Result<Car?>.Failure(Error.NotFound);
            }
            return Result<Car?>.Success(car);
        }

        protected sealed override IEnumerable<CarResponseDto> MapAsDto(IEnumerable<Car> records)
        {
            return records.Select(entity =>
            {
                var responseDto = entity.AsDto<CarResponseDto>();
                responseDto.Locations = [];
                responseDto.ActualLocation = entity.Locations.OrderByDescending(x => x.FromDate)
                    .FirstOrDefault(x => x.FromDate <= DateTime.Now)?
                        .Location.AsDto<LocationResponseDto>();

                responseDto.Paint = entity.Paint.AsDto<PaintResponseDto>();
                responseDto.Model = entity.Model.AsDto<CarModelResponseDto>();
                responseDto.Model.Brand = entity.Model.Brand.AsDto<BrandResponseDto>();
                responseDto.Model.BodyType = entity.Model.BodyType.AsDto<BodyTypeResponseDto>();
                responseDto.Model.ModelVersion = entity.Model.ModelVersion.AsDto<ModelVersionResponseDto>();
                responseDto.Model.DriveType = entity.Model.DriveType.AsDto<DriveTypeResponseDto>();
                return responseDto;
            });
        }

        protected sealed override CarResponseDto MapAsDto(Car entity)
        {
            var responseDto = entity.AsDto<CarResponseDto>();
            responseDto.Locations = entity.Locations.Select(l => l.AsDto<Car_LocationResponseDto>()).ToList();
            responseDto.ActualLocation = entity.Locations.OrderByDescending(x => x.FromDate)
                .FirstOrDefault(x => x.FromDate <= DateTime.Now)?
                    .Location.AsDto<LocationResponseDto>();

            responseDto.Paint = entity.Paint.AsDto<PaintResponseDto>();
            responseDto.Model = entity.Model.AsDto<CarModelResponseDto>();
            responseDto.Model.Brand = entity.Model.Brand.AsDto<BrandResponseDto>();
            responseDto.Model.GearBox = entity.Model.GearBox.AsDto<GearBoxResponseDto>();
            responseDto.Model.FuelType = entity.Model.FuelType.AsDto<FuelTypeResponseDto>();
            responseDto.Model.BodyType = entity.Model.BodyType.AsDto<BodyTypeResponseDto>();
            responseDto.Model.ModelVersion = entity.Model.ModelVersion.AsDto<ModelVersionResponseDto>();
            responseDto.Model.DriveType = entity.Model.DriveType.AsDto<DriveTypeResponseDto>();
            responseDto.Model.CarModelDetails = entity.Model.CarModelDetails.AsDto<CarModelDetailsResponseDto>();
            responseDto.Model.Equipments = entity.Model.Equipments.Select(eq => eq.AsDto<EquipmentResponseDto>()).ToList();
            return responseDto;
        }
    }
}
