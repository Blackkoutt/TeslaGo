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
    public sealed class CarModelService(IUnitOfWork unitOfWork, IAuthService authService)
    : GenericService<
        CarModel,
        CarModelRequestDto,
        CarModelRequestDto,
        CarModelResponseDto,
        CarModelQuery>(unitOfWork, authService), ICarModelService
    {
        public sealed override async Task<Result<IEnumerable<CarModelResponseDto>>> GetAllAsync(CarModelQuery query)
        {
            var records = await _repository.GetAllAsync(q =>
                                                q.ByQuery(query)
                                                .Where(x => !x.IsDeleted)
                                                .GetPage(query.PageNumber, query.PageSize));
            var response = MapAsDto(records);
            return Result<IEnumerable<CarModelResponseDto>>.Success(response);
        }
        public sealed override async Task<Result<object>> AddAsync(CarModelRequestDto? requestDto)
        {
            var result = await ValidateEntity(requestDto);
            if (!result.IsSuccessful)
                return Result<object>.Failure(result.Error);

            var entity = MapAsEntity(requestDto!);
            await AdditionalMapping(entity, requestDto!);

            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }

        public sealed override async Task<Result<object>> UpdateAsync(int id, CarModelRequestDto? requestDto)
        {
            var result = await ValidateEntity(requestDto, id);
            if (!result.IsSuccessful)
                return Result<object>.Failure(result.Error);

            var oldEntity = result.Value;
            if (oldEntity == null)
                return Result<object>.Failure(Error.NullObjectDetected);

            var newEntity = (CarModel)MapToEntity(requestDto!, oldEntity);
            await AdditionalMapping(newEntity, requestDto!);

            _repository.Update(newEntity);

            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }


        private async Task AdditionalMapping(CarModel carModel, CarModelRequestDto requestDto)
        {
            carModel.CarModelDetails = requestDto.CarModelDetails.AsEntity<CarModelDetails>();
            var equipments = await _unitOfWork.GetRepository<Equipment>().GetAllAsync(q => 
                q.Where(x => requestDto.EquipmentsIds.Contains(x.Id)));
            carModel.Equipments = equipments.ToList();
        }

        protected sealed override async Task<Result<CarModel?>> ValidateEntity(IRequestDto? requestDto, int? id = null)
        {
            var carModelRequestDto = requestDto as CarModelRequestDto;
            if (carModelRequestDto == null)
                return Result<CarModel?>.Failure(Error.BadParameterType);

            if (id != null && id < 0)
                return Result<CarModel?>.Failure(Error.RouteParamOutOfRange);

            if (requestDto == null)
                return Result<CarModel?>.Failure(Error.NullParameter);

            if (await NotExistInDB<Brand>(carModelRequestDto.BrandId))
                return Result<CarModel?>.Failure(BrandError.NotFound);

            if (await NotExistInDB<GearBox>(carModelRequestDto.GearBoxId))
                return Result<CarModel?>.Failure(GearBoxError.NotFound);

            if (await NotExistInDB<FuelType>(carModelRequestDto.FuelTypeId))
                return Result<CarModel?>.Failure(FuelTypeError.NotFound);

            if (await NotExistInDB<BodyType>(carModelRequestDto.BodyTypeId))
                return Result<CarModel?>.Failure(BodyTypeError.NotFound);

            if (await NotExistInDB<ModelVersion>(carModelRequestDto.ModelVersionId))
                return Result<CarModel?>.Failure(ModelVersionError.NotFound);

            if (await NotExistInDB<DB.Entities.DriveType>(carModelRequestDto.DriveTypeId))
                return Result<CarModel?>.Failure(DriveTypeError.NotFound);

            if (await NotExistInDB<Equipment>(carModelRequestDto.EquipmentsIds))
                return Result<CarModel?>.Failure(EquipmentError.NotFound);

            var userResult = await _authService.GetCurrentUserAsEntity();
            if (!userResult.IsSuccessful)
                return Result<CarModel?>.Failure(userResult.Error);

            var user = userResult.Value;

            if (!user.IsInRole(Roles.Admin))
                return Result<CarModel?>.Failure(AuthError.UserDoesNotHavePremissionToResource);

            CarModel? carModel = null;
            if (id != null)
            {
                carModel = await _repository.GetOneAsync((int)id);
                if (carModel == null)
                    return Result<CarModel?>.Failure(Error.NotFound);

                if (carModel is ISoftDeleteable softDeleteableEntity && softDeleteableEntity.IsDeleted)
                    return Result<CarModel?>.Failure(Error.NotFound);
            }
            return Result<CarModel?>.Success(carModel);
        }

        protected sealed override IEnumerable<CarModelResponseDto> MapAsDto(IEnumerable<CarModel> records)
        {
            return records.Select(entity =>
            {
                var responseDto = entity.AsDto<CarModelResponseDto>();
                responseDto.Brand = entity.Brand.AsDto<BrandResponseDto>();
                responseDto.BodyType = entity.BodyType.AsDto<BodyTypeResponseDto>();
                responseDto.ModelVersion = entity.ModelVersion.AsDto<ModelVersionResponseDto>();
                responseDto.DriveType = entity.DriveType.AsDto<DriveTypeResponseDto>();
                return responseDto;
            });
        }

        protected sealed override CarModelResponseDto MapAsDto(CarModel entity)
        {
            var responseDto = entity.AsDto<CarModelResponseDto>();
            responseDto.Brand = entity.Brand.AsDto<BrandResponseDto>();
            responseDto.GearBox = entity.GearBox.AsDto<GearBoxResponseDto>();
            responseDto.FuelType = entity.FuelType.AsDto<FuelTypeResponseDto>();
            responseDto.BodyType = entity.BodyType.AsDto<BodyTypeResponseDto>();
            responseDto.ModelVersion = entity.ModelVersion.AsDto<ModelVersionResponseDto>();
            responseDto.DriveType = entity.DriveType.AsDto<DriveTypeResponseDto>();
            responseDto.CarModelDetails = entity.CarModelDetails.AsDto<CarModelDetailsResponseDto>();
            responseDto.Equipments = entity.Equipments.Select(eq => eq.AsDto<EquipmentResponseDto>()).ToList();
            return responseDto;
        }
    }
}
