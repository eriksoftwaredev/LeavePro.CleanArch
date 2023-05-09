using LeavePro.CleanArch.Application.Contracts.Persistence;
using LeavePro.CleanArch.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using LeavePro.CleanArch.Domain.Common;

namespace LeavePro.CleanArch.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly LmDbContext Context;

    public Repository(LmDbContext context)
    {
        Context = context;
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync()
    {
        return await Context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await Context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
    {
        await Context.AddRangeAsync(entities);
        await Context.SaveChangesAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Context.Update(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(TEntity entity)
    {
        Context.Remove(entity);
        await Context.SaveChangesAsync();
    }
}
