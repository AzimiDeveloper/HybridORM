using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hama.WinApp.Helpers.Core
{
    public class AppConfigHelper
    {
        public SortedList<string, string> GetConfigs()
        {
            SortedList<string, string> configs = new SortedList<string, string>();
            foreach (string key in ConfigurationManager.AppSettings)
            {
                string value = ConfigurationManager.AppSettings[key];
                configs.Add(key, value);
            }
            return configs;
        }

        public void AddConfig(string key,string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
