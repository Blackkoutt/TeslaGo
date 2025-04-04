using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TeslaGoAPI.DB.Entities.Abstract;

namespace TeslaGoAPI.DB.Entities
{
    public class Role : IdentityRole<int>, IEntity
    {
        [MaxLength(500)]
        public string? Description { get; set; }
        public ICollection<User> Users { get; set; } = [];
    }
}
