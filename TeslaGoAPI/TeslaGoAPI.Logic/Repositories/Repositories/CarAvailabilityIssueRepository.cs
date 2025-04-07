using Microsoft.EntityFrameworkCore;
using TeslaGoAPI.DB.Context;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Repositories.Repositories.Abstract;

namespace TeslaGoAPI.Logic.Repositories.Repositories
{
    public sealed class CarAvailabilityIssueRepository(APIContext context) : GenericRepository<CarAvailabilityIssue>(context)
    {
        public sealed override async Task<IEnumerable<CarAvailabilityIssue>> GetAllAsync(Func<IQueryable<CarAvailabilityIssue>, IQueryable<CarAvailabilityIssue>>? query = null)
        {
            var _table = _context.CarAvailabilityIssue
                         .Include(x => x.Reservation)
                            .ThenInclude(x => x.User)
                        .Include(x => x.CarModel)
                            .ThenInclude(x => x.Brand)
                        .Include(x => x.CarModel)
                            .ThenInclude(x => x.ModelVersion)
                        .Include(x => x.CarModel)
                            .ThenInclude(x => x.DriveType)
                        .Include(x => x.Location);

            return await (query != null ? query(_table).ToListAsync() : _table.ToListAsync());
        }
        public sealed override async Task<CarAvailabilityIssue?> GetOneAsync(int id)
        {
            var issue = await _context.CarAvailabilityIssue
                             .Include(x => x.Reservation)
                                .ThenInclude(x => x.User)
                            .Include(x => x.CarModel)
                                .ThenInclude(x => x.Brand)
                            .Include(x => x.CarModel)
                                .ThenInclude(x => x.ModelVersion)
                            .Include(x => x.CarModel)
                                .ThenInclude(x => x.DriveType)
                            .Include(x => x.Location)
                            .FirstOrDefaultAsync(x => x.Id == id);

            return issue;
        }
    }
}
