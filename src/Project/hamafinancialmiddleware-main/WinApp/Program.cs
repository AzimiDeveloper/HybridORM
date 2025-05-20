using Hama.Core.Models;
using Hama.Infrastructure.Extensions;
using Hama.Infrastructure.Repositories.Interfaces;
using Hama.Service.ServiceRegistration;
using Hama.Share.Models.Mock;
using Hama.WinApp.Helpers.Core;
using Hama.WinApp.Infrastructure;
using Hama.WinApp.Providers;
using Hama.WinApp.Views.Forms;
using Hama.WinApp.Views.Forms.DocumentPatterns;
using Hama.WinApp.Views.Forms.Documents;
using Hama.WinApp.Views.Forms.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver.Core.Configuration;
using RepoDb;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hama.WinApp
{

    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        private static ServiceCollection _serviceCollection;

        public static string _ConectionString => AppSettingsHelper.GetConnectionString();

        [STAThread]
        static void Main()
        {
            _serviceCollection = new ServiceCollection();

            // 1. پیکربندی وابستگی‌ها
            ConfigureDependencyInjection();

            // 2. ساخت provider
            ServiceProvider = _serviceCollection.BuildServiceProvider();

            // 3. ظاهر DevExpress
            FillDefaultSkin();

            // 4. RepoDb Bootstrap
            RepoDb.GlobalConfiguration.Setup().UseSqlServer();

            // 5. اجرای فرم اصلی
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CheckAndRunApplication();
        }

        private static void ConfigureDependencyInjection()
        {
            // 1. ثبت Provider کانکشن استرینگ برای مصرف در DbContext و RepoDB
            _serviceCollection.AddSingleton<IConnectionStringProvider, WinAppConnectionStringProvider>();

            // 2. تنظیم DbContext با کانکشن استرینگ داینامیک (EF Core)
            _serviceCollection.AddDbContext<HamaFinancialMiddlewareContext>((serviceProvider, options) =>
            {
                var connectionStringProvider = serviceProvider.GetRequiredService<IConnectionStringProvider>();
                var connectionString = connectionStringProvider.GetConnectionString();

                options.UseSqlServer(connectionString);
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });

            // 3. کش داخلی (برای EF و RepoDB)
            _serviceCollection.AddMemoryCache();

            // 4. رجیستری لایه زیرساخت (ریپازیتوری‌ها)
            _serviceCollection.AddRepositories();

            // 5. رجیستری سرویس‌های کاربردی (Application Services)
            _serviceCollection.AddApplicationServices();

            // 6. رجیستری فرم‌های WinForms
            _serviceCollection.AddWinAppDependencies();
        }
        private static void CheckAndRunApplication()
        {
                 var loginForm = ServiceProvider.GetRequiredService<LoginForm>();
                Application.Run(loginForm);
        }
        private static void FillDefaultSkin()
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("WXI", "Calmness");
        }
    }

}
