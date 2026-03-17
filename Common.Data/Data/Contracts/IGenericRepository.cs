namespace Commmon.Data.Data.Contracts
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        T UpdateAsync(T entity);
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
    }
}
