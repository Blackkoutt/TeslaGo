using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.ResponseDto
{
    public class Car_LocationResponseDto : BaseResponseDto
    {
        public DateTime FromDate { get; set; }
        public LocationResponseDto? Location { get; set; } = default!;
    }
}
