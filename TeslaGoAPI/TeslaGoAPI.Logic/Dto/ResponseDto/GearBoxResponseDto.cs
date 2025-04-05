using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.ResponseDto
{
    public class GearBoxResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = string.Empty;
        public byte? NumberOfGears { get; set; }
    }
}
