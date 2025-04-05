using Microsoft.EntityFrameworkCore;
using TeslaGoAPI.DB.Context;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Repositories.Repositories.Abstract;

namespace TeslaGoAPI.Logic.Repositories.Repositories
{
    public sealed class CityRepository(APIContext context) : GenericRepository<City>(context)
    {
        public sealed override async Task<IEnumerable<City>> GetAllAsync(Func<IQueryable<City>, IQueryable<City>>? query = null)
        {
            var _table = _context.City
                         .Include(x => x.Country);

            return await (query != null ? query(_table).ToListAsync() : _table.ToListAsync());
        }
        public sealed override async Task<City?> GetOneAsync(int id)
        {
            return await _context.City
                         .Include(x => x.Country)
                          .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
