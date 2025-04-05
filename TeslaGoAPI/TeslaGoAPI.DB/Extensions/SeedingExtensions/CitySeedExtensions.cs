using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class CitySeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<City> entityBuilder)
        {
            entityBuilder.HasData(
                new City
                {
                    Id = 1,
                    Name = "Palma",
                    CountryId = 1
                },
                new City
                {
                    Id = 2,
                    Name = "Alcudia",
                    CountryId = 1
                },
                new City
                {
                    Id = 3,
                    Name = "Manacor",
                    CountryId = 1
                },
                new City
                {
                    Id = 4,
                    Name = "Inca",
                    CountryId = 1
                },
                new City
                {
                    Id = 5,
                    Name = "Santanyí",
                    CountryId = 1
                },
                new City
                {
                    Id = 6,
                    Name = "Sóller",
                    CountryId = 1
                },
                new City
                {
                    Id = 7,
                    Name = "Magaluf",
                    CountryId = 1
                },
                new City
                {
                    Id = 8,
                    Name = "Porto Cristo",
                    CountryId = 1
                },
                new City
                {
                    Id = 9,
                    Name = "Campos",
                    CountryId = 1
                },
                new City
                {
                    Id = 10,
                    Name = "Marratxí",
                    CountryId = 1
                },
                new City
                {
                    Id = 11,
                    Name = "Warsaw",
                    CountryId = 2
                },
                new City
                {
                    Id = 12,
                    Name = "Kraków",
                    CountryId = 2
                },
                new City
                {
                    Id = 13,
                    Name = "Madrid",
                    CountryId = 1
                },
                new City
                {
                    Id = 14,
                    Name = "Barcelona",
                    CountryId = 1
                },
                new City
                {
                    Id = 15,
                    Name = "Berlin",
                    CountryId = 3
                },
                new City
                {
                    Id = 16,
                    Name = "Munich",
                    CountryId = 3
                },
                new City
                {
                    Id = 17,
                    Name = "Paris",
                    CountryId = 4
                },
                new City
                {
                    Id = 18,
                    Name = "Lyon",
                    CountryId = 1
                },
                new City
                {
                    Id = 19,
                    Name = "Rome",
                    CountryId = 5
                },
                new City
                {
                    Id = 20,
                    Name = "Milan",
                    CountryId = 5
                }
            );
        }
    }
}
