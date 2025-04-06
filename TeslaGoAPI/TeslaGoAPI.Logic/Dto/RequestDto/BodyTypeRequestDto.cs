using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record BodyTypeRequestDto(
        string Name
    ) : IRequestDto, INameableRequestDto;
}
