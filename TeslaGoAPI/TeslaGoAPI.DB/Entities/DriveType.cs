using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class DriveType : BaseEntity, INameableEntity
    {
        [MaxLength(80)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; } = string.Empty;
        public ICollection<CarModel> CarModels { get; set; } = [];
    }
}
