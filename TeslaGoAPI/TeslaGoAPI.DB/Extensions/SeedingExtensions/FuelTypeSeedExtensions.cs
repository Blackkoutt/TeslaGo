using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class FuelTypeSeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<FuelType> entityBuilder)
        {
            entityBuilder.HasData(
                new FuelType
                {
                    Id = 1,
                    Name = "Electric"
                }
            );
        }
    }
}
