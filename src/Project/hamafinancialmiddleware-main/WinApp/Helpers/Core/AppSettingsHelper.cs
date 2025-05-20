using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hama.WinApp.Helpers.Core
{
    public static class AppSettingsHelper
    {
        public static string GetConnectionString(string name = "DefaultConnection")
        {
            var cn = ConfigurationManager.ConnectionStrings[name]?.ConnectionString;
            AppContext.SetData("ConnectionString", cn); 
            return cn  ?? throw new InvalidOperationException("Connection string not found.");
        }


    }
}
