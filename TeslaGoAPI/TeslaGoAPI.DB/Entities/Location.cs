using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class Location : BaseEntity, INameableEntity, ISoftDeleteable
    {
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        public int AddressId { get; set; }
        public Address Address { get; set; } = default!;
        public ICollection<Car_Location> Cars { get; set; } = [];
        public ICollection<Reservation> ReturnReservations { get; set; } = [];
        public ICollection<Reservation> PickupReservations { get; set; } = [];
        public ICollection<CarAvailabilityIssue> CarAvailabilityIssues { get; set; } = [];
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeleteDate { get; set; } = null;
    }
}
