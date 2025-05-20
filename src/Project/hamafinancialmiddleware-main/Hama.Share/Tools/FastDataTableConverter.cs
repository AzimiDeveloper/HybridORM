using FastMember;
using System.Buffers;
using System.Collections.Concurrent;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace Hama.Share.Tools
{
    public static class FastDataTableConverter
    {
        private static readonly ConcurrentDictionary<Type, Delegate> _cache = new();

        // تبدیل لیست به DataTable
        private static readonly ConcurrentDictionary<Type, TypeAccessor> _typeAccessors = new();
        public static async Task<DataTable> ToDataTableAsync<T>(IEnumerable<T> data, bool addSelectColumn = false)
        {
            return await Task.Run(() =>
            {
                var table = new DataTable();

                var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                                     .OrderBy(p => p.MetadataToken)
                                     .ToArray();

                if (addSelectColumn)
                {
                    var selectCol = new DataColumn("IsSelected", typeof(bool))
                    {
                        DefaultValue = false
                    };
                    table.Columns.Add(selectCol);
                }

                foreach (var prop in props)
                {
                    var columnType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    table.Columns.Add(prop.Name, columnType);
                }

                using (var reader = ObjectReader.Create(data, props.Select(p => p.Name).ToArray()))
                {
                    table.Load(reader);
                }

                return table;
            });
        }





        // تبدیل DataTable به لیست
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            var mapper = (Func<DataRow, T>)_cache.GetOrAdd(typeof(T), _ => CreateMapper<T>(table));
            var list = new List<T>(table.Rows.Count);

            foreach (DataRow row in table.Rows)
                list.Add(mapper(row));

            return list;
        }


        private static Func<DataRow, T> CreateMapper<T>(DataTable table) where T : new()
        {
            var rowParam = Expression.Parameter(typeof(DataRow), "row");
            var bindings = new List<MemberBinding>();

            foreach (DataColumn column in table.Columns)
            {
                var prop = typeof(T).GetProperty(column.ColumnName, BindingFlags.Public | BindingFlags.Instance);
                if (prop == null || !prop.CanWrite)
                    continue;

                var valueExp = Expression.Property(rowParam, "Item", Expression.Constant(column.ColumnName));

                var safeValueExp = Expression.Condition(
                    Expression.Equal(valueExp, Expression.Constant(DBNull.Value)),
                    Expression.Default(prop.PropertyType),
                    Expression.Convert(valueExp, prop.PropertyType)
                );

                bindings.Add(Expression.Bind(prop, safeValueExp));
            }

            var body = Expression.MemberInit(Expression.New(typeof(T)), bindings);
            var lambda = Expression.Lambda<Func<DataRow, T>>(body, rowParam);

            return lambda.Compile();
        }
    }
}
