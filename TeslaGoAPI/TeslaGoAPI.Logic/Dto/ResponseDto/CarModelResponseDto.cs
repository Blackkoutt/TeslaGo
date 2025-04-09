using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.ResponseDto
{
    public class CarModelResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = string.Empty;
        public byte SeatCount { get; set; }
        public decimal PricePerDay { get; set; }
        public short? Range { get; set; }
        public int AllCarsCount { get; set; }
        public string ImageEndpoint { get; set; } = string.Empty;
        public BrandResponseDto Brand { get; set; } = default!;
        public GearBoxResponseDto? GearBox { get; set; } = default!;
        public FuelTypeResponseDto? FuelType { get; set; } = default!;
        public BodyTypeResponseDto BodyType { get; set; } = default!;
        public ModelVersionResponseDto ModelVersion { get; set; } = default!;
        public DriveTypeResponseDto DriveType { get; set; } = default!;
        public CarModelDetailsResponseDto? CarModelDetails { get; set; } = default!;
        public ICollection<EquipmentResponseDto> Equipments { get; set; } = [];
    }
}
