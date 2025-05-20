using Hama.Infrastructure.Repositories.Interfaces;
using Hama.Service.Interfaces.ORM;
using Hama.Share.Results;
using System.Linq.Expressions;

namespace Hama.Service.ORM
{
    public class BaseEfService<T> : IBaseServiceEf<T> where T : class, new()
    {
        private readonly IBaseEfRepository<T> _repository;

        public BaseEfService(IBaseEfRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<List<T>>> EfGetAsync(
            Expression<Func<T, bool>> filter = null, 
            string includes = "",
            Func<IQueryable<T>, 
            IOrderedQueryable<T>> orderBy = null,
            int? skip = null, 
            int? take = null, 
            bool asNoTracking = true)
        {
            try
            {
                var result = await _repository.GetAsync(filter, includes, orderBy, skip, take, asNoTracking);
                return ServiceResult<List<T>>.Ok(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<List<T>>.Fail(500,"خطا در دریافت EF:", ex.Message);
            }
        }

        public async Task<ServiceResult<IQueryable<T>>> EfGetQueryable(
            Expression<Func<T, bool>> filter = null,
            string includes = "",
            Func<IQueryable<T>, 
            IOrderedQueryable<T>> orderBy = null,
            int? skip = null, 
            int? take = null, 
            bool asNoTracking = true)
        {
            try
            {
                var result = await _repository.GetQueryableAsync(filter, includes, orderBy, skip, take, asNoTracking);
                return ServiceResult<IQueryable<T>>.Ok(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<IQueryable<T>>.Fail(500, "خطا در دریافت Queryable EF:", ex.Message);
            }
        }

        public async Task<ServiceResult<T>> EfGetByIdAsync(object id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                return entity != null
                    ? ServiceResult<T>.Ok(entity)
                    : ServiceResult<T>.Fail(500, "یافت نشد");
            }
            catch (Exception ex)
            {
                return ServiceResult<T>.Fail(500, "خطا در یافتن موجودیت:", ex.Message);
            }
        }
        public async Task<ServiceResult<bool>> EfAnyAsync(Expression<Func<T, bool>> filter = null)
        {
            try
            {
                var result = await _repository.AnyAsync(filter);
                return ServiceResult<bool>.Ok(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500, "خطا در بررسی وجود:", ex.Message);
            }
        }
        public async Task<ServiceResult<bool>> EfInsertAsync(T entity)
        {
            try
            {
                await _repository.InsertAsync(entity);
                var saved = await _repository.SaveAsync();
                return ServiceResult<bool>.Ok(saved, "درج با موفقیت انجام شد", 201);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500, "خطا در درج:", ex.Message);
            }
        }
        public async Task<ServiceResult<bool>> EfInsertBulkAsync(IEnumerable<T> entities)
        {
            try
            {
                await _repository.InsertBulkAsync(entities);
                var saved = await _repository.SaveAsync();
                return ServiceResult<bool>.Ok(saved, "درج دسته‌ای با موفقیت انجام شد", 201);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500, "خطا در درج دسته‌ای:", ex.Message);
            }
        }
        public async Task<ServiceResult<bool>> EfUpdateAsync(T entity)
        {
            try
            {
                await _repository.UpdateAsync(entity);
                return ServiceResult<bool>.Ok(true, "ویرایش با موفقیت انجام شد", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500, "خطا در ویرایش:", ex.Message);
            }
        }
        public async Task<ServiceResult<bool>> EfUpdateBulkAsync(IEnumerable<T> entities)
        {
            try
            {
                await _repository.UpdateBulkAsync(entities);
                return ServiceResult<bool>.Ok(true, "ویرایش دسته‌ای با موفقیت انجام شد", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500, "خطا در ویرایش دسته‌ای:", ex.Message);
            }
        }
        public async Task<ServiceResult<bool>> EfDeleteAsync(T entity)
        {
            try
            {
                await _repository.DeleteAsync(entity);
                return ServiceResult<bool>.Ok(true, "حذف با موفقیت انجام شد", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500, "خطا در حذف:", ex.Message);
            }
        }
        public async Task<ServiceResult<bool>> EfDeleteBulkAsync(IEnumerable<T> entities)
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


    }
}
