using DevExpress.Data.Linq;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using Hama.Core.Models;
using Hama.Service.Interfaces.ORM;
using Hama.Share.Results;
using Hama.Share.Tools;
using Hama.WinApp.Helpers.UI.Fillers;
using Hama.WinApp.Helpers.UI.Grid;
using Hama.WinApp.Helpers.UI.Loading;
using Hama.WinApp.Helpers.UI.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hama.WinApp.Views.Forms.Users
{
    public partial class UsersForm : BaseForm
    {
        private readonly IBaseServiceEf<User> _efUserService;
        private readonly IBaseRepoDbService<User> _repoUserService;
        public User Entity { get; set; }

        public UsersForm(IBaseServiceEf<User> efUserService, IBaseRepoDbService<User> repoUserService)
        {
            InitializeComponent();

            _efUserService = efUserService;
            _repoUserService = repoUserService;

            _visibleBarItems = new BarItem[] {
                barButtonItemNew,
                barButtonItemSave,
                barButtonItemEdit,
                barButtonItemDelete,
                barButtonItemReload
            };

            InitializeBarItemVisible(_visibleBarItems);
        }
       
        public override async Task<bool> ActionReload()
        {
            var flag = false;
            await LoadingHelper.ProcessAsync(this, async () =>
            {
                var result = await _efUserService.EfGetQueryable(null);
                if (!result.Success)
                {
                    AlertHelper.ShowError(this, string.Join("\n", result.Errors));
                }

                gridData = new LinqServerModeSource()
                {
                    KeyExpression = "Id",
                    QueryableSource = result.Data.Select(u => new
                    {
                        u.Id,
                        u.UserName,
                        FullName = u.FirstName + " " + u.LastName,
                        u.IsActive
                    })
                };

                customGridControl1.gridControl1.DataSource = null;
                 await FillerHelper.SetData(customGridControl1.gridControl1, gridData);

                flag = true;
            });

            return flag;
        }
        public override async Task<bool> ValidateForm()
        {
            await base.ValidateForm();

            var errors = new List<(Control Control, string Message)>();

            if (string.IsNullOrWhiteSpace(txeUserName.Text))
                errors.Add((txeUserName, MessageHelper.GetMessage(204)));

            if (Entity == null && string.IsNullOrWhiteSpace(txePassword.Text))
                errors.Add((txePassword, "رمز عبور الزامی است."));

            foreach (var err in errors)
            {
                dxError.SetError(err.Control, err.Message);
                AlertHelper.ShowWarning(this, err.Message);
            }

            return errors.Count == 0;
        }
        public override async Task ClearForm()
        {
            await base.ClearForm();

            txeUserName.EditValue = null;
            txeFirstName.EditValue = null;
            txeLastName.EditValue = null;
            txePassword.EditValue = null;
            tglIsActive.IsOn = true;
            Entity = null;
        }
        public override async Task ActionSave()
        {
            if (!await ValidateForm())
                return ;

            var user = Entity ?? new User();
            string actionName = user.Id == 0 ? "ثبت" : "ویرایش";

            var confirm = ConfirmDialogHelper.Show(
                message: $"آیا از {actionName} اطلاعات انتخاب شده، اطمینان دارید؟",
                title: $"درخواست {actionName}"
            );

            if (confirm != DialogResult.Yes)
                return ;

            try
            {
                user.UserName = txeUserName.Text.Trim();
                user.FirstName = txeFirstName.Text.Trim();
                user.LastName = txeLastName.Text.Trim();
                user.IsActive = tglIsActive.IsOn;

                if (!string.IsNullOrWhiteSpace(txePassword.Text))
                    user.PasswordHash = txePassword.Text.Trim();

                ServiceResult<bool> result;

                if (user.Id == 0)
                    result = await _repoUserService.RepoInsertAsync(user);
                else
                    result = await _repoUserService.RepoUpdateAsync(user);

                if (result.Success)
                {
                    await ActionNew();
                    await ActionReload();
                    Entity = null;
                    AlertHelper.ShowSuccess(this, result.Message);
                }
                else
                {
                    AlertHelper.ShowError(this, string.Join("\n", result.Errors));
                }
            }
            catch (Exception ex)
            {
                AlertHelper.ShowError(this, $"خطای غیرمنتظره:\n{ex.Message}");
            }
        }
        public override async Task ActionEdit()
        {
            await ClearForm();

            var id = customGridControl1.gridView1.GetFocusedRowCellValue("Id");
            if (id == null) return ;

            var result = await _repoUserService.RepoGetByIdAsync(Convert.ToInt32(id));
            if (!result.Success || result.Data == null)
            {
                AlertHelper.ShowError(this, "خطا در دریافت اطلاعات کاربر.");
                return ;
            }

            Entity = result.Data;

            txeUserName.Text = Entity.UserName;
            txeFirstName.Text = Entity.FirstName;
            txeLastName.Text = Entity.LastName;
            tglIsActive.IsOn = Entity.IsActive;
            txePassword.EditValue = null; // رمز نمایش داده نمی‌شود

            sccMain.Collapsed = false;

        }
        public override async Task ActionDelete()
        {
            var id = customGridControl1.gridView1.GetFocusedRowCellValue("Id");

            if (id == null)
            {
                AlertHelper.ShowWarning(this, "لطفاً یک کاربر را برای حذف انتخاب کنید");
                return ;
            }

            var confirm = ConfirmDialogHelper.Show(
                message: "آیا از حذف کاربر انتخاب شده اطمینان دارید؟",
                title: "درخواست حذف"
            );

            if (confirm != DialogResult.Yes)
                return ;

            var result = await _repoUserService.RepoDeleteAsync(Convert.ToInt32(id));

            if (result.Success)
            {
                await ActionReload();
                AlertHelper.ShowSuccess(this, result.Message);
            }
            else
            {
                AlertHelper.ShowError(this, string.Join("\n", result.Errors));
            }
        }
        public override async Task InitializeGrid()
        {
            var reload = await ActionReload();
            if (reload)
            {
                FillFormGirdProperties(gridData, typeof(User));
                await SetTitle(customGridControl1.gridView1);
                GridHelper.ReDesignColumns(customGridControl1.gridView1);
            }
        }
        public override async Task SetTitle(GridView grid)
        {
            await base.SetTitle(grid);
            if (grid.Columns["Id"] != null)
                grid.Columns["Id"].Visible = false;

            if (grid.Columns["UserName"] != null)
                grid.Columns["UserName"].Caption = "نام کاربری";

            if (grid.Columns["FullName"] != null)
                grid.Columns["FullName"].Caption = "نام و نام خانوادگی";

            if (grid.Columns["IsActive"] != null)
                grid.Columns["IsActive"].Caption = "فعال / غیرفعال";

        }
    }
}
