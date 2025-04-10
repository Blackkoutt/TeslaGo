using Microsoft.EntityFrameworkCore;
using TeslaGoAPI.DB.Context;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Repositories.Repositories.Abstract;

namespace TeslaGoAPI.Logic.Repositories.Repositories
{
    public sealed class AddressRepository(APIContext context) : GenericRepository<Address>(context)
    {
        public sealed override async Task<IEnumerable<Address>> GetAllAsync(Func<IQueryable<Address>, IQueryable<Address>>? query = null)
        {
            var _table = _context.Address
                         .Where(x => x.City != null)
                         .Include(x => x.City)
                            .ThenInclude(x => x!.Country);

            return await (query != null ? query(_table).ToListAsync() : _table.ToListAsync());
        }
        public sealed override async Task<Address?> GetOneAsync(int id)
        {
            return await _context.Address
                          .Where(x => x.City != null)
                          .Include(x => x.City)
                            .ThenInclude(x => x!.Country)
                          .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
