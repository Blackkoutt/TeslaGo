using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.ResponseDto
{
    public class CarModelDetailsResponseDto : BaseResponseDto
    {
        public byte? DoorCount { get; set; }
        public short? HorsePower { get; set; }
        public DateTime? ProductionStartYear { get; set; }
        public DateTime? ProductionEndYear { get; set; }
        public string? Description { get; set; }
        public decimal? AccelerationInSeconds { get; set; }
        public short? MaxSpeedInKmPerHour { get; set; }
        public int? TrunkCapacityLiters { get; set; }
        public int? TrunkCapacitySuitCases { get; set; }
    }
}
