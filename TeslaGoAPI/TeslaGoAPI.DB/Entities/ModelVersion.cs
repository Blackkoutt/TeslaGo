using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class ModelVersion : BaseEntity
    {
        [MaxLength(80)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; } 
        public ICollection<CarModel> CarModels { get; set; } = [];
    }
}
