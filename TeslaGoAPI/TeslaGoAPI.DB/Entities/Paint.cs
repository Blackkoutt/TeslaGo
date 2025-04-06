using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class Paint : BaseEntity, INameableEntity
    {
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(7)]
        public string ColorHex { get; set; } = string.Empty;
        public ICollection<Car> Cars { get; set; } = [];
    }
}
