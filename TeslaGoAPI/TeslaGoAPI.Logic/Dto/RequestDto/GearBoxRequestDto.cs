using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record GearBoxRequestDto(
        string Name,
        byte? NumberOfGears
    ) : IRequestDto, INameableRequestDto;
}
