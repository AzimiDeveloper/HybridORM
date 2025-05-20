using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

public static class ExpressionHelper
{
    private static readonly Regex PlaceholderPattern = new(@"\[(Normal|Sum|Count)\(([\w]+)\)\s*(\*|\+|\-|\/)?\s*([\d\.]*)?\]", RegexOptions.IgnoreCase);

    public static string ProcessField(string template, DataRow currentRow, List<DataRow> allRows)
    {
        if (string.IsNullOrWhiteSpace(template)) return template;

        return PlaceholderPattern.Replace(template, match =>
        {
            string type = match.Groups[1].Value;   // Normal, Sum, Count
            string field = match.Groups[2].Value;  // نام ستون
            string op = match.Groups[3].Value;     // + - * /
            string val = match.Groups[4].Value;    // مقدار ثابت

            if (type.Equals("Normal", StringComparison.OrdinalIgnoreCase))
            {
                if (!currentRow.Table.Columns.Contains(field))
                    return "";

                var rawValue = currentRow[field];

                // اگر عملیات ریاضی وجود ندارد، مقدار رشته‌ای را مستقیماً برگردان
                if (string.IsNullOrWhiteSpace(op))
                    return rawValue?.ToString() ?? "";

                // اگر مقدار قابل تبدیل به عدد نبود، مقدار رشته‌ای بدون تغییر را برگردان
                if (!decimal.TryParse(rawValue?.ToString(), out var baseVal))
                    return rawValue?.ToString() ?? "";

                if (!decimal.TryParse(val, NumberStyles.Any, CultureInfo.InvariantCulture, out var operand))
                    operand = 0;

                decimal result = op switch
                {
                    "*" => baseVal * operand,
                    "/" => operand == 0 ? 0 : baseVal / operand,
                    "+" => baseVal + operand,
                    "-" => baseVal - operand,
                    _ => baseVal
                };

                return result.ToString("0.##");
            }

            // پردازش Sum یا Count
            decimal aggregateVal = 0;
            if (type.Equals("Sum", StringComparison.OrdinalIgnoreCase))
            {
                aggregateVal = allRows
                    .Where(r => r.Table.Columns.Contains(field))
                    .Sum(r => decimal.TryParse(r[field]?.ToString(), out var val) ? val : 0);
            }
            else if (type.Equals("Count", StringComparison.OrdinalIgnoreCase))
            {
                aggregateVal = allRows.Count;
            }

            if (string.IsNullOrEmpty(op))
                return aggregateVal.ToString("0.##");

            if (!decimal.TryParse(val, NumberStyles.Any, CultureInfo.InvariantCulture, out var aggregateOperand))
                aggregateOperand = 0;

            decimal aggResult = op switch
            {
                "*" => aggregateVal * aggregateOperand,
                "/" => aggregateOperand == 0 ? 0 : aggregateVal / aggregateOperand,
                "+" => aggregateVal + aggregateOperand,
                "-" => aggregateVal - aggregateOperand,
                _ => aggregateVal
            };

            return aggResult.ToString("0.##");
        });
    }

    public static bool ContainsAggregatePlaceholder(string input)
        => input != null && (input.Contains("[Sum(") || input.Contains("[Count("));

    public static bool ContainsNormalPlaceholder(string input)
        => input != null && input.Contains("[Normal(");
}
