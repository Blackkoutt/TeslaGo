using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class LocationSeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<Location> entityBuilder)
        {
            entityBuilder.HasData(
                new Location
                {
                    Id = 1,
                    Name = "Palma Airport",
                    AddressId = 1,
                },
                new Location
                {
                    Id = 2,
                    Name = "Palma City Center",
                    AddressId = 2,
                },
                new Location
                {
                    Id = 3,
                    Name = "Alcudia",
                    AddressId = 3,
                },
                new Location
                {
                    Id = 4,
                    Name = "Manacor",
                    AddressId = 4,
                }
            );
        }
    }
}
