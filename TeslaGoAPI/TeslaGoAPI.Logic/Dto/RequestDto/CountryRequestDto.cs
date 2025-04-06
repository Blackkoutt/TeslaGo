using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record CountryRequestDto (
        string Name
    ) : IRequestDto, INameableRequestDto;
}
