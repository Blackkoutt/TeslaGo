using Microsoft.EntityFrameworkCore;
using TeslaGoAPI.DB.Context;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Repositories.Repositories.Abstract;

namespace TeslaGoAPI.Logic.Repositories.Repositories
{
    public sealed class CarRepository(APIContext context) : GenericRepository<Car>(context)
    {
        public sealed override async Task<IEnumerable<Car>> GetAllAsync(Func<IQueryable<Car>, IQueryable<Car>>? query = null)
        {
            var _table = _context.Car
                         .Include(x => x.Locations)
                            .ThenInclude(x => x.Location)
                         .Include(x => x.Model)
                            .ThenInclude(x => x.Brand)
                         .Include(x => x.Model)
                            .ThenInclude(x => x.BodyType)
                         .Include(x => x.Model)
                            .ThenInclude(x => x.ModelVersion)
                         .Include(x => x.Model)
                            .ThenInclude(x => x.DriveType);

            foreach (var item in _table) 
            {
                item.ActualLocation = item.Locations.OrderByDescending(l => l.FromDate).FirstOrDefault();
            }

            return await (query != null ? query(_table).ToListAsync() : _table.ToListAsync());
        }
        public sealed override async Task<Car?> GetOneAsync(int id)
        {
            var car = await _context.Car
                        .Include(x => x.Paint)
                        .Include(x => x.Locations)
                            .ThenInclude(x => x.Location)
                        .Include(x => x.Model)
                            .ThenInclude(x => x.Brand)
                        .Include(x => x.Model)
                            .ThenInclude(x => x.GearBox)
                        .Include(x => x.Model)
                            .ThenInclude(x => x.FuelType)
                        .Include(x => x.Model)
                            .ThenInclude(x => x.BodyType)
                        .Include(x => x.Model)
                            .ThenInclude(x => x.ModelVersion)
                        .Include(x => x.Model)
                            .ThenInclude(x => x.DriveType)
                        .Include(x => x.Model)
                            .ThenInclude(x => x.CarModelDetails)
                        .Include(x => x.Model)
                            .ThenInclude(x => x.Equipments)
                        .FirstOrDefaultAsync(x => x.Id == id);

            if (car != null) car.ActualLocation = car.Locations.OrderByDescending(l => l.FromDate).FirstOrDefault();

            return car;
        }
    }
}
