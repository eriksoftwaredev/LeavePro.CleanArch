using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeavePro.CleanArch.Application.Contracts.Persistence;

public interface IRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAllAsync();
    Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> GetByIdAsync(int id);
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);
}