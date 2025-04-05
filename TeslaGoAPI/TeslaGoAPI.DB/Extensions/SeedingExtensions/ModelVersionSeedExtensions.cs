using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class ModelVersionSeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<ModelVersion> entityBuilder)
        {
            entityBuilder.HasData(
                new ModelVersion
                {
                    Id = 1,
                    Name = "Standard",
                    Description = "Standard range, standard performance"
                },
                new ModelVersion
                {
                    Id = 2,
                    Name = "Long Range",
                    Description = "Longer range, standard performance"

                },
                new ModelVersion
                {
                    Id = 3,
                    Name = "Performance",
                    Description = "High-performance version with quicker acceleration"
                },
                new ModelVersion
                {
                    Id = 4,
                    Name = "Plaid",
                    Description = "Top performance with three motors and extreme acceleration"
                },
                new ModelVersion
                {
                    Id = 5,
                    Name = "Cyber-beast",
                    Description = "Tri-motor performance with extreme acceleration and off-road prowess."
                }
            );
        }
    }
}
