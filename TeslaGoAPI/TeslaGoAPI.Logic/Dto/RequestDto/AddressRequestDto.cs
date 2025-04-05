using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record AddressRequestDto(
        string Street,
        string HouseNr,
        short? FlatNr,
        string ZipCode,
        int CityId
    ) : IRequestDto;
}
