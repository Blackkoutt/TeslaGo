using Bogus;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class Car_LocationSeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<Car_Location> entityBuilder, int modelCount, int carCountForEachModel, int locationCount, DateTime today)
        {
            Random random = new();

            int id = 1;

            var car_locationsCount = modelCount * carCountForEachModel;

            var carLocations = new List<Car_Location>();
            var faker = new Faker();

            for (int i = 0; i < car_locationsCount; i++)
            {
                carLocations.Add(new Car_Location
                {
                    Id = id,
                    CarId = id,              
                    FromDate = today,
                    LocationId = faker.Random.Int(1, locationCount),
                });
                id++;
            }
            entityBuilder.HasData(carLocations.ToArray());
        }
    }
}
