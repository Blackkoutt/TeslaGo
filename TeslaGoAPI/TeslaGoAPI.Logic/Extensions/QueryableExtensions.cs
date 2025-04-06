using System.Linq.Expressions;
using System.Reflection;
using TeslaGoAPI.DB.Entities.Abstract;
using TeslaGoAPI.Logic.Enums;
using TeslaGoAPI.Logic.Query.Abstract;

namespace TeslaGoAPI.Logic.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TEntity> GetPage<TEntity>(this IQueryable<TEntity> query, int? pageNumber, int? pageSize)
        {
            if (pageNumber != null && pageSize != null)
            {
                var skipNumber = (int)((pageNumber - 1) * pageSize);
                return query.Skip(skipNumber).Take((int)pageSize);
            }
            return query;
        }

        public static IQueryable<TEntity> SortBy<TEntity>(this IQueryable<TEntity> query, string? sortBy, SortDirection sortDirection) where TEntity : class
        {
            if (!string.IsNullOrEmpty(sortBy))
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
    }
}
