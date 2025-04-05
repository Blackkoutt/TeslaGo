using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class CountrySeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<Country> entityBuilder)
        {
            entityBuilder.HasData(
                new Country
                {
                    Id = 1,
                    Name = "Spain"
                },
                new Country
                {
                    Id = 2,
                    Name = "Poland"
                },
                new Country
                {
                    Id = 3,
                    Name = "Germany"
                },
                new Country
                {
                    Id = 4,
                    Name = "France"
                },
                new Country
                {
                    Id = 5,
                    Name = "Italy"
                }
            );
        }
    }
}
