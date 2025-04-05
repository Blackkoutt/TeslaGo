using Microsoft.EntityFrameworkCore;
using TeslaGoAPI.DB.Context;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Repositories.Repositories.Abstract;

namespace TeslaGoAPI.Logic.Repositories.Repositories
{
    public sealed class LocationRepository(APIContext context) : GenericRepository<Location>(context)
    {
        public sealed override async Task<Location?> GetOneAsync(int id)
        {
            return await _context.Location
                          .Include(x => x.Address)
                            .ThenInclude(x => x.City)
                                .ThenInclude(x => x.Country)
                          .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
