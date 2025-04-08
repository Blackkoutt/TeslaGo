using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Dto.RequestDto;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Query;
using TeslaGoAPI.Logic.Services.Interfaces.Abstract;

namespace TeslaGoAPI.Logic.Services.Interfaces
{
    public interface IAddressService : IGenericService<
        Address,
        AddressRequestDto,
        AddressRequestDto,
        AddressResponseDto,
        AddressQuery
    >
    {
        Task AddCityToAddress(Address address, string cityName, int countryId);
    }
}
