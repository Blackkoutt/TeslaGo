namespace TeslaGoAPI.Logic.Repositories.Interfaces.Abstract
{
    public interface IGenericRepository<TEntity> : IRepository
    {
        Task<TEntity?> GetOneAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? query = null);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Detach(TEntity entity);
    }
}
