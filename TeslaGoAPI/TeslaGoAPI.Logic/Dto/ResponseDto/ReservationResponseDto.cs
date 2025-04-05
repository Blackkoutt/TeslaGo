using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Dto.ResponseDto
{
    public class ReservationResponseDto : BaseResponseDto
    {
        public DateTime ReservationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
        public UserResponseDto User { get; set; } = default!;
        public CarModelResponseDto CarModel { get; set; } = default!;
        public CarResponseDto? Car { get; set; } = default!;
        public PaymentMethodResponseDto? PaymentMethod { get; set; } = default!;
        public ICollection<OptServiceResponseDto> OptServices { get; set; } = [];
        public LocationResponseDto PickupLocation { get; set; } = default!;
        public LocationResponseDto ReturnLocation { get; set; } = default!;
        public bool IsActive { get; set; }
        public bool IsExpired { get; set; }
    }
}
