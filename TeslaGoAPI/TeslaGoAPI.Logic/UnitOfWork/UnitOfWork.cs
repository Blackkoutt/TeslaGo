using TeslaGoAPI.DB.Context;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Repositories.Interfaces.Abstract;
using TeslaGoAPI.Logic.Repositories.Repositories;
using TeslaGoAPI.Logic.Exceptions;

namespace TeslaGoAPI.Logic.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly APIContext _context;
        private readonly Dictionary<Type, IRepository> _repositories;

        public UnitOfWork(APIContext context)
        {
            _context = context;
            _repositories = InitRepositoriesDictionary();
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.TryGetValue(typeof(TEntity), out var repository))
            {
                return (IGenericRepository<TEntity>)repository;
            }
            throw new RepositoryNotExistException($"No existing repository for entity type {typeof(TEntity)}.");
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public APIContext Context { get { return _context; } }

        private Dictionary<Type, IRepository> InitRepositoriesDictionary()
        {
            return new Dictionary<Type, IRepository>
            {
                { typeof(Address), new AddressRepository(_context) },
                { typeof(BodyType), new BodyTypeRepository(_context) },
                { typeof(Brand), new BrandRepository(_context)},
                { typeof(Car), new CarRepository(_context) },
                { typeof(CarModel), new CarModelRepository(_context) },
                { typeof(City), new CityRepository(_context) },
                { typeof(Country), new CountryRepository(_context) },
                { typeof(DB.Entities.DriveType), new DriveTypeRepository(_context) },
                { typeof(Equipment), new EquipmentRepository(_context) },
                { typeof(FuelType), new FuelTypeRepository(_context) },
                { typeof(GearBox), new GearBoxRepository(_context) },
                { typeof(Location), new LocationRepository(_context) },
                { typeof(ModelVersion), new ModelVersionRepository(_context) },
                { typeof(OptService), new OptServiceRepository(_context) },
                { typeof(Paint), new PaintRepository(_context) },
                { typeof(PaymentMethod), new PaymentMetodRepository(_context) },
                { typeof(Reservation), new ReservationRepository(_context) },
                { typeof(User), new UserRepository(_context) },
                { typeof(CarAvailabilityIssue), new CarAvailabilityIssueRepository(_context) },
            };
        }
    }
}
