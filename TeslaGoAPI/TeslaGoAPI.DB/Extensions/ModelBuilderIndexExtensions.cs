using Microsoft.EntityFrameworkCore;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions
{
    public static class ModelBuilderIndexExtensions
    {
        public static void AddEntitiesIndexes(this ModelBuilder builder)
        {
            builder.Entity<Car>().HasIndex(x => x.VIN).IsUnique();
            builder.Entity<Car>().HasIndex(x => x.RegistrationNr).IsUnique();
            builder.Entity<User>().HasIndex(x => x.DrivingLicenseNumber).IsUnique();
            builder.Entity<Reservation>().HasIndex(x => x.PickupLocationId);
        }
    }
}
