using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class CarModelDetails : BaseEntity
    {
        public byte? DoorCount { get; set; }
        public short? HorsePower { get; set; }
        public DateTime? ProductionStartYear { get; set; }   
        public DateTime? ProductionEndYear { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        public decimal? AccelerationInSeconds { get; set; }
        public short? MaxSpeedInKmPerHour { get; set; }
        public int? TrunkCapacityLiters { get; set; }
        public int? TrunkCapacitySuitCases { get; set; }
        public CarModel CarModel { get; set; } = default!;
    }
}
