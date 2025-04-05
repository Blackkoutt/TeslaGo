using Microsoft.EntityFrameworkCore;
using TeslaGoAPI.DB.Context;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Repositories.Repositories.Abstract;

namespace TeslaGoAPI.Logic.Repositories.Repositories
{
    public sealed class UserRepository(APIContext context) : GenericRepository<User>(context)
    {
        public sealed override async Task<User?> GetOneAsync(int id)
        {
            return await _context.Users
                             .Include(x => x.Roles)
                             .Include(x => x.Address)
                             .Include(x => x.Reservations)
                             .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
