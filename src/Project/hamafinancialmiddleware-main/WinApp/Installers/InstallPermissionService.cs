using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using Hama.Core.Models;
using Hama.Service.Interfaces.ORM;
using Hama.Share.Results;
using Hama.WinApp.Views.Components;
using Hama.WinApp.Helpers.UI.Controls;
using Hama.WinApp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hama.WinApp.Installers
{
    public class InstallPermissionService
    {
        private readonly IBaseRepoDbService<Permission> _permissionService;
        private readonly IBaseRepoDbService<Role> _roleService;
        private readonly IBaseRepoDbService<User> _userService;
        private readonly IBaseServiceEf<Permission> _efPermissionService;
        private readonly IBaseServiceEf<Role> _efRoleService;
        private readonly IBaseServiceEf<User> _efUserService;

        private record TempPermission(string Name, string Description, string ParentName);

        public InstallPermissionService(
            IBaseRepoDbService<Permission> permissionService,
            IBaseRepoDbService<Role> roleService,
            IBaseRepoDbService<User> userService,
            IBaseServiceEf<Permission> efPermissionService,
            IBaseServiceEf<Role> efRoleService,
            IBaseServiceEf<User> efUserService)
        {
            _permissionService = permissionService;
            _roleService = roleService;
            _userService = userService;
            _efPermissionService = efPermissionService;
            _efRoleService = efRoleService;
            _efUserService = efUserService;
        }

        public async Task<ServiceResult<bool>> ExtractPermissionsFromAllFormsAsync()
        {
            try
            {
                var tempPermissions = new List<TempPermission>();

                var formTypes = typeof(BaseForm).Assembly
                    .GetTypes()
                    .Where(t => t.IsSubclassOf(typeof(BaseForm)) && !t.IsAbstract)
                    .ToList();

                foreach (var type in formTypes)
                {
                    BaseForm form = null;
                    try
                    {
                        form = Program.ServiceProvider.GetService(type) as BaseForm;
                        if (form == null) continue;

                        // فرم
                        tempPermissions.Add(new TempPermission(type.Name, $"فرم: {form.Text}", null));

                        // دکمه‌ها
                        foreach (var item in form.GetVisibleBarItems())
                        {
                            tempPermissions.Add(new TempPermission(
                                $"{type.Name}.{item.Name}",
                                $"رویداد فرم: {item.Caption}",
                                type.Name));
                        }

                        // تب‌ها
                        var tabPanes = FormHelper.GetAllControlsRecusrvive<TabPane>(form);
                        foreach (var tabPane in tabPanes)
                        {
                            foreach (TabNavigationPage tab in tabPane.Pages)
                            {
                                string tabCode = $"{type.Name}.{tab.Name}";
                                tempPermissions.Add(new TempPermission(tabCode, $"تب: {tab.Caption}", type.Name));

                                foreach (Control ctrl in tab.Controls)
                                {
                                    if (ctrl is not CustomGridControl grid)
                                        continue;

                                    string gridCode = $"{tabCode}.{grid.Name}";
                                    tempPermissions.Add(new TempPermission(gridCode, $"گرید: {tab.Caption}", type.Name));

                                    var barManager = GetBarManager(grid);
                                    if (barManager != null)
                                    {
                                        foreach (var btn in GetBarButtons(barManager))
                                        {
                                            tempPermissions.Add(new TempPermission(
                                                $"{gridCode}.{btn.Name}",
                                                $"رویداد لیست: {btn.Caption}",
                                                type.Name));
                                        }
                                    }
                                }
                            }
                        }

                        // فیلدهای فرم
                        var formFields = ControlsHelper.GetAll(form, ControlsHelper.CrudControls);
                        foreach (Control field in formFields)
                        {
                            if (field is DevExpress.XtraEditors.BaseEdit edit)
                            {
                                string title = ControlsHelper.GetControlDisplayName(edit);
                                tempPermissions.Add(new TempPermission(
                                    $"{type.Name}.{field.Name}",
                                    $"فیلد: [{title}]",
                                    type.Name));
                            }
                        }
                    }
                    catch 
                    {
                        // در صورت خطا رد می‌شیم ولی برنامه قطع نمی‌شود
                        continue;
                    }
                    finally
                    {
                        form?.Dispose();
                    }
                }

                return await SyncPermissionsAsync(tempPermissions);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500,"خطا در استخراج مجوزها:", ex.Message);
            }
        }


        private async Task<ServiceResult<bool>> SyncPermissionsAsync(List<TempPermission> tempPermissions)
        {
            var existingResult = await _efPermissionService.EfGetAsync();
            if (!existingResult.Success)
                return ServiceResult<bool>.Fail(500,"خطا در دریافت مجوزهای موجود:", string.Join("\n", existingResult.Errors));

            var existing = existingResult.Data.ToList();
            var existingNames = existing.Select(p => p.Name).ToHashSet();

            var parentPermissions = tempPermissions
                .Where(p => p.ParentName == null && !existingNames.Contains(p.Name))
                .Select(p => new Permission
                {
                    Name = p.Name,
                    Description = p.Description
                }).DistinctBy(a => a.Name).ToList();

            if (parentPermissions.Any())
            {
                var insertParentResult = await _permissionService.RepoInsertBulkAsync(parentPermissions);
                if (!insertParentResult.Success)
                    return ServiceResult<bool>.Fail(500,"خطا در درج مجوزهای والد:", string.Join("\n", insertParentResult.Errors));
            }

            var allPermissionsResult = await _efPermissionService.EfGetAsync();
            if (!allPermissionsResult.Success)
                return ServiceResult<bool>.Fail(500, "خطا در دریافت مجوزهای به‌روز شده:", string.Join("\n", allPermissionsResult.Errors));

            var allPermissions = allPermissionsResult.Data.ToList();
            var idMap = allPermissions.ToDictionary(p => p.Name, p => p.Id);

            var childPermissions = tempPermissions
                .Where(p => p.ParentName != null && !existingNames.Contains(p.Name))
                .Select(p => new Permission
                {
                    Name = p.Name,
                    Description = p.Description,
                    ParentId = idMap.TryGetValue(p.ParentName!, out int parentId) ? parentId : null
                }).DistinctBy(a => a.Name).ToList();

            if (childPermissions.Any())
            {
                var insertChildResult = await _permissionService.RepoInsertBulkAsync(childPermissions);
                if (!insertChildResult.Success)
                    return ServiceResult<bool>.Fail(500, "خطا در درج مجوزهای فرزند:", string.Join("\n", insertChildResult.Errors));
            }

            var knownCodes = tempPermissions.Select(p => p.Name).ToHashSet();
            var toDelete = existing.Where(e => !knownCodes.Contains(e.Name)).ToList();

            if (toDelete.Any())
            {
                var deleteResult = await _permissionService.RepoDeleteBulkAsync(toDelete);
                if (!deleteResult.Success)
                    return ServiceResult<bool>.Fail(500, "خطا در حذف مجوزهای بلااستفاده:", string.Join("\n", deleteResult.Errors));
            }

            return ServiceResult<bool>.Ok(true, "مجوزها با موفقیت بروزرسانی شدند.",200);
        }

        private BarManager GetBarManager(Control ctrl)
        {
            return ctrl.GetType()
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => typeof(BarManager).IsAssignableFrom(f.FieldType))?
                .GetValue(ctrl) as BarManager;
        }

        private List<BarButtonItem> GetBarButtons(BarManager manager)
        {
            return manager.Items.OfType<BarButtonItem>()
                .Where(b => !string.IsNullOrWhiteSpace(b.Name))
                .ToList();
        }

        public async Task<ServiceResult<bool>> SeedInitialUserAsync()
        {
            try
            {
                var roleResult = await _efRoleService.EfGetAsync(x => x.Name == "Admin");
                if (!roleResult.Success)
                    return ServiceResult<bool>.Fail(500, "خطا در دریافت نقش Admin:", string.Join("\n", roleResult.Errors));

                var adminRole = roleResult.Data.FirstOrDefault();
                if (adminRole == null)
                {
                    var insertRoleResult = await _roleService.RepoInsertAsync(new Role { Name = "Admin" });
                    if (!insertRoleResult.Success)
                        return ServiceResult<bool>.Fail(500, "خطا در ثبت نقش Admin:", string.Join("\n", insertRoleResult.Errors));
                }

                var userResult = await _efUserService.EfGetAsync(x => x.UserName == "admin");
                if (!userResult.Success)
                    return ServiceResult<bool>.Fail(500, "خطا در دریافت کاربر admin:", string.Join("\n", userResult.Errors));

                var adminUser = userResult.Data.FirstOrDefault();
                if (adminUser == null)
                {
                    var newUser = new User
                    {
                        FirstName = "مدیر",
                        LastName = "سیستم",
                        UserName = "admin",
                        PasswordHash = "1234",
                        IsActive = true
                    };
                    var insertUserResult = await _userService.RepoInsertAsync(newUser);
                    if (!insertUserResult.Success)
                        return ServiceResult<bool>.Fail(500, "خطا در ثبت کاربر admin:", string.Join("\n", insertUserResult.Errors));
                }

                return ServiceResult<bool>.Ok(true, "کاربر و نقش admin با موفقیت آماده شدند.",200);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail(500,"خطای کلی در SeedInitialUser:", ex.Message);
            }
        }
    }
}
