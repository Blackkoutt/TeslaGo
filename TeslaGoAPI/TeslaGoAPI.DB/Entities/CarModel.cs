using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class CarModel : BaseEntity, INameableEntity, ISoftDeleteable
    {
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        public byte SeatCount { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal PricePerDay { get; set; }
        public short? Range { get; set; }
        public string? ImageName { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = default!;
        public int GearBoxId { get; set; }
        public GearBox GearBox { get; set; } = default!;
        public int FuelTypeId { get; set; }
        public FuelType FuelType { get; set; } = default!;
        public int BodyTypeId { get; set; }
        public BodyType BodyType { get; set; } = default!;
        public int ModelVersionId { get; set; }
        public ModelVersion ModelVersion { get; set; } = default!;
        public int DriveTypeId { get; set; }
        public DriveType DriveType { get; set; } = default!;
        public CarModelDetails CarModelDetails { get; set; } = default!;
        public ICollection<Equipment> Equipments { get; set; } = [];   
        public ICollection<Car> Cars { get; set; } = [];
        public ICollection<CarModel> Reservations { get; set; } = [];
        public ICollection<CarAvailabilityIssue> CarAvailabilityIssues { get; set; } = [];
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeleteDate { get; set; } = null;
    }
}
