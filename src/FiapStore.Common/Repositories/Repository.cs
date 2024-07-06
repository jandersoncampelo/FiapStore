
using FiapStore.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace FiapStore.Common.Repositories;

public class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly DbContext Context;

    public Repository(DbContext context)
    {
        Context = context;
    }
    public async Task<T> AddAsync(T entity)
    {
        Context.Set<T>().Add(entity);
        await Context.SaveChangesAsync();

        return await Context.Set<T>().FindAsync(entity.Id);
    }

    public async Task DeleteAsync(T entity)
    {
        await Task.Run(() => Context.Set<T>().Remove(entity));
        await Context.SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public async Task<IQueryable<T>> ListAsync()
    {
        return await Task.Run(() => Context.Set<T>().AsQueryable());
    }

    public async Task UpdateAsync(T entity)
    {
        await Task.Run(() => Context.Set<T>().Update(entity));
        await Context.SaveChangesAsync();
    }
}
