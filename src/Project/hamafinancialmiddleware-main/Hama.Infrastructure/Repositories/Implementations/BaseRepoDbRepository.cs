using Hama.Infrastructure.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using RepoDb;
using System.Linq.Expressions;


namespace Hama.Infrastructure.Repositories.Implementations
{
    public class BaseRepoDbRepository<T> : IBaseRepoDbRepository<T> where T : class

    {
        private readonly string _connectionString;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(180); // زمان انقضای کش
        private SqlConnection _sharedConnection;
        private SqlTransaction _sharedTransaction;


        public BaseRepoDbRepository(IConnectionStringProvider connectionStringProvider, IMemoryCache cache)
        {
            _connectionString = connectionStringProvider.GetConnectionString();
            _cache = cache;
        }


        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        // *************************************** Get ************************************************************
        /// <summary>
        /// بازیابی لیست داده‌ها از دیتابیس بر اساس فیلتر، مرتب‌سازی، صفحه‌بندی و امکان استفاده از کش.
        /// مناسب برای داده‌هایی که نیاز به فیلتر یا صفحه‌بندی دارند.
        /// <para>
        /// <b>مثال استفاده:</b><br/>
        /// <code>
        /// var products = await repository.Get(
        ///     filter: x => x.Price &gt; 1000,
        ///     orderBy: x => x.Id,
        ///     ascending: true,
        ///     page: 2,
        ///     pageSize: 100,
        ///     useCache: true);
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="filter">فیلتر انتخاب داده‌ها (اختیاری).</param>
        /// <param name="page">شماره صفحه (اختیاری).</param>
        /// <param name="pageSize">تعداد رکورد در هر صفحه (اختیاری).</param>
        /// <param name="orderBy">ستون مرتب‌سازی (اختیاری).</param>
        /// <param name="ascending">مرتب‌سازی صعودی/نزولی (پیش‌فرض true).</param>
        /// <param name="useCache">فعال کردن استفاده از کش (پیش‌فرض false).</param>
        /// <returns>لیست داده‌ها.</returns>
        public async Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            int? page = null,
            int? pageSize = null,
            Expression<Func<T, object>> orderBy = null,
            bool ascending = true,
            bool useCache = false)
        {
            string cacheKey = $"Get-{typeof(T).Name}-{filter}-{page}-{pageSize}-{orderBy}-{ascending}";

            if (useCache && _cache.TryGetValue(cacheKey, out IEnumerable<T> cachedData))
                return cachedData;

            return await UseConnectionAsync(async (connection, transaction) =>
            {
                // گرفتن دیتا از دیتابیس
                var query = filter == null
                    ? await connection.QueryAllAsync<T>(transaction: transaction)
                    : await connection.QueryAsync(filter, transaction: transaction);

                // چون query یک IEnumerable است باید بیاریم داخل حافظه بعد OrderBy بزنیم
                var result = query.AsQueryable();  // اینجا میشه IQueryable

                // ترتیب
                if (orderBy != null)
                    result = ascending ? result.OrderBy(orderBy) : result.OrderByDescending(orderBy);

                // صفحه بندی
                if (page.HasValue && pageSize.HasValue)
                    result = result.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);

                var finalResult = result.ToList();  // ToList معمولی نه async

                if (useCache)
                    _cache.Set(cacheKey, finalResult, _cacheExpiration);

                return finalResult;
            });
        }


        public async Task<IEnumerable<TDto>> GetQueryAsync<TDto>(string sql, object parameters = null) where TDto : class, new()
        {
            return await UseConnectionAsync(async (conn, tran) =>
            {
                return await conn.ExecuteQueryAsync<TDto>(sql, parameters, transaction: tran);
            });
        }
        /// <summary>
        /// بازیابی یک موجودیت بر اساس شناسه (ID) از دیتابیس با امکان استفاده از کش.
        /// <para>
        /// <b>مثال استفاده:</b><br/>
        /// <code>
        /// var product = await repository.GetById(123, useCache: true);
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="id">شناسه موجودیت مورد نظر.</param>
        /// <param name="useCache">فعال کردن استفاده از کش (پیش‌فرض false).</param>
        /// <returns>موجودیت مورد نظر یا null.</returns>
        public async Task<T?> GetByIdAsync(int id, bool useCache = false)
        {
            string cacheKey = $"GetById-{typeof(T).Name}-{id}";

            if (useCache && _cache.TryGetValue(cacheKey, out T cachedItem))
                return cachedItem;

            var result = await UseConnectionAsync(async (conn, tran) =>
            {
                var rows = await conn.QueryAsync<T>(new { Id = id }, transaction: tran);
                return rows.FirstOrDefault();
            });

            if (useCache && result != null)
                _cache.Set(cacheKey, result, _cacheExpiration);

            return result;

        }

        // *************************************** Get Paged Custom **********************************************************
        /// <summary>
        /// بازیابی داده‌ها به صورت صفحه‌بندی شده و قابل سفارشی‌سازی بر اساس فیلتر، مرتب‌سازی و کش از دیتابیس.
        /// این متد برای دریافت داده‌ها در سناریوهایی که نیاز به صفحه‌بندی و بازدهی بالا دارند بهینه شده است.
        /// <para>
        /// <b>مثال استفاده معمولی:</b><br/>
        /// <code>
        /// var result = await repository.GetPagedCustomAsync&lt;ProductDto&gt;(
        ///     filter: x => x.Price &gt; 5000,
        ///     orderBy: x => x.CreatedDate,
        ///     ascending: false,
        ///     page: 1,
        ///     pageSize: 50,
        ///     useCache: true);
        /// </code>
        /// </para>
        /// <para>
        /// <b>مثال استفاده با پارامترهای اضافی (extraParameters):</b><br/>
        /// <code>
        /// var result = await repository.GetPagedCustomAsync&lt;ProductDto&gt;(
        ///     filter: null,
        ///     orderBy: x => x.CreatedDate,
        ///     ascending: false,
        ///     page: 1,
        ///     pageSize: 50,
        ///     extraParameters: new { MinPrice = 5000, StartDate = new DateTime(2024, 1, 1) },
        ///     useCache: true);
        /// </code>
        /// <br/>
        /// در این حالت متد باید از این پارامترها در کوئری SQL خود استفاده کند.
        /// </para>
        /// <para>
        /// <b>مثال استفاده با خروجی Anonymous Type:</b><br/>
        /// <code>
        /// var tempResult = await repository.GetPagedCustomAsync&lt;Product&gt;(
        ///     filter: x => x.Price &gt; 5000,
        ///     orderBy: x => x.CreatedDate,
        ///     ascending: false,
        ///     page: 1,
        ///     pageSize: 50,
        ///     useCache: true);
        ///
        /// var anonymousResult = tempResult.Select(x => new {
        ///     x.Id,
        ///     x.Name,
        ///     PriceWithTax = x.Price * 1.09
        /// }).ToList();
        /// </code>
        /// </para>
        /// </summary>
        /// <typeparam name="TOutput">نوع مدل خروجی که داده‌ها به آن نگاشت (Map) می‌شوند.</typeparam>
        /// <param name="filter">شرط فیلترینگ داده‌ها در قالب Expression (اختیاری).</param>
        /// <param name="orderBy">ستون مورد نظر برای مرتب‌سازی خروجی (اختیاری، پیش‌فرض: کلید اصلی موجودیت).</param>
        /// <param name="ascending">جهت مرتب‌سازی: صعودی (true) یا نزولی (false)، پیش‌فرض true است.</param>
        /// <param name="page">شماره صفحه‌ای که می‌خواهید داده‌ها از آن شروع شود (پیش‌فرض 1).</param>
        /// <param name="pageSize">تعداد رکوردهایی که در هر صفحه نمایش داده می‌شوند (پیش‌فرض 1000).</param>
        /// <param name="extraParameters">پارامترهای اضافی که برای اجرای کوئری لازم باشد (اختیاری)، مانند مقادیر تاریخ، عدد یا هر مقداری که به صورت Expression به‌سادگی قابل استفاده نباشد.</param>
        /// <param name="useCache">فعال کردن کش برای این کوئری به‌منظور افزایش کارایی در دسترسی‌های بعدی (پیش‌فرض false).</param>
        /// <returns>لیستی از داده‌ها در قالب نوع مشخص‌شده که به صورت صفحه‌بندی‌شده از دیتابیس واکشی شده است.</returns>
        public async Task<IEnumerable<TOutput>> GetPagedCustomAsync<TOutput>(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> orderBy = null, bool ascending = true, int page = 1, int pageSize = 1000, object extraParameters = null, bool useCache = false)
            where TOutput : class, new()
        {
            string cacheKey = $"GetPagedCustom-{typeof(T).Name}-{filter}-{page}-{pageSize}-{orderBy}-{ascending}-{extraParameters}";

            if (useCache && _cache.TryGetValue(cacheKey, out IEnumerable<TOutput> cachedResult))
                return cachedResult;

            var connection = await GetCurrentConnectionAsync();
            var transaction = GetCurrentTransaction();

            var whereClause = filter != null ? $"WHERE {CreateWhereClause(filter)}" : "";

            string orderByColumn = orderBy != null
                ? GetPropertyName(orderBy)
                : GetEntityKeyColumn();

            int offset = (page - 1) * pageSize;

            var sqlQuery = $@"
                            SELECT *
                            FROM [{typeof(T).Name}] WITH(NOLOCK)
                            {whereClause}
                            ORDER BY [{orderByColumn}] {(ascending ? "ASC" : "DESC")}
                            OFFSET {offset} ROWS FETCH NEXT {pageSize} ROWS ONLY";

            var rows = await connection.ExecuteQueryAsync(sqlQuery, extraParameters, transaction: transaction);

            var result = rows.Select(row => MapRowToObject<TOutput>((IDictionary<string, object>)row)).ToList();

            if (useCache)
                _cache.Set(cacheKey, result, _cacheExpiration);

            return result;
        }

        // *************************************** Execute Stored Procedure **************************************************
        /// <summary>
        /// اجرای Stored Procedure از دیتابیس و بازگرداندن نتایج آن به صورت لیستی از نوع مشخص.
        /// <para>
        /// <b>مثال استفاده معمولی:</b><br/>
        /// <code>
        /// var result = await repository.ExecuteStoredProcedureAsync&lt;ProductDto&gt;(
        ///     "GetProductsByPrice",
        ///     new { MinPrice = 5000 });
        /// </code>
        /// </para>
        /// <para>
        /// <b>مثال استفاده با Anonymous Type:</b><br/>
        /// <code>
        /// var tempResult = await repository.ExecuteStoredProcedureAsync&lt;ProductDto&gt;(
        ///     "GetProductsByPrice",
        ///     new { MinPrice = 5000 });
        ///
        /// var anonymousResult = tempResult.Select(x => new {
        ///     x.Id,
        ///     x.Name,
        ///     TaxedPrice = x.Price * 1.09
        /// }).ToList();
        /// </code>
        /// </para>
        /// </summary>
        /// <typeparam name="TOutput">نوع مدل خروجی که داده‌ها به آن نگاشت (Map) می‌شوند.</typeparam>
        /// <param name="storedProcedureName">نام Stored Procedure موجود در دیتابیس.</param>
        /// <param name="parameters">پارامترهای موردنیاز برای اجرای Stored Procedure (اختیاری).</param>
        /// <param name="useCache">فعال کردن کش برای این درخواست (پیش‌فرض false).</param>
        /// <returns>لیستی از داده‌های خروجی Stored Procedure در قالب نوع مشخص‌شده.</returns>
        public async Task<IEnumerable<TOutput>> ExecuteStoredProcedureAsync<TOutput>(string storedProcedureName, object parameters = null, bool useCache = false)
           where TOutput : class, new()
        {
            string cacheKey = $"SP-{storedProcedureName}-{typeof(TOutput).Name}-{parameters}";

            if (useCache && _cache.TryGetValue(cacheKey, out IEnumerable<TOutput> cachedResult))
                return cachedResult;

            var result = await UseConnectionAsync(async (connection, transaction) =>
            {
                var rows = await connection.ExecuteQueryAsync(
                    storedProcedureName,
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure,
                    transaction: transaction);

                return rows.Select(row => MapRowToObject<TOutput>((IDictionary<string, object>)row)).ToList();
            });

            if (useCache)
                _cache.Set(cacheKey, result, _cacheExpiration);

            return result;
        }

        // *************************************** Insert **********************************************************
        /// <summary>
        /// درج یک موجودیت جدید در دیتابیس.
        /// <para>
        /// <b>مثال استفاده:</b><br/>
        /// <code>
        /// await repository.Insert(new Product { Name = "Mobile", Price = 5000 });
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="entity">موجودیت مورد نظر برای درج.</param>
        public async Task InsertAsync(T entity)
        {
            await UseConnectionAsync(async (conn, tran) =>
            {
                await conn.InsertAsync(entity, transaction: tran);
                return true;
            });
        }
        /// <summary>
        /// درج دسته‌ای از موجودیت‌ها به صورت یکجا (Bulk Insert) برای عملکرد بهتر در حجم داده زیاد.
        /// <para>
        /// <b>مثال استفاده:</b><br/>
        /// <code>
        /// await repository.InsertBulk(productsList);
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="entities">لیست موجودیت‌ها برای درج.</param>
        public async Task InsertBulkAsync(IEnumerable<T> entities)
        {
            await UseConnectionAsync(async (conn, tran) =>
            {
                await conn.BulkInsertAsync(entities, transaction: tran);
                return true;
            });
        }


        // *************************************** Update **********************************************************
        /// <summary>
        /// به‌روزرسانی یک موجودیت موجود در دیتابیس.
        /// <para>
        /// <b>مثال استفاده:</b><br/>
        /// <code>
        /// product.Price = 4500;
        /// await repository.Update(product);
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="entity">موجودیت مورد نظر برای به‌روزرسانی.</param>
        public async Task UpdateAsync(T entity)
        {
            await UseConnectionAsync(async (conn, tran) =>
            {
                RemoveCache(GetEntityId(entity));
                await conn.UpdateAsync(entity, transaction: tran);
                return true;
            });
        }

        /// <summary>
        /// به‌روزرسانی دسته‌ای از موجودیت‌ها به صورت یکجا (Bulk Update) برای عملکرد بهتر.
        /// <para>
        /// <b>مثال استفاده:</b><br/>
        /// <code>
        /// await repository.UpdateBulk(productsList, qualifiers: x => x.Id);
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="entities">لیست موجودیت‌ها برای به‌روزرسانی.</param>
        /// <param name="qualifiers">مشخص‌کننده فیلد کلیدی برای آپدیت.</param>
        public async Task UpdateBulkAsync(IEnumerable<T> entities, Expression<Func<T, object>> qualifiers)
        {

            if (entities == null || !entities.Any()) return;

            var connection = await GetCurrentConnectionAsync();
            var transaction = GetCurrentTransaction();

            var ids = entities.Select(GetEntityId).ToList();
            await RemoveCache(ids);

            await connection.BulkUpdateAsync(entities, qualifiers: qualifiers, transaction: transaction);

        }

        // *************************************** Delete **********************************************************
        /// <summary>
        /// حذف یک موجودیت بر اساس شناسه از دیتابیس.
        /// <para>
        /// <b>مثال استفاده:</b><br/>
        /// <code>
        /// await repository.Delete(123);
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="id">شناسه موجودیت برای حذف.</param>
        public async Task DeleteAsync(int id)
        {
            await UseConnectionAsync(async (conn, tran) =>
            {
                RemoveCache(id);
                await conn.DeleteAsync<T>(new { Id = id }, transaction: tran);
                return true;
            });
        }

        /// <summary>
        /// حذف دسته‌ای از موجودیت‌ها بر اساس لیست شناسه‌ها.
        /// <para>
        /// <b>مثال استفاده:</b><br/>
        /// <code>
        /// await repository.DeleteBulk(new List&lt;int&gt;{1,2,3,4});
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="ids">لیست شناسه‌های موجودیت‌ها برای حذف.</param>
        public async Task DeleteBulkAsync(IEnumerable<T> entities)
        {
            var connection = await GetCurrentConnectionAsync();
            var transaction = GetCurrentTransaction();

            var ids = entities.Select(GetEntityId).ToList();
            await RemoveCache(ids);

            await connection.BulkDeleteAsync(entities, transaction: transaction);
        }
        /// <summary>
        /// حذف دسته‌ای از موجودیت‌ها بر اساس لیست شناسه‌ها.
        /// <para>
        /// <b>مثال استفاده:</b><br/>
        /// <code>
        /// await repository.DeleteBulk(new List&lt;int&gt;{1,2,3,4});
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="ids">لیست شناسه‌های موجودیت‌ها برای حذف.</param>
        public async Task DeleteBulkAsync(IEnumerable<int> ids)
        {
            var connection = await GetCurrentConnectionAsync();
            var transaction = GetCurrentTransaction();

            var sql = $"DELETE FROM [{typeof(T).Name}] WHERE Id IN @Ids";
            await RemoveCache(ids);
            await connection.ExecuteNonQueryAsync(sql, new { Ids = ids.ToArray() }, transaction: transaction);
        }
        public async Task DeleteBulk(IEnumerable<T> entities, Expression<Func<T, object>> qualifiers)
        {
            var connection = await GetCurrentConnectionAsync();
            var transaction = GetCurrentTransaction();

            var ids = entities.Select(GetEntityId).ToList();
            await RemoveCache(ids);

            await connection.BulkDeleteAsync(entities, qualifiers: qualifiers, transaction: transaction);

        }

        // *************************************** Upsert (Merge) **************************************************
        /// <summary>
        /// درج یا به‌روزرسانی دسته‌ای از موجودیت‌ها در دیتابیس (Bulk Merge).
        /// در صورت وجود داشتن، آپدیت می‌کند و در غیر این صورت درج می‌کند.
        /// <para>
        /// <b>مثال استفاده:</b><br/>
        /// <code>
        /// await repository.MergeBulk(productsList, qualifiers: x => x.Id);
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="entities">لیست موجودیت‌ها.</param>
        /// <param name="qualifiers">مشخص‌کننده فیلد کلیدی برای تشخیص وجود داده.</param>
        public async Task MergeBulkAsync(IEnumerable<T> entities, Expression<Func<T, object>> qualifiers)
        {
            var connection = await GetCurrentConnectionAsync();
            var transaction = GetCurrentTransaction();

            var ids = entities.Select(GetEntityId).ToList();
            await RemoveCache(ids);

            await connection.BulkMergeAsync(entities, qualifiers: qualifiers, transaction: transaction);
        }

        // *************************************** Additional Helpers **********************************************
        /// <summary>
        /// بررسی وجود حداقل یک رکورد مطابق با شرط.
        /// <para>
        /// <b>مثال استفاده:</b><br/>
        /// <code>
        /// bool exists = await repository.Any(x => x.Price &gt; 10000);
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="filter">شرط بررسی وجود.</param>
        /// <returns>true در صورت وجود حداقل یک رکورد، در غیر این صورت false.</returns>

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
        {
            return await UseConnectionAsync(async (conn, tran) =>
            {
                return await conn.ExistsAsync(filter, transaction: tran);
            });
        }
        /// <summary>
        /// بررسی وجود حداقل یک رکورد مطابق با شرط به حجم داده زیاد.
        /// <para>
        /// <b>مثال استفاده:</b><br/>
        /// <code>
        /// await repo.ExistRaw("UserId = @UserId AND RoleId = @RoleId", new { UserId = 1, RoleId = 2 });
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="filter">شرط بررسی وجود.</param>
        /// <returns>true در صورت وجود حداقل یک رکورد، در غیر این صورت false.</returns>
        public async Task<bool> ExistRaw(string whereClause, object parameters)
        {
            return await UseConnectionAsync(async (conn, tran) =>
            {
                var sql = $"SELECT TOP 1 1 FROM [{typeof(T).Name}] WHERE {whereClause}";
                var result = await conn.ExecuteScalarAsync<int?>(sql, parameters, transaction: tran);
                return result.HasValue;
            });
        }


        /// <summary>
        /// شمارش تعداد رکوردهای موجود بر اساس یک شرط مشخص.
        /// <para>
        /// <b>مثال استفاده:</b><br/>
        /// <code>
        /// long count = await repository.Count(x => x.Price &gt; 5000);
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="filter">شرط شمارش (اختیاری).</param>
        /// <returns>تعداد رکوردهای موجود مطابق شرط.</returns>
        public async Task<long> CountAsync(Expression<Func<T, bool>> filter = null)
        {
            return await UseConnectionAsync(async (conn, tran) =>
            {
                if (filter != null)
                    return await conn.CountAsync(where: filter, transaction: tran);
                else
                    return await conn.CountAsync<T>((object)null, transaction: tran);
            });
        }

        /// <summary>
        /// اجرای مجموعه‌ای از عملیات در قالب یک تراکنش واحد. تمام عملیات باید از connection و transaction ارائه‌شده استفاده کنند.
        /// <para>
        /// <b>مثال استفاده:</b><br/>
        /// <code>
        /// await repository.ExecuteInTransaction(async (conn, tran) =&gt;
        /// {
        ///     await conn.InsertAsync(product1, transaction: tran);
        ///     await conn.UpdateAsync(product2, transaction: tran);
        /// });
        /// </code>
        /// </para>
        /// </summary>
        /// <param name="operations">عملیاتی که باید در قالب تراکنش انجام شوند. connection و transaction به آن ارسال می‌شود.</param>
        public async Task ExecuteInTransactionAsync(Func<Task> operations)
        {
            _sharedConnection = GetConnection();
            await _sharedConnection.OpenAsync();
            _sharedTransaction = _sharedConnection.BeginTransaction();

            try
            {
                await operations();

                await _sharedTransaction.CommitAsync();
            }
            catch
            {
                await _sharedTransaction.RollbackAsync();
                throw;
            }
            finally
            {
                _sharedTransaction.Dispose();
                _sharedConnection.Dispose();
                _sharedTransaction = null;
                _sharedConnection = null;
            }
        }

        // *************************************** Method Helpers **********************************************
        private string CreateWhereClause(Expression<Func<T, bool>> filter)
        {
            if (filter == null) return "1=1";
            var body = filter.Body.ToString();
            var paramName = filter.Parameters[0].Name + ".";
            return body.Replace(paramName, "").Replace("AndAlso", "AND").Replace("OrElse", "OR");
        }
        private TOutput MapRowToObject<TOutput>(IDictionary<string, object> row) where TOutput : class, new()
        {
            var obj = new TOutput();
            var objType = typeof(TOutput);

            foreach (var prop in objType.GetProperties())
            {
                if (row.TryGetValue(prop.Name, out var value) && value != null && value != DBNull.Value)
                {
                    var targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    prop.SetValue(obj, Convert.ChangeType(value, targetType));
                }
            }

            return obj;
        }
        private string GetEntityKeyColumn()
        {
            var keyProp = typeof(T).GetProperties()
                .FirstOrDefault(p => p.Name.Equals("Id", StringComparison.OrdinalIgnoreCase)
                                     || p.Name.Equals($"{typeof(T).Name}Id", StringComparison.OrdinalIgnoreCase)
                                     || p.Name.EndsWith("Key", StringComparison.OrdinalIgnoreCase));

            if (keyProp == null)
                throw new Exception($"No primary key found for entity {typeof(T).Name}");

            return keyProp.Name;
        }
        private string GetPropertyName(Expression<Func<T, object>> expression)
        {
            if (expression.Body is MemberExpression member)
                return member.Member.Name;

            if (expression.Body is UnaryExpression unary && unary.Operand is MemberExpression unaryMember)
                return unaryMember.Member.Name;

            throw new ArgumentException("Invalid expression provided for property selector.");
        }
        private async Task<SqlConnection> GetCurrentConnectionAsync()
        {
            if (_sharedConnection != null)
                return _sharedConnection;

            var connection = GetConnection();
            await connection.OpenAsync();
            return connection;
        }
        private SqlTransaction GetCurrentTransaction()
        {
            return _sharedTransaction;
        }
        private async Task<TResult> UseConnectionAsync<TResult>(Func<SqlConnection, SqlTransaction, Task<TResult>> action)
        {
            var isShared = _sharedConnection != null;
            var connection = await GetCurrentConnectionAsync();
            var transaction = GetCurrentTransaction();

            try
            {
                return await action(connection, transaction);
            }
            finally
            {
                if (!isShared)
                    connection.Dispose();
            }
        }



        // *************************************** Cache Methods **************************************************
        private async Task RemoveCache(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any()) return;

            // ایجاد یک لیست از وظایف برای انجام حذف کش به‌صورت همزمان
            var tasks = ids.Select(id => Task.Run(() =>
            {
                _cache.Remove($"GetById-{typeof(T).Name}-{id}");
            })).ToList();

            // انجام همه وظایف به‌صورت همزمان
            await Task.WhenAll(tasks);

            // همچنین کش لیست کلی باید پاک شود
            _cache.Remove($"Get-{typeof(T).Name}");
        }
        private void RemoveCache(int? id = null)
        {
            if (id.HasValue)
            {
                _cache.Remove($"GetById-{typeof(T).Name}-{id.Value}");
            }

            _cache.Remove($"Get-{typeof(T).Name}"); // لیست کلی هم باید پاک شود
        }
        private int GetEntityId(T entity)
        {
            // دریافت تمامی پراپرتی‌های کلاس
            var properties = typeof(T).GetProperties();

            // جستجوی کلید اصلی (فرض می‌کنیم فیلد کلید، دارای نام رایج مثل Id، TId، یا شامل "Key" است)
            var keyProperty = properties.FirstOrDefault(p =>
                p.Name.Equals("Id", StringComparison.OrdinalIgnoreCase) ||
                p.Name.Equals($"{typeof(T).Name}Id", StringComparison.OrdinalIgnoreCase) ||
                p.Name.ToLower().Contains("key")
            );

            // اگر کلید پیدا نشد، خطا برگردان
            if (keyProperty == null)
                throw new Exception($"No primary key found for entity {typeof(T).Name}");

            // مقدار کلید را دریافت و به `int` تبدیل کن
            return Convert.ToInt32(keyProperty.GetValue(entity));
        }
    }
}
