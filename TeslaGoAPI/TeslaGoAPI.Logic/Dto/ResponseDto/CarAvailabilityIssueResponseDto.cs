using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.ResponseDto
{
    public class CarAvailabilityIssueResponseDto : BaseResponseDto
    {
        public DateTime IssueDetectionDate { get; set; }
        public ReservationResponseDto Reservation { get; set; } = default!;
        public CarModelResponseDto CarModel { get; set; } = default!;
        public LocationResponseDto Location { get; set; } = default!;
    }
}
