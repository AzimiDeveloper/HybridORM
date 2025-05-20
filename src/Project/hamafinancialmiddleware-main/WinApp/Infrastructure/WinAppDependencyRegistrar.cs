using Hama.WinApp.Views.Forms;
using Hama.WinApp.Views.Forms.DocumentPatterns;
using Hama.WinApp.Views.Forms.Documents;
using Hama.WinApp.Views.Forms.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Hama.WinApp.Infrastructure
{
    public static class WinAppDependencyRegistrar
    {
        public static IServiceCollection AddWinAppDependencies(this IServiceCollection services)
        {
            // فرم‌های کاربران
            services.AddTransient<LoginForm>();
            services.AddTransient<UsersForm>();
            services.AddTransient<RolesForm>();
            services.AddTransient<PermissionsForm>();
            services.AddTransient<UserPermissionForm>();

            // فرم‌های اسناد
            services.AddTransient<DocumentPatternCategoriesForm>();
            services.AddTransient<DocumentPatternForm>();
            services.AddTransient<NosaAccountingForm>();
            services.AddTransient<NosaAccountingXMLDesigner>();
            services.AddTransient<NosaAccountingColumnSelectorForm>();

            // فرم‌های عمومی
            services.AddTransient<MainForm>();

            return services;
        }
    }
}
