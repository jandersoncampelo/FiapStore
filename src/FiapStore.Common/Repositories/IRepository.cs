using FiapStore.Common.Entities;

namespace FiapStore.Common.Repositories;

public interface IRepository<T> where T : Entity
{
    Task<T> GetByIdAsync(long id);
    Task<IQueryable<T>> ListAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
