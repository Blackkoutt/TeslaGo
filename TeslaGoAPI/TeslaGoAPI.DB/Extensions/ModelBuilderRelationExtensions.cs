using Microsoft.EntityFrameworkCore;
using TeslaGoAPI.DB.Entities;

namespace TeslaGoAPI.DB.Extensions
{
    public static class ModelBuilderRelationExtensions
    {
        public static void ConfigureEntityRelations(this ModelBuilder builder)
        {
            // 1:1 Relation
            builder.Entity<CarModel>()
                .HasOne(x => x.CarModelDetails)
                .WithOne(x => x.CarModel)
                .HasForeignKey<CarModelDetails>(x => x.Id);

            // Custom 1:N Relation
            builder.Entity<Reservation>()
                .HasOne(x => x.PickupLocation)
                .WithMany(x => x.PickupReservations)
                .HasForeignKey(x => x.PickupLocationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Reservation>()
                .HasOne(x => x.ReturnLocation)
                .WithMany(x => x.ReturnReservations)
                .HasForeignKey(x => x.ReturnLocationId)
                .OnDelete(DeleteBehavior.NoAction);

            // N:N Relations
            builder.Entity<Car>()
                .HasMany(x => x.Locations)
                .WithMany(x => x.Cars)
                .UsingEntity<Car_Location>();

            builder.Entity<CarModel>()
                .HasMany(x => x.Equipments)
                .WithMany(x => x.CarModels)
                .UsingEntity<CarModel_Equipment>();

            builder.Entity<Reservation>()
                .HasMany(x => x.OptServices)
                .WithMany(x => x.Reservations)
                .UsingEntity<Reservation_OptService>();
        }
    }
}
