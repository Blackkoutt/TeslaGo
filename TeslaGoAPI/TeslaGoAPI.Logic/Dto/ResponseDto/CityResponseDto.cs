using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.ResponseDto
{
    public class CityResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = string.Empty;
        public CountryResponseDto Country { get; set; } = default!;
    }
}
