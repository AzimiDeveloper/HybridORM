using Hama.Core.Models;
using Hama.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;

    /// <summary>
    /// ریپازیتوری پایه برای عملیات CRUD با EF Core همراه با کش، اینکلود، صفحه‌بندی و مدیریت تغییرات.
    /// </summary>
    /// <typeparam name="TEntity">نوع موجودیت (Entity) که عملیات روی آن انجام می‌شود.</typeparam>
    public class BaseEfRepository<TEntity> : IBaseEfRepository<TEntity>, IAsyncDisposable     where TEntity : class, new()
    {
        private readonly DbContext _context;
        private readonly IMemoryCache _cache;
        private readonly bool _ownContext; // آیا خودم Context رو ساختم؟
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(180);

        public BaseEfRepository(HamaFinancialMiddlewareContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
            _ownContext = false;
        }

        private DbSet<TEntity> Table => _context.Set<TEntity>();

        /// <summary>
        /// دریافت موجودیت‌ها با قابلیت فیلتر، اینکلود، مرتب‌سازی و صفحه‌بندی.
        /// </summary>
        public async Task<List<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string includes = "",
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = true)
        {
            IQueryable<TEntity> query = Table;

            if (!string.IsNullOrWhiteSpace(includes))
            {
                foreach (var include in includes.Split(",", StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(include.Trim());
                }
            }

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        /// <summary>
        /// دریافت Queryable موجودیت‌ها جهت عملیات Lazy Load یا Custom Query.
        /// </summary>
        public async Task<IQueryable<TEntity>> GetQueryableAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string includes = "",
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = true)
        {
            IQueryable<TEntity> query = Table;

            if (!string.IsNullOrWhiteSpace(includes))
            {
                foreach (var include in includes.Split(",", StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(include.Trim());
                }
            }

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (asNoTracking)
                query = query.AsNoTracking();

            return await Task.FromResult(query);
        }

        /// <summary>
        /// دریافت موجودیت بر اساس شناسه.
        /// </summary>
        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await Table.FindAsync(id);
        }

        /// <summary>
        /// اضافه کردن یک موجودیت جدید.
        /// </summary>
        public async Task InsertAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
        }

        /// <summary>
        /// اضافه کردن چندین موجودیت جدید به صورت دسته‌ای.
        /// </summary>
        public async Task InsertBulkAsync(IEnumerable<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        /// <summary>
        /// به‌روزرسانی یک موجودیت موجود.
        /// </summary>
        public async Task UpdateAsync(TEntity entity)
        {
            Table.Update(entity);
            await SaveAsync();
        }

        /// <summary>
        /// به‌روزرسانی دسته‌ای موجودیت‌ها.
        /// </summary>
        public async Task UpdateBulkAsync(IEnumerable<TEntity> entities)
        {
            Table.UpdateRange(entities);
            await SaveAsync();
        }

        /// <summary>
        /// حذف یک موجودیت.
        /// </summary>
        public async Task DeleteAsync(TEntity entity)
        {
            Table.Remove(entity);
            await SaveAsync();
        }

        /// <summary>
        /// حذف چندین موجودیت به صورت دسته‌ای.
        /// </summary>
        public async Task DeleteBulkAsync(IEnumerable<TEntity> entities)
        {
            Table.RemoveRange(entities);
            await SaveAsync();
        }

        /// <summary>
        /// ذخیره تغییرات انجام‌شده در دیتابیس.
        /// </summary>
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// لغو تغییرات انجام شده (بازگرداندن به وضعیت اولیه).
        /// </summary>
        public async Task CancelAsync()
        {
            foreach (var entry in _context.ChangeTracker.Entries<TEntity>())
            {
                if (entry.State == EntityState.Modified)
                    entry.CurrentValues.SetValues(entry.OriginalValues);
            }
            await Task.CompletedTask;
        }

        /// <summary>
        /// آزادسازی منابع.
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            if (_ownContext)
            {
                await _context.DisposeAsync();
            }
        }

        /// <summary>
        /// بررسی وجود موجودیت‌ها با یا بدون شرط.
        /// </summary>
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = Table.AsNoTracking();
            if (filter != null)
                return await query.AnyAsync(filter);
            else
                return await query.AnyAsync();
        }
    }
