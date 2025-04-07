using System.Linq.Expressions;
using System.Reflection;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.DB.Entities.Abstract;
using TeslaGoAPI.Logic.Enums;
using TeslaGoAPI.Logic.Query;
using TeslaGoAPI.Logic.Query.Abstract;

namespace TeslaGoAPI.Logic.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<Address> ByQuery(this IQueryable<Address> queryable, AddressQuery query)
        {
            if (!string.IsNullOrEmpty(query.Street)) queryable = queryable.Where(x => x.Street.ToLower() == query.Street.ToLower());
            if (!string.IsNullOrEmpty(query.HouseNr)) queryable = queryable.Where(x => x.HouseNr.ToLower() == query.HouseNr.ToLower());
            if (query.FlatNr != null) queryable = queryable.Where(x => x.FlatNr == query.FlatNr);
            if (!string.IsNullOrEmpty(query.ZipCode)) queryable = queryable.Where(x => x.ZipCode.ToLower() == query.ZipCode.ToLower());
            if (query.CityId != null) queryable = queryable.Where(x => x.CityId == query.CityId);
            queryable = queryable.SortBy(query.SortBy, query.SortDirection);
            return queryable;
        }

        public static IQueryable<CarModel> ByQuery(this IQueryable<CarModel> queryable, CarModelQuery query)
        {
            if (!string.IsNullOrEmpty(query.Name)) queryable = queryable.Where(x => x.Name.ToLower() == query.Name.ToLower());
            if (query.MinPrice != null) queryable = queryable.Where(x => x.PricePerDay >= query.MinPrice);
            if (query.MaxPrice != null) queryable = queryable.Where(x => x.PricePerDay <= query.MaxPrice);
            if (query.MinRange != null) queryable = queryable.Where(x => x.Range >= query.MinRange);
            if (query.MaxRange != null) queryable = queryable.Where(x => x.Range <= query.MaxRange);
            if (query.BrandId != null) queryable = queryable.Where(x => x.BrandId == query.BrandId);
            if (query.GearBoxId != null) queryable = queryable.Where(x => x.GearBoxId == query.GearBoxId);
            if (query.FuelTypeId != null) queryable = queryable.Where(x => x.FuelTypeId == query.FuelTypeId);
            if (query.BodyTypeId != null) queryable = queryable.Where(x => x.BodyTypeId == query.BodyTypeId);
            if (query.ModelVersionId != null) queryable = queryable.Where(x => x.ModelVersionId == query.ModelVersionId);
            if (query.DriveTypeId != null) queryable = queryable.Where(x => x.DriveTypeId == query.DriveTypeId);
            if (query.MinHorsePower != null) queryable = queryable.Where(x => x.CarModelDetails.HorsePower >= query.MinHorsePower);
            if (query.MaxHorsePower != null) queryable = queryable.Where(x => x.CarModelDetails.HorsePower <= query.MaxHorsePower);
            if (query.MinTrunkCapacityLiters != null) queryable = queryable.Where(x => x.CarModelDetails.TrunkCapacityLiters >= query.MinTrunkCapacityLiters);
            if (query.MaxTrunkCapacityLiters != null) queryable = queryable.Where(x => x.CarModelDetails.TrunkCapacityLiters <= query.MaxTrunkCapacityLiters);
            queryable = queryable.SortBy(query.SortBy, query.SortDirection);
            return queryable;
        }

        public static IQueryable<Reservation> ByQuery(this IQueryable<Reservation> queryable, ReservationQuery query)
        {
            queryable = queryable.ByStatus(query.Status);
            queryable = queryable.ByDate(query);
            if (query.FromReservationDate != null) queryable = queryable.Where(x => x.ReservationDate >= query.FromReservationDate);
            if (query.ToReservationDate != null) queryable = queryable.Where(x => x.ReservationDate <= query.ToReservationDate);
            if (query.MinPrice != null) queryable = queryable.Where(x => x.TotalCost >= query.MinPrice);
            if (query.MaxPrice != null) queryable = queryable.Where(x => x.TotalCost <= query.MaxPrice);
            if (!string.IsNullOrEmpty(query.UserName)) queryable = queryable.Where(x => $"{x.User.Name} {x.User.Surname}".Contains(query.UserName));
            if (query.PickupLocationId != null) queryable = queryable.Where(x => x.PickupLocationId == query.PickupLocationId);
            if (query.ReturnLocationId != null) queryable = queryable.Where(x => x.ReturnLocationId == query.ReturnLocationId);
            if (query.CarModelId != null) queryable = queryable.Where(x => x.CarModelId == query.CarModelId);
            if (query.CarId != null) queryable = queryable.Where(x => x.CarId == query.CarId);
            if (query.PaymentMethodId != null) queryable = queryable.Where(x => x.PaymentMethodId == query.PaymentMethodId);
            queryable = queryable.SortBy(query.SortBy, query.SortDirection);
            return queryable;
        }

        public static IQueryable<TEntity> GetPage<TEntity>(this IQueryable<TEntity> query, int? pageNumber, int? pageSize)
        {
            if (pageNumber != null && pageSize != null)
            {
                var skipNumber = (int)((pageNumber - 1) * pageSize);
                return query.Skip(skipNumber).Take((int)pageSize);
            }
            return query;
        }

        public static IQueryable<TEntity> SortBy<TEntity>(this IQueryable<TEntity> query, string? sortBy, SortDirection? sortDirection) where TEntity : class
        {
            if (!string.IsNullOrEmpty(sortBy) && sortDirection != null)
            {
                PropertyInfo? property = typeof(TEntity)
                                        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                        .FirstOrDefault(p => p.Name.Equals(sortBy, StringComparison.OrdinalIgnoreCase));
                if (property == null) return query;

                var parameter = Expression.Parameter(typeof(TEntity), "x");

                // Property access expression (x.PropertyName)
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);

                // OrderBy lambda expression (x => x.PropertyName)
                var orderByExpression = Expression.Lambda(propertyAccess, parameter);

                // Get sorting method name
                string methodName = (sortDirection == SortDirection.DESC) ? "OrderByDescending" : "OrderBy";

                // Use reflection to get the correct method
                MethodInfo orderByMethod = typeof(Queryable).GetMethods()
                .Where(m => m.Name == methodName && m.GetParameters().Length == 2)
                    .Single()
                    .MakeGenericMethod(typeof(TEntity), property.PropertyType);

                var invokedMethodResult = orderByMethod.Invoke(
                            obj: null,
                            parameters: new object[] { query, orderByExpression });

                if (invokedMethodResult == null)
                    throw new Exception();

                return (IQueryable<TEntity>)invokedMethodResult;

            }
            return query;
        }

        public static IQueryable<TEntity> ByName<TEntity>(this IQueryable<TEntity> queryable, INameableQuery query)
        {
            if (!string.IsNullOrEmpty(query.Name)) queryable = queryable.Where(e => ((INameableEntity)e!).Name.ToLower().Contains(query.Name.ToLower()));
            return queryable;
        }

        public static IQueryable<TEntity> ByDate<TEntity>(this IQueryable<TEntity> queryable, IDateableQuery query)
        {
            if (query.FromDate != null)
            {
                queryable = queryable.Where(e => ((IDateableEntity)e!).StartDate >= query.FromDate ||
                                                  ((IDateableEntity)e!).EndDate > query.FromDate);
            }

            if (query.ToDate != null)
            {
                queryable = queryable.Where(e => ((IDateableEntity)e!).StartDate <= query.ToDate);
            }
            return queryable;
        }

        public static IQueryable<TEntity> ByStatus<TEntity>(this IQueryable<TEntity> queryable, Status? status) where TEntity : class
        {
            return status switch
            {
                Status.Active => queryable.Where(r => (!((ISoftDeleteable)r).IsDeleted && ((IDateableEntity)r).EndDate > DateTime.Now)),
                Status.Expired => queryable.Where(r => (!((ISoftDeleteable)r).IsDeleted && !(((IDateableEntity)r).EndDate > DateTime.Now))),
                Status.Deleted => queryable.Where(r => (((ISoftDeleteable)r).IsDeleted)),
                _ => queryable
            };
        }
    }
}
