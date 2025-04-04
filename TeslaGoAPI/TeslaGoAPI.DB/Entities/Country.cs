using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class Country : BaseEntity
    {
        [MaxLength(80)]
        public string Name { get; set; } = string.Empty;
        public ICollection<City> Cities { get; set; } = [];
    }
}
