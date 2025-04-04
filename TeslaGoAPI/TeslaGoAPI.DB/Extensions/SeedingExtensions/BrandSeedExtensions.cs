using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class BrandSeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<Brand> entityBuilder)
        {
            entityBuilder.HasData(
                new Brand
                {
                    Name = "Tesla"
                }
            );
        }
    }
}
