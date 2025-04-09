using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class CarModelDetails : BaseEntity
    {
        public DateTime? ProductionStartYear { get; set; }   
        public DateTime? ProductionEndYear { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        public CarModel CarModel { get; set; } = default!;
    }
}
