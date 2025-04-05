using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.ResponseDto
{
    public class PaymentMethodResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = string.Empty;
    }
}
