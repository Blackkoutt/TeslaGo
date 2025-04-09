using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.ResponseDto
{
    public class CarModelDetailsResponseDto : BaseResponseDto
    {
        public DateTime? ProductionStartYear { get; set; }
        public DateTime? ProductionEndYear { get; set; }
        public string? Description { get; set; }
    }
}
