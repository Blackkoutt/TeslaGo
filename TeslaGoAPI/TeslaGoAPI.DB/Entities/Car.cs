using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class Car : BaseEntity
    {
        [MaxLength(17)]
        public string VIN { get; set; } = string.Empty;

        [MaxLength(20)]
        public string RegistrationNr { get; set; } = string.Empty;

        public int ModelId { get; set; }
        public CarModel Model { get; set; } = default!;
        public int PaintId { get; set; }
        public Paint Paint { get; set; } = default!;
        public ICollection<Car_Location> Locations { get; set; } = [];
        public ICollection<Reservation> Reservations { get; set; } = [];
    }
}
