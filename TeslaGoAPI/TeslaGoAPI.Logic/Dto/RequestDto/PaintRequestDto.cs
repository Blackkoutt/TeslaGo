using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record PaintRequestDto(
        string Name,
        string ColorHex
    ) : IRequestDto, INameableRequestDto;
}
