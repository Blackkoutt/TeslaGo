using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.ResponseDto
{
    public class CarResponseDto : BaseResponseDto
    {
        public string VIN { get; set; } = string.Empty;
        public string RegistrationNr { get; set; } = string.Empty;
        public CarModelResponseDto Model { get; set; } = default!;
        public PaintResponseDto? Paint { get; set; } = default!;
        public ICollection<Car_LocationResponseDto> Locations { get; set; } = [];
        public Car_LocationResponseDto? ActualLocation { get; set; }
    }
}
