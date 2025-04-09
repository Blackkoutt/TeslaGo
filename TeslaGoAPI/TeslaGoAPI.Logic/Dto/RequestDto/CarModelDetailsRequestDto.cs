using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record CarModelDetailsRequestDto(
        DateTime? ProductionStartYear,
        DateTime? ProductionEndYear,
        string? Description
    ) : IRequestDto;
}
