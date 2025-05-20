using Hama.Infrastructure.Repositories.Interfaces;
using Hama.WinApp.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hama.WinApp.Providers
{
    public class WinAppConnectionStringProvider : IConnectionStringProvider
    {
        public string GetConnectionString()
        {
            return AppSettingsHelper.GetConnectionString();
        }
    }
}
