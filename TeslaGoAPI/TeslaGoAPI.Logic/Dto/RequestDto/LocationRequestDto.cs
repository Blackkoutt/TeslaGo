using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record LocationRequestDto(
       string Name,
       AddressRequestDto AddressRequestDto
    ) : IRequestDto;
}
