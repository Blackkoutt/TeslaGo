using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class Location : BaseEntity
    {
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        public int AddressId { get; set; }
        public Address Address { get; set; } = default!;
        public ICollection<Car_Location> Cars { get; set; } = [];
        public ICollection<Reservation> ReturnReservations { get; set; } = [];
        public ICollection<Reservation> PickupReservations { get; set; } = [];
    }
}
