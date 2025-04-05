using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.ResponseDto
{
    public class EquipmentResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
