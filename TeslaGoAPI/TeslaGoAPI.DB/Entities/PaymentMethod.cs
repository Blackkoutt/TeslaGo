using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class PaymentMethod : BaseEntity, INameableEntity
    {
        [MaxLength(60)]
        public string Name { get; set; } = string.Empty;
        public ICollection<Reservation> Reservations { get; set; } = [];
    }
}
