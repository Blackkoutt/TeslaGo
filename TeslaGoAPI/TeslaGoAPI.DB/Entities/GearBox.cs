using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class GearBox : BaseEntity, INameableEntity, ISoftDeleteable
    {
        [MaxLength(80)]
        public string Name { get; set; } = string.Empty;
        public byte? NumberOfGears { get; set; }
        public ICollection<CarModel> CarModels { get; set; } = [];
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeleteDate { get; set; } = null;
    }
}
