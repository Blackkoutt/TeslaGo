using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record FuelTypeRequestDto(
        string Name
    ) : IRequestDto;
}
