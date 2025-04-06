using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record ModelVersionRequestDto(
       string Name,
       string? Description
    ) : IRequestDto, INameableRequestDto;
}
