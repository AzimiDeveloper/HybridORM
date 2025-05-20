using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Hama.Core.Models
{
public partial class HamaFinancialMiddlewareContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //دریافت کانکشن استرینگ دریافتی از برنامه ویندوز
        //    if (AppContext.GetData("ConnectionString") != null && !string.IsNullOrEmpty(AppContext.GetData("ConnectionString").ToString()))
        //    {
        //        var myConnectionString = AppContext.GetData("ConnectionString").ToString();
        //        optionsBuilder.UseSqlServer(myConnectionString);
        //        optionsBuilder.EnableDetailedErrors();
        //        optionsBuilder.EnableSensitiveDataLogging();
        //    }
        //}
    }
}
