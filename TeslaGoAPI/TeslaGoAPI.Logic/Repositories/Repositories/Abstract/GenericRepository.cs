using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using TeslaGoAPI.DB.Context;
using TeslaGoAPI.Logic.Repositories.Interfaces.Abstract;

namespace TeslaGoAPI.Logic.Repositories.Repositories.Abstract
{
    public abstract class GenericRepository<TEntity>(APIContext context) : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly APIContext _context = context;
        private readonly DbSet<TEntity> _table = context.Set<TEntity>();

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? query = null)
        {
             return await(query?.Invoke(_table) ?? _table).ToListAsync();
        }
        public virtual async Task<TEntity?> GetOneAsync(int id) => await _table.FindAsync(id);
        public async Task Add(TEntity entity) => await _table.AddAsync(entity);
        public void Delete(TEntity entity) => _table.Remove(entity);
        public void Update(TEntity entity) => _table.Update(entity);
        public void Detach(TEntity entity) => _table.Entry(entity).State = EntityState.Detached;
    }
}
