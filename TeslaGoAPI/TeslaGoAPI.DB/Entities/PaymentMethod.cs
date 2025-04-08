using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class PaymentMethod : BaseEntity, INameableEntity, ISoftDeleteable
    {
        [MaxLength(60)]
        public string Name { get; set; } = string.Empty;
        public ICollection<Reservation> Reservations { get; set; } = [];
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeleteDate { get; set; } = null;
    }
}
