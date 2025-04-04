using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class Address : BaseEntity
    {
        [MaxLength(150)]
        public string Street { get; set; } = string.Empty;

        [MaxLength(10)]
        public string HouseNr { get; set; } = string.Empty;

        public short FlatNr { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; } = string.Empty;

        public int CityId { get; set; }
        public City City { get; set; } = default!;
        public ICollection<Location> Locations { get; set; } = [];
        public ICollection<User> Users { get; set; } = [];
    }
}
