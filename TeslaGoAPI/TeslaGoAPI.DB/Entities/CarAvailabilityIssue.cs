using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class CarAvailabilityIssue : BaseEntity
    {
        public DateTime IssueDetectionDate { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; } = default!;
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; } = default!;
        public int LocationId { get; set; }
        public Location Location { get; set; } = default!;
    }
}
