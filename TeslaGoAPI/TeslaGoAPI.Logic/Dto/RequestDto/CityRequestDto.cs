using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record CityRequestDto(
        string Name,
        int CountryId
    ) : IRequestDto, INameableRequestDto;
}
