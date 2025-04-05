using TeslaGoAPI.DB.Context;
using TeslaGoAPI.Logic.Repositories.Interfaces.Abstract;

namespace TeslaGoAPI.Logic.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task SaveChangesAsync();
        APIContext Context { get; }
    }
}
