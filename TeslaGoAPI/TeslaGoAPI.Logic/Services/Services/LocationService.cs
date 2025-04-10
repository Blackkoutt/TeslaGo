
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
    public sealed class LocationService(IUnitOfWork unitOfWork, IAuthService authService, IAddressService addressService)
           : GenericService<
               Location,
               LocationRequestDto,
               LocationRequestDto,
               LocationResponseDto,
               LocationQuery>(unitOfWork, authService), ILocationService
    {
        private readonly IAddressService _addressService = addressService;
        public sealed override async Task<Result<IEnumerable<LocationResponseDto>>> GetAllAsync(LocationQuery query)
        {
            var records = await _repository.GetAllAsync(q =>
                                                q.ByQuery(query)
                                                .Where(x => !x.IsDeleted)
                                                .GetPage(query.PageNumber, query.PageSize));
            var response = MapAsDto(records);
            return Result<IEnumerable<LocationResponseDto>>.Success(response);
        }

        public sealed override async Task<Result<object>> AddAsync(LocationRequestDto? requestDto)
        {
            var result = await ValidateEntity(requestDto);
            if (!result.IsSuccessful)
                return Result<object>.Failure(result.Error);

            var location = MapAsEntity(requestDto!);

            await _addressService.AddCityToAddress(location.Address, requestDto!.AddressRequestDto.CityName, requestDto.AddressRequestDto.CountryId);

            await _repository.AddAsync(location);
            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }

        public sealed override async Task<Result<object>> UpdateAsync(int id, LocationRequestDto? requestDto)
        {
            var result = await ValidateEntity(requestDto, id);
            if (!result.IsSuccessful)
                return Result<object>.Failure(result.Error);

            var oldEntity = result.Value;
            if (oldEntity == null)
                return Result<object>.Failure(Error.NullObjectDetected);

            var location = (Location)MapToEntity(requestDto!, oldEntity);

            await _addressService.AddCityToAddress(location.Address, requestDto!.AddressRequestDto.CityName, requestDto.AddressRequestDto.CountryId);

            _repository.Update(location);

            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }


        protected sealed override Location MapAsEntity(IRequestDto requestDto)
        {
            var locationDto = requestDto as LocationRequestDto;
            var location = requestDto.AsEntity<Location>();
            location.Address = locationDto!.AddressRequestDto.AsEntity<Address>();
            return location;
        }


        protected sealed override async Task<Result<Location?>> ValidateEntity(IRequestDto? requestDto, int? id = null)
        {
            if (id != null && id < 0)
                return Result<Location?>.Failure(Error.RouteParamOutOfRange);

            if (requestDto == null)
                return Result<Location?>.Failure(Error.NullParameter);

            var locationDto = requestDto as LocationRequestDto;
            if (locationDto == null)
                return Result<Location?>.Failure(Error.BadParameterType);

            var isExistResult = await base.IsSameEntityExistInDatabase(requestDto!, id);
            if (!isExistResult.IsSuccessful)
                return Result<Location?>.Failure(isExistResult.Error);

            if (isExistResult.Value)
                return Result<Location?>.Failure(Error.SuchEntityExistInDb);

            if (locationDto.AddressRequestDto.CountryId != null)
            {
                if (await NotExistInDB<Country>((int)locationDto.AddressRequestDto.CountryId))
                    return Result<Location?>.Failure(CityError.NotFound);
            }

            var userResult = await _authService.GetCurrentUserAsEntity();
            if (!userResult.IsSuccessful)
                return Result<Location?>.Failure(userResult.Error);

            var user = userResult.Value;

            if (!user.IsInRole(Roles.Admin))
                return Result<Location?>.Failure(AuthError.UserDoesNotHavePremissionToResource);

            Location? Location = null;
            if (id != null)
            {
                Location = await _repository.GetOneAsync((int)id);
                if (Location == null)
                    return Result<Location?>.Failure(Error.NotFound);

                if (Location is ISoftDeleteable softDeleteableEntity && softDeleteableEntity.IsDeleted)
                    return Result<Location?>.Failure(Error.NotFound);
            }
            return Result<Location?>.Success(Location);
        }
        protected sealed override LocationResponseDto MapAsDto(Location entity)
        {
            var responseDto = entity.AsDto<LocationResponseDto>();
            responseDto.Address = entity.Address.AsDto<AddressResponseDto>();
            if(entity.Address.City!= null)
            {
                responseDto.Address.City = entity.Address.City.AsDto<CityResponseDto>();
                if (entity.Address.City.Country != null)
                    responseDto.Address.City.Country = entity.Address.City.Country.AsDto<CountryResponseDto>();
            }
            return responseDto;
        }

    }
}
