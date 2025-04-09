using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TeslaGoAPI.DB.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TeslaGoAPI.DB.Extensions
{
    public static class ModelBuilderConstraintExtensions
    {
        public static void AddEntitiesConstraints(this ModelBuilder builder)
        {
            builder.Entity<OptService>().AddRangeConstraint(x => x.Price, 0m, 50000m);

            builder.Entity<Address>().AddRangeConstraint(x => x.FlatNr, 0, 10000);

            builder.Entity<Car>().AddLengthConstraint(x => x.VIN, 17, 17);

            builder.Entity<CarModel>().AddRangeConstraint(x => x.SeatCount, 1, byte.MaxValue);
            builder.Entity<CarModel>().AddRangeConstraint(x => x.PricePerDay, 0m, 50000m);
            builder.Entity<CarModel>().AddRangeConstraint(x => x.Range, 0, 10000);

            builder.Entity<CarModel>().AddRangeConstraint(x => x.DoorCount, 1, 30);
            builder.Entity<CarModel>().AddRangeConstraint(x => x.HorsePower, 1, 10000);
            builder.Entity<CarModel>().AddRangeConstraint(x => x.AccelerationInSeconds, 0, 1000m);
            builder.Entity<CarModel>().AddRangeConstraint(x => x.MaxSpeedInKmPerHour, 1, 1000);
            builder.Entity<CarModel>().AddRangeConstraint(x => x.TrunkCapacityLiters, 0, 10000);
            builder.Entity<CarModel>().AddRangeConstraint(x => x.TrunkCapacitySuitCases, 0, 50);

            builder.Entity<Paint>().AddLengthConstraint(x => x.ColorHex, 7, 7);

            builder.Entity<Reservation>().AddRangeConstraint(x => x.TotalCost, 0m, 1000000m);
        }

        private static void AddRangeConstraint<T, TProp>(this EntityTypeBuilder<T> entityBuilder, Expression<Func<T, TProp?>> prop, TProp min, TProp? max)
            where T : class
            where TProp : struct
        {
            var propName = prop.GetMemberAccess().Name;

            string constraint = max is null
                ? $"[{propName}] >= {min}"
                : $"[{propName}] BETWEEN {min} AND {max}";

            entityBuilder.AddConstraint(propName, constraint);
        }

        private static void AddLengthConstraint<T>(this EntityTypeBuilder<T> entityBuilder, Expression<Func<T, string>> prop, int min, int? max)
            where T : class
        {
            var propName = prop.GetMemberAccess().Name;

            string constraint = max is null
                ? $"LEN([{propName}]) >= {min}"
                : $"LEN([{propName}]) BETWEEN {min} AND {max}";

            entityBuilder.AddConstraint(propName, constraint);
        }

        private static void AddConstraint<T>(this EntityTypeBuilder<T> entityBuilder, string propName, string constraintExpression)
            where T : class
        {
            var tableName = typeof(T).Name;
            var constraintName = $"CK_{tableName}_{propName}";
            entityBuilder.ToTable(x => x.HasCheckConstraint(constraintName, constraintExpression));
        }
    }
}
