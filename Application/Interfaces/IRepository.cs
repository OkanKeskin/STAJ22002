using System.Linq.Expressions;

namespace Application.Interfaces;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
    Task<List<T>?> GetByFilterListAsync(Expression<Func<T, bool>> filter);

}