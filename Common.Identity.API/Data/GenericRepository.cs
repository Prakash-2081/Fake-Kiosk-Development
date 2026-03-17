using Commmon.Data.Data.Contracts;
using Common.Identity.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Commmon.Data.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IdentityDataContext _db;
        internal DbSet<T> _dbSet;
        public GenericRepository(IdentityDataContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _dbSet = _db.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public T UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            _db.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult(_dbSet);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var result=await _dbSet.FindAsync(id);
            if (result == null)
            {
                throw new Exception($"Id {id} not found");
            }
            return result;
        }

        
    }
}
