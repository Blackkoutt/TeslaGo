using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class Car_Location : BaseEntity
    {
        public int CarId { get; set; }
        public DateTime FromDate { get; set; }
        public Car Car { get; set; } = default!;
        public int LocationId { get; set; }
        public Location Location { get; set; } = default!;
    }
}
