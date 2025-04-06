using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record BrandRequestDto(
        string Name
    ) : IRequestDto, INameableRequestDto;
}
