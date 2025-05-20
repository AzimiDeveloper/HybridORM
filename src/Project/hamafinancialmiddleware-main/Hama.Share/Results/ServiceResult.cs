using System;
using System.Collections.Generic;
using System.Linq;

namespace Hama.Share.Results
{
    public class ServiceResult<T>
    {
        public bool Success => !Errors.Any();
        public List<string> Errors { get; set; } = new();
        public T? Data { get; set; }
        public string? Message { get; set; }

        /// <summary>
        /// کد وضعیت (مطابق با استاندارد HTTP مانند 200، 400، 404، 500)
        /// </summary>
        public int StatusCode { get; set; } = 200;

        /// <summary>
        /// اطلاعات صفحه‌بندی در صورت نیاز (برای لیست‌ها)
        /// </summary>
        public PaginationMetadata? Pagination { get; set; }

        public static ServiceResult<T> Ok(T data, string? message = null, int statusCode = 200)
        {
            return new ServiceResult<T>
            {
                Data = data,
                Message = message,
                StatusCode = statusCode
            };
        }

        public static ServiceResult<T> Fail(int statusCode = 400 ,params string[] errors)
        {
            return new ServiceResult<T>
            {
                Errors = errors.ToList(),
                StatusCode = statusCode
            };
        }
    }

    /// <summary>
    /// مدل اطلاعات صفحه‌بندی برای خروجی‌های لیستی
    /// </summary>
    public class PaginationMetadata
    {
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => PageSize == 0 ? 0 : (int)Math.Ceiling((double)TotalItems / PageSize);
    }
}
