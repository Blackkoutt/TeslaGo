using Microsoft.EntityFrameworkCore;
using TeslaGoAPI.DB.Context;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Repositories.Repositories.Abstract;

namespace TeslaGoAPI.Logic.Repositories.Repositories
{
    public sealed class CarModelRepository(APIContext context) : GenericRepository<CarModel>(context)
    {
        public sealed override async Task<IEnumerable<CarModel>> GetAllAsync(Func<IQueryable<CarModel>, IQueryable<CarModel>>? query = null)
        {
            var _table = _context.CarModel
                         .Include(x => x.Cars)
                            .ThenInclude(x => x.Locations.OrderByDescending(l => l.FromDate).Take(1))
                                .ThenInclude(x => x.Location)
                         .Include(x => x.Brand)
                         .Include(x => x.BodyType)
                         .Include(x => x.ModelVersion)
                         .Include(x => x.DriveType);

            return await (query != null ? query(_table).ToListAsync() : _table.ToListAsync());
        }
        public sealed override async Task<CarModel?> GetOneAsync(int id)
        {
            var car = await _context.CarModel
                             .Include(x => x.Cars)
                                .ThenInclude(x => x.Locations.OrderByDescending(l => l.FromDate).Take(1))
                                    .ThenInclude(x => x.Location)
                            .Include(x => x.Brand)
                            .Include(x => x.GearBox)
                            .Include(x => x.FuelType)
                            .Include(x => x.BodyType)
                            .Include(x => x.ModelVersion)
                            .Include(x => x.DriveType)
                            .Include(x => x.CarModelDetails)
                            .Include(x => x.Equipments)
                            .FirstOrDefaultAsync(x => x.Id == id);

            return car;
        }
    }
}
