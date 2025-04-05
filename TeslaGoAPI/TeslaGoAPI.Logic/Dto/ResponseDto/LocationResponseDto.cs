using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.ResponseDto
{
    public class LocationResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = string.Empty;
        public AddressResponseDto? Address { get; set; } = default!;
    }
}
