using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class OptService : BaseEntity, INameableEntity, ISoftDeleteable
    {
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = [];
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeleteDate { get; set; } = null;
    }
}
