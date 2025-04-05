using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record DriveTypeRequestDto(
        string Name,
        string? Description
    ) : IRequestDto;
}
