using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class User : IdentityUser<int>, IEntity
    {
        [MaxLength(60)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(80)]
        public string Surname { get; set; } = string.Empty;

        [MaxLength(30)]
        public string? DrivingLicenseNumber { get; set; }

        public DateTime RegisteredDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? AddressId { get; set; }
        public Address? Address { get; set; } = default!;
        public ICollection<Reservation> Reservations { get; set; } = [];
        public ICollection<Role> Roles { get; set; } = [];
    }
}
