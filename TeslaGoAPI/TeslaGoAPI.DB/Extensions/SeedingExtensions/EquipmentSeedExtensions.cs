using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class EquipmentSeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<Equipment> entityBuilder)
        {
            entityBuilder.HasData(
                new Equipment
                {
                    Id = 1,
                    Name = "Autopilot",
                    Description = "Advanced driver assistance system with automatic lane-keeping, adaptive cruise control, and more."
                },
                new Equipment
                {
                    Id = 2,
                    Name = "Full Self-Driving (FSD) Package",
                    Description = "Includes Autopilot features plus Navigate on Autopilot, Auto Park, Summon, and more."
                },
                new Equipment
                {
                    Id = 3,
                    Name = "Premium Interior",
                    Description = "Upgraded interior with premium audio, ambient lighting, and more luxurious finishes."
                },
                new Equipment
                {
                    Id = 4,
                    Name = "Heated Seats",
                    Description = "Heated front and rear seats for added comfort during cold weather."
                },
                new Equipment
                {
                    Id = 5,
                    Name = "Glass Roof",
                    Description = "Panoramic glass roof providing an open, airy feel and UV protection."
                },
                new Equipment
                {
                    Id = 6,
                    Name = "Supercharging",
                    Description = "Access to Tesla's Supercharger network for fast charging."
                },
                new Equipment
                {
                    Id = 7,
                    Name = "Premium Connectivity",
                    Description = "Access to premium features such as satellite maps, live traffic visualizations, and more."
                },
                new Equipment
                {
                    Id = 8,
                    Name = "Towing Package",
                    Description = "Includes a tow hitch and towing accessories for hauling trailers or other gear."
                },
                 new Equipment
                 {
                     Id = 9,
                     Name = "19\" Wheels",
                     Description = "Basic 19-inch wheels"
                 },
                new Equipment
                {
                    Id = 10,
                    Name = "20\" Wheels",
                    Description = "Larger 20-inch wheels for better performance and appearance."
                },
                new Equipment
                {
                    Id = 11,
                    Name = "20\" Sport Wheels",
                    Description = "Sportier 20-inch wheels for enhanced performance and aesthetics."
                },
                new Equipment
                {
                    Id = 12,
                    Name = "Enhanced Audio System",
                    Description = "Upgraded audio system with premium sound quality."
                },
                new Equipment
                {
                    Id = 13,
                    Name = "Smart Summon",
                    Description = "Ability to remotely summon your Tesla to you using the Tesla app."
                }
            );
        }
    }
}
