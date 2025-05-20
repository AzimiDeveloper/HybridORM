using Hama.Share.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hama.Service.Interfaces.ORM
{
    public interface IBaseRepoDbService<T> where T : class, new()
    {
        Task<ServiceResult<List<TDto>>> RepoGetQueryAsync<TDto>(string sql, object parameters = null) where TDto : class, new();
        Task<ServiceResult<T?>> RepoGetByIdAsync(int id);
        Task<ServiceResult<bool>> RepoInsertAsync(T entity);
        Task<ServiceResult<bool>> RepoInsertBulkAsync(IEnumerable<T> entities);
        Task<ServiceResult<bool>> RepoUpdateAsync(T entity);
        Task<ServiceResult<bool>> RepoUpdateBulkAsync(IEnumerable<T> entities, Expression<Func<T, object>> qualifiers);
        Task<ServiceResult<bool>> RepoDeleteAsync(int id);
        Task<ServiceResult<bool>> RepoDeleteBulkAsync(IEnumerable<T> entities);
        Task<ServiceResult<bool>> RepoDeleteBulkAsync(IEnumerable<int> ids);
        Task<ServiceResult<bool>> RepoMergeBulkAsync(IEnumerable<T> entities, Expression<Func<T, object>> qualifiers);
        Task<ServiceResult<bool>> RepoAnyAsync(Expression<Func<T, bool>> filter);
        Task<ServiceResult<long>> RepoCountAsync();
        Task<ServiceResult<bool>> RepoExecuteInTransactionAsync(Func<Task> operations);
        Task<ServiceResult<List<TOutput>>> RepoGetPagedCustomAsync<TOutput>(
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> orderBy = null,
            bool ascending = true,
            int page = 1,
            int pageSize = 1000,
            object extraParameters = null,
            bool useCache = false)
            where TOutput : class, new();

        Task<ServiceResult<List<TOutput>>> RepoExecuteStoredProcedureAsync<TOutput>(string spName, object parameters = null, bool useCache = false)
            where TOutput : class, new();
    }
}
