using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.ResponseDto
{
    public class PaintResponseDto : BaseResponseDto
    {
        public string Name { get; set; } = string.Empty;
        public string ColorHex { get; set; } = string.Empty;
    }
}
