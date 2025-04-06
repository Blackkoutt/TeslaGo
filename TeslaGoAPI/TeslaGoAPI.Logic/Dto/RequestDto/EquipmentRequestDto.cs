using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record EquipmentRequestDto(
        string Name,
        string? Description
    ) : IRequestDto, INameableRequestDto;
}
