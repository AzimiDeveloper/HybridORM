using System;
using System.IO;
using System.Text.RegularExpressions;
using Humanizer; // اضافه کردن Humanizer

string modelsPath = Path.GetFullPath(@"..\..\..\..\Hama.Core\Models");

foreach (var file in Directory.GetFiles(modelsPath, "*.cs", SearchOption.AllDirectories))
{
    if (!file.Contains("Context"))
    {
        string text = File.ReadAllText(file);

        // پیدا کردن تعریف کلاس
        var match = Regex.Match(text, @"public partial class (\w+)", RegexOptions.Multiline);
        if (match.Success)
        {
            string className = match.Groups[1].Value;
            string tableName = className.Pluralize(); // 👈 جمع سازی درست

            if (!text.Contains("[Table("))
            {
                string attributes = $"[System.ComponentModel.DataAnnotations.Schema.Table(\"{tableName}\")]\n[RepoDb.Attributes.Map(\"{tableName}\")]\n";
                text = text.Replace(match.Value, attributes + match.Value);
                File.WriteAllText(file, text);
                Console.WriteLine($"✅ Updated: {Path.GetFileName(file)} with Table(\"{tableName}\")");
            }
            else
            {
                Console.WriteLine($"⏩ Already has [Table]: {Path.GetFileName(file)}");
            }
        }
    }
}

Console.WriteLine("\n🎯 All classes updated correctly with Pluralized Table and Map attributes!");
