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
    public sealed class AddressService(IUnitOfWork unitOfWork, IAuthService authService)
        : GenericService<
            Address,
            AddressRequestDto,
            AddressRequestDto,
            AddressResponseDto,
            AddressQuery>(unitOfWork, authService), IAddressService
    {

        public sealed override async Task<Result<IEnumerable<AddressResponseDto>>> GetAllAsync(AddressQuery query)
        {
            User? user = default!;

            var userResult = await _authService.GetCurrentUserAsEntity();
            if (!userResult.IsSuccessful)
                return Result<IEnumerable<AddressResponseDto>>.Failure(userResult.Error);
            user = userResult.Value;

            if (user.IsInRole(Roles.Admin))
            {
                var allReservations = await _repository.GetAllAsync(q =>
                                                q.ByQuery(query)
                                                .Where(x => !x.IsDeleted)
                                                .GetPage(query.PageNumber, query.PageSize));

                var allReservationsDto = MapAsDto(allReservations);
                return Result<IEnumerable<AddressResponseDto>>.Success(allReservationsDto);
            }
            else if (user.IsInRole(Roles.User))
            {
                var userReservations = await _repository.GetAllAsync(q =>
                                            q.ByQuery(query)
                                            .Where(x => (x.Location != null || (x.User != null && x.User.Id == user.Id)) && !x.IsDeleted)
                                            .GetPage(query.PageNumber, query.PageSize));

                var userReservationsResponse = MapAsDto(userReservations);
                return Result<IEnumerable<AddressResponseDto>>.Success(userReservationsResponse);
            }
            else
                return Result<IEnumerable<AddressResponseDto>>.Failure(AuthError.UserDoesNotHaveSpecificRole);
        }


        public sealed override async Task<Result<AddressResponseDto>> GetOneAsync(int id)
        {
            if (id < 0)
                return Result<AddressResponseDto>.Failure(Error.RouteParamOutOfRange);

            var address = await _repository.GetOneAsync(id);
            if (address == null || address.IsDeleted)
                return Result<AddressResponseDto>.Failure(Error.NotFound);

            var userResult = await _authService.GetCurrentUserAsEntity();
            if (!userResult.IsSuccessful)
                return Result<AddressResponseDto>.Failure(userResult.Error);

            var user = userResult.Value;
            var addressUserId = address.User?.Id;

            if(address.Location == null)
            {
                var premissionResult = await CheckUserPremission(addressUserId);
                if (!premissionResult.IsSuccessful)
                    return Result<AddressResponseDto>.Failure(premissionResult.Error);
            }

            var response = MapAsDto(address);

            return Result<AddressResponseDto>.Success(response);
        }
 
        public sealed override async Task<Result<object>> AddAsync(AddressRequestDto? requestDto)
        {
            var result = await ValidateEntity(requestDto);
            if (!result.IsSuccessful)
                return Result<object>.Failure(result.Error);

            var address = MapAsEntity(requestDto!);

            await AddCityToAddress(address, requestDto!.CityName, requestDto.CountryId);

            var userResult = await _authService.GetCurrentUserAsEntity();
            if (!userResult.IsSuccessful)
                return Result<object>.Failure(userResult.Error);

            var user = userResult.Value;

            if (user.IsInRole(Roles.User))
            {
                if(user.AddressId == null)
                {
                    address.User = user;
                    address.Location = null;
                }
                else Result<object>.Failure(AddressError.UserAlreadyHasAddress);
            }                

            await _repository.AddAsync(address);
            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }

        public sealed override async Task<Result<object>> UpdateAsync(int id, AddressRequestDto? requestDto)
        {
            var result = await ValidateEntity(requestDto, id);
            if (!result.IsSuccessful)
                return Result<object>.Failure(result.Error);

            var oldEntity = result.Value;
            if(oldEntity == null)
                return Result<object>.Failure(Error.NullObjectDetected);

            var address = (Address)MapToEntity(requestDto!, oldEntity);

            var userResult = await _authService.GetCurrentUserAsEntity();
            if (!userResult.IsSuccessful)
                return Result<object>.Failure(userResult.Error);

            var premissionResult = await CheckUserPremission(address.User?.Id);
            if (!premissionResult.IsSuccessful)
                return Result<object>.Failure(premissionResult.Error);

            await AddCityToAddress(address, requestDto!.CityName, requestDto.CountryId);

            _repository.Update(address);

            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }

        protected sealed override async Task<Result<Address>> ValidateBeforeDelete(int id)
        {
            if (id < 0)
                return Result<Address>.Failure(Error.RouteParamOutOfRange);

            var address = await _repository.GetOneAsync(id);

            if (address == null)
                return Result<Address>.Failure(Error.NotFound);


            if (address is ISoftDeleteable softDeleteableEntity && softDeleteableEntity.IsDeleted)
                return Result<Address>.Failure(Error.NotFound);

            var userResult = await _authService.GetCurrentUserAsEntity();
            if (!userResult.IsSuccessful)
                return Result<Address>.Failure(userResult.Error);

            var user = userResult.Value;
            var addressUserId = address.User?.Id;

            var premissionResult = await CheckUserPremission(addressUserId);
            if (!premissionResult.IsSuccessful)
                return Result<Address>.Failure(premissionResult.Error);

            return Result<Address>.Success(address);
        }

        public async Task AddCityToAddress(Address address, string cityName, int countryId)
        {
            var cities = await _unitOfWork.GetRepository<City>()
                   .GetAllAsync(q => q.Where(x =>
                       x.Name.ToLower() == cityName.ToLower()));

            var city = cities.FirstOrDefault(x => x.CountryId == countryId);

            if (city != null)
            {
                address.CityId = cities.First().Id;
            }
            else
            {
                address.City = new City
                {
                    Name = cityName,
                    CountryId = countryId,
                };
            }
        }


        protected sealed override IEnumerable<AddressResponseDto> MapAsDto(IEnumerable<Address> records)
        {
            return records.Select(entity => MapAsDto(entity));
        }

        protected sealed override AddressResponseDto MapAsDto(Address entity)
        {
            var responseDto = entity.AsDto<AddressResponseDto>();
            responseDto.City = entity.City.AsDto<CityResponseDto>();
            responseDto.City.Country = entity.City.Country.AsDto<CountryResponseDto>();
            return responseDto;
        }

        protected sealed override async Task<Result<Address?>> ValidateEntity(IRequestDto? requestDto, int? id = null)
        {
            var addressDto = requestDto as AddressRequestDto;
            if (addressDto == null)
                return Result<Address?>.Failure(Error.BadParameterType);

            if (id != null && id < 0)
                return Result<Address?>.Failure(Error.RouteParamOutOfRange);

            if (requestDto == null)
                return Result<Address?>.Failure(Error.NullParameter);

            if (await NotExistInDB<Country>(addressDto.CountryId))
                return Result<Address?>.Failure(CityError.NotFound);

            Address? address = null;
            if(id != null)
            {
                address = await _repository.GetOneAsync((int)id);
                if (address == null)
                    return Result<Address?>.Failure(Error.NotFound);

                if (address is ISoftDeleteable softDeleteableEntity && softDeleteableEntity.IsDeleted)
                    return Result<Address?>.Failure(Error.NotFound);
            }
            return Result<Address?>.Success(address);
        }
    }
}
