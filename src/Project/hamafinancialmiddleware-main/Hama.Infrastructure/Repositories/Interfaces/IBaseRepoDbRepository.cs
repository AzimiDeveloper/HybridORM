using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hama.Infrastructure.Repositories.Interfaces
{
    public interface IBaseRepoDbRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            int? page = null,
            int? pageSize = null,
            Expression<Func<T, object>> orderBy = null,
            bool ascending = true,
            bool useCache = false);

        Task<IEnumerable<TDto>> GetQueryAsync<TDto>(string sql, object parameters = null) where TDto : class, new();
        Task<T?> GetByIdAsync(int id, bool useCache = false);
        Task<IEnumerable<TOutput>> GetPagedCustomAsync<TOutput>(
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> orderBy = null,
            bool ascending = true,
            int page = 1,
            int pageSize = 1000,
            object extraParameters = null,
            bool useCache = false) where TOutput : class, new();

        Task<IEnumerable<TOutput>> ExecuteStoredProcedureAsync<TOutput>(string storedProcedureName, object parameters = null, bool useCache = false) where TOutput : class, new();
        Task InsertAsync(T entity);
        Task InsertBulkAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateBulkAsync(IEnumerable<T> entities, Expression<Func<T, object>> qualifiers);
        Task DeleteAsync(int id);
        Task DeleteBulkAsync(IEnumerable<T> entities);
        Task DeleteBulkAsync(IEnumerable<int> ids);
        Task DeleteBulk(IEnumerable<T> entities, Expression<Func<T, object>> qualifiers);
        Task MergeBulkAsync(IEnumerable<T> entities, Expression<Func<T, object>> qualifiers);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
        Task<bool> ExistRaw(string whereClause, object parameters);
        Task<long> CountAsync(Expression<Func<T, bool>> filter = null);
        Task ExecuteInTransactionAsync(Func<Task> operations);
    }
}
