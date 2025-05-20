using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hama.Infrastructure.Repositories.Interfaces
{
    public interface IBaseEfRepository<TEntity> where TEntity : class, new()
    {
        Task<List<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string includes = "",
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = true);

        Task<IQueryable<TEntity>> GetQueryableAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string includes = "",
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = true);

        Task<TEntity> GetByIdAsync(object id);
        Task InsertAsync(TEntity entity);
        Task InsertBulkAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task UpdateBulkAsync(IEnumerable<TEntity> entities);
        Task DeleteAsync(TEntity entity);
        Task DeleteBulkAsync(IEnumerable<TEntity> entities);
        Task<bool> SaveAsync();
        Task CancelAsync();
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null);
    }
}
