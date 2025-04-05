using Bogus;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions.SeedingExtensions
{
    public static class CarSeedExtensions
    {
        public static void Seed(this EntityTypeBuilder<Car> entityBuilder, int modelCount, int carCountForEachModel, int paintCount)
        {
            int id = 1;

            var cars = new List<Car>();
            var faker = new Faker();

            for (int modelId = 1; modelId < modelCount + 1; modelId ++)
            {
                for (int i = 0; i < carCountForEachModel; i++)
                {
                    cars.Add(new Car
                    {
                        Id = id++,
                        VIN = faker.Vehicle.Vin(),
                        RegistrationNr = (faker.Lorem.Letter(3) + " " + faker.Random.Int(100, 999).ToString()).ToUpper(),
                        ModelId = modelId,
                        PaintId = faker.Random.Int(1, paintCount),
                    });
                }
            }
            entityBuilder.HasData(cars.ToArray());
        }
    }
}
