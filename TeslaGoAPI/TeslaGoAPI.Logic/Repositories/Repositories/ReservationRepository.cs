using Microsoft.EntityFrameworkCore;
using TeslaGoAPI.DB.Context;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Repositories.Repositories.Abstract;

namespace TeslaGoAPI.Logic.Repositories.Repositories
{
    public sealed class ReservationRepository(APIContext context) : GenericRepository<Reservation>(context)
    {
        public sealed override async Task<IEnumerable<Reservation>> GetAllAsync(Func<IQueryable<Reservation>, IQueryable<Reservation>>? query = null)
        {
            var _table = _context.Reservation
                         .Include(x => x.User)
                         .Include(x => x.CarModel)
                            .ThenInclude(x => x.Brand)
                         .Include(x => x.CarModel)
                            .ThenInclude(x => x.ModelVersion)
                         .Include(x => x.CarModel)
                            .ThenInclude(x => x.DriveType)
                          .Include(x => x.Car)
                         .Include(x => x.PickupLocation)
                         .Include(x => x.ReturnLocation)
                         .Include(x => x.PaymentMethod);

            return await (query != null ? query(_table).ToListAsync() : _table.ToListAsync());
        }
        public sealed override async Task<Reservation?> GetOneAsync(int id)
        {
            return await _context.Reservation
                             .Include(x => x.User)
                             .Include(x => x.CarModel)
                                .ThenInclude(x => x.Brand)
                             .Include(x => x.CarModel)
                                .ThenInclude(x => x.ModelVersion)
                             .Include(x => x.CarModel)
                                .ThenInclude(x => x.DriveType)
                             .Include(x => x.Car)
                             .Include(x => x.PaymentMethod)
                             .Include(x => x.PickupLocation)
                             .Include(x => x.ReturnLocation)
                             .Include(x => x.OptServices)
                             .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
