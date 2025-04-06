using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.RequestDto
{
    public record PaymentMethodRequestDto(
        string Name
    ) : IRequestDto, INameableRequestDto;
}
