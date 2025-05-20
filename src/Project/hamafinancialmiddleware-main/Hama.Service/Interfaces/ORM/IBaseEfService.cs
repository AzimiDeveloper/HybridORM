using Hama.Share.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hama.Service.Interfaces.ORM
{
    public interface IBaseServiceEf<T> where T : class, new()
    {
        Task<ServiceResult<List<T>>> EfGetAsync(
            Expression<Func<T, bool>> filter = null,
            string includes = "",
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = true);

        Task<ServiceResult<IQueryable<T>>> EfGetQueryable(
            Expression<Func<T, bool>> filter = null,
            string includes = "",
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = true);

        Task<ServiceResult<T>> EfGetByIdAsync(object id);
        Task<ServiceResult<bool>> EfInsertAsync(T entity);
        Task<ServiceResult<bool>> EfInsertBulkAsync(IEnumerable<T> entities);
        Task<ServiceResult<bool>> EfUpdateAsync(T entity);
        Task<ServiceResult<bool>> EfUpdateBulkAsync(IEnumerable<T> entities);
        Task<ServiceResult<bool>> EfDeleteAsync(T entity);
        Task<ServiceResult<bool>> EfDeleteBulkAsync(IEnumerable<T> entities);
        Task<ServiceResult<bool>> EfAnyAsync(Expression<Func<T, bool>> filter = null);
    }
}
