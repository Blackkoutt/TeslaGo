using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class Equipment : BaseEntity, INameableEntity
    {
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }
        public ICollection<CarModel> CarModels { get; set; } = [];
    }
}
