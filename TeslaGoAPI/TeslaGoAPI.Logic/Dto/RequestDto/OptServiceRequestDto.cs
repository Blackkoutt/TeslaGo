using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record OptServiceRequestDto(
       string Name,
       decimal Price,
       string? Description
    ) : IRequestDto;
}
