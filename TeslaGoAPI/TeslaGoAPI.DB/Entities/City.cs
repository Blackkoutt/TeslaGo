using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class City : BaseEntity, INameableEntity, ISoftDeleteable
    {
        [MaxLength(80)]
        public string Name { get; set; } = string.Empty;
        public int? CountryId { get; set; }
        public Country? Country { get; set; } = default!;
        public ICollection<Address> Addresses { get; set; } = [];
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeleteDate { get; set; } = null;
    }
}
