using Microsoft.EntityFrameworkCore;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.DB.Extensions.SeedingExtensions;

namespace TeslaGoAPI.DB.Extensions
{
    public static class ModelBuilderSeedExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            var today = new DateTime(2025, 4, 5, 12, 0, 0);

            const int modelCount = 15;
            const int paintCount = 7;
            const int carCount = 7;
            const int locationCount = 4;

            builder.Entity<Country>().Seed();
            builder.Entity<City>().Seed();
            builder.Entity<Address>().Seed();

            builder.SeedUsers(today);
            builder.SeedRoles();
            builder.SeedUsersInRoles();

            builder.Entity<BodyType>().Seed();
            builder.Entity<Brand>().Seed();

            builder.Entity<Entities.DriveType>().Seed();
            builder.Entity<Equipment>().Seed();
            builder.Entity<FuelType>().Seed();
            builder.Entity<GearBox>().Seed();
            builder.Entity<ModelVersion>().Seed();
            builder.Entity<OptService>().Seed();
            builder.Entity<Paint>().Seed();
            builder.Entity<PaymentMethod>().Seed();
            builder.Entity<Location>().Seed();
            builder.Entity<CarModelDetails>().Seed();
            builder.Entity<CarModel>().Seed();
            builder.Entity<CarModel_Equipment>().Seed();
            builder.Entity<Car>().Seed(modelCount, carCount, paintCount);
            builder.Entity<Car_Location>().Seed(modelCount, carCount, locationCount, today);
        }
    }
}
