using Hama.Infrastructure.Repositories.Interfaces;
using Hama.Service.Interfaces.ORM;
using Hama.Share.Results;
using System.Linq.Expressions;

namespace Hama.Service.ORM
{
    public class BaseRepoDbService<T> : IBaseRepoDbService<T> where T : class, new()
    {
        private readonly IBaseRepoDbRepository<T> _repository;

        public BaseRepoDbService(IBaseRepoDbRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<T?>> RepoGetByIdAsync(int id)
        {
            try
            {
                var result = await _repository.GetByIdAsync(id);
                return result != null
                    ? ServiceResult<T?>.Ok(result)
                    : ServiceResult<T?>.Fail(500,"یافت نشد");
            }
            catch (Exception ex)
            {
                return ServiceResult<T?>.Fail(500, "خطا در دریافت:", ex.Message);
            }
        }

        public async Task<ServiceResult<bool>> RepoInsertAsync(T entity)
        {
            try
            {
                await _repository.InsertAsync(entity);
                return ServiceResult<bool>.Ok(true, "درج با موفقیت انجام شد", 200);

            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500, "خطا در درج:", ex.Message);
            }
        }

        public async Task<ServiceResult<bool>> RepoInsertBulkAsync(IEnumerable<T> entities)
        {
            try
            {
                await _repository.InsertBulkAsync(entities);
                return ServiceResult<bool>.Ok(true, "درج گروهی با موفقیت انجام شد", 200);

            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500, "خطا در درج گروهی:", ex.Message);
            }
        }

        public async Task<ServiceResult<bool>> RepoUpdateAsync(T entity)
        {
            try
            {
                await _repository.UpdateAsync(entity);
                return ServiceResult<bool>.Ok(true, "ویرایش  با موفقیت انجام شد", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500, "خطا در ویرایش:", ex.Message);
            }
        }

        public async Task<ServiceResult<bool>> RepoUpdateBulkAsync(IEnumerable<T> entities, Expression<Func<T, object>> qualifiers)
        {
            try
            {
                await _repository.UpdateBulkAsync(entities, qualifiers);
                return ServiceResult<bool>.Ok(true, "ویرایش دسته‌ای با موفقیت انجام شد", 200);

            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500, "خطا در ویرایش دسته‌ای:", ex.Message);
            }
        }

        public async Task<ServiceResult<bool>> RepoDeleteAsync(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return ServiceResult<bool>.Ok(true, "حذف  با موفقیت انجام شد", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500, "خطا در حذف:", ex.Message);
            }
        }

        public async Task<ServiceResult<bool>> RepoDeleteBulkAsync(IEnumerable<T> entities)
        {
            try
            {
                await _repository.DeleteBulkAsync(entities);
                return ServiceResult<bool>.Ok(true, "حذف دسته‌ای با موفقیت انجام شد", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500, "خطا در حذف دسته‌ای:", ex.Message);
            }
        }

        public async Task<ServiceResult<bool>> RepoDeleteBulkAsync(IEnumerable<int> ids)
        {
            try
            {
                await _repository.DeleteBulkAsync(ids);
                return ServiceResult<bool>.Ok(true, "حذف دسته‌ای با موفقیت انجام شد", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500, "خطا در حذف با شناسه‌ها:", ex.Message);
            }
        }

        public async Task<ServiceResult<bool>> RepoMergeBulkAsync(IEnumerable<T> entities, Expression<Func<T, object>> qualifiers)
        {
            try
            {
                await _repository.MergeBulkAsync(entities, qualifiers);
                return ServiceResult<bool>.Ok(true, "ادغام دسته‌ای با موفقیت انجام شد", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500, "خطا در ادغام دسته‌ای:", ex.Message);
            }
        }

        public async Task<ServiceResult<bool>> RepoAnyAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                var exists = await _repository.AnyAsync(filter);
                return ServiceResult<bool>.Ok(exists);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500, "خطا در بررسی وجود:", ex.Message);
            }
        }

        public async Task<ServiceResult<long>> RepoCountAsync()
        {
            try
            {
                var count = await _repository.CountAsync();
                return ServiceResult<long>.Ok(count);
            }
            catch (Exception ex)
            {
                return ServiceResult<long>.Fail(500, "خطا در شمارش:", ex.Message);
            }
        }

        public async Task<ServiceResult<bool>> RepoExecuteInTransactionAsync(Func<Task> operations)
        {
            try
            {
                await _repository.ExecuteInTransactionAsync(operations);
                return ServiceResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500, "خطا در اجرای تراکنش:", ex.Message);
            }
        }

        public async Task<ServiceResult<List<TDto>>> RepoGetQueryAsync<TDto>(string sql, object parameters = null)
            where TDto : class, new()
        {
            try
            {
                var result = await _repository.GetQueryAsync<TDto>(sql, parameters);
                return ServiceResult<List<TDto>>.Ok(result.ToList());
            }
            catch (Exception ex)
            {
                return ServiceResult<List<TDto>>.Fail(500, "خطا در اجرای کوئری SQL:", ex.Message);
            }
        }

        public async Task<ServiceResult<List<TOutput>>> RepoGetPagedCustomAsync<TOutput>(
            Expression<Func<T, bool>> filter = null,
            Expression<Func<T, object>> orderBy = null,
            bool ascending = true,
            int page = 1,
            int pageSize = 1000,
            object extraParameters = null,
            bool useCache = false)
            where TOutput : class, new()
        {
            try
            {
                var result = await _repository.GetPagedCustomAsync<TOutput>(
                    filter, orderBy, ascending, page, pageSize, extraParameters, useCache);
                return ServiceResult<List<TOutput>>.Ok(result.ToList());
            }
            catch (Exception ex)
            {
                return ServiceResult<List<TOutput>>.Fail(500, "خطا در دریافت داده صفحه‌بندی‌شده:", ex.Message);
            }
        }

        public async Task<ServiceResult<List<TOutput>>> RepoExecuteStoredProcedureAsync<TOutput>(
            string spName, object parameters = null, bool useCache = false)
            where TOutput : class, new()
        {
            try
            {
                var result = await _repository.ExecuteStoredProcedureAsync<TOutput>(spName, parameters, useCache);
                return ServiceResult<List<TOutput>>.Ok(result.ToList());
            }
            catch (Exception ex)
            {
                return ServiceResult<List<TOutput>>.Fail(500, "خطا در اجرای Stored Procedure:", ex.Message);
            }
        }
    }
}
