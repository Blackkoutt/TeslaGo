﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
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

            builder.Entity<User>()
                .HasOne(x => x.Address)
                .WithOne(x => x.User)
                .HasForeignKey<User>(x => x.AddressId);

            builder.Entity<Location>()
                .HasOne(x => x.Address)
                .WithOne(x => x.Location)
                .HasForeignKey<Location>(x => x.AddressId);

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

            builder.Entity<CarAvailabilityIssue>()
                .HasOne(x => x.Reservation)
                .WithMany(x => x.CarAvailabilityIssues)
                .HasForeignKey(x => x.ReservationId)
                .OnDelete(DeleteBehavior.NoAction);

            // N:N Relations
            builder.Entity<User>()
             .HasMany(e => e.Roles)
             .WithMany(e => e.Users)
             .UsingEntity<IdentityUserRole<int>>();
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
