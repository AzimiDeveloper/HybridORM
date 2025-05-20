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
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hama.WinApp.Views.Forms.Users
{
    public partial class RolesForm : BaseForm
    {
        private readonly IBaseServiceEf<Role> _efService;
        private readonly IBaseRepoDbService<Role> _repoService;
        public Role Entity { get; set; }

        public RolesForm(IBaseServiceEf<Role> efService, IBaseRepoDbService<Role> repoService)
        {
            InitializeComponent();
            _efService = efService;
            _repoService = repoService;

            _visibleBarItems = new BarItem[] {
                barButtonItemNew,
                barButtonItemSave,
                barButtonItemEdit,
                barButtonItemDelete,
                barButtonItemReload,
            };

            InitializeBarItemVisible(_visibleBarItems);
        }

        public async override Task<bool> ActionReload()
        {
            var flag = false;
            await LoadingHelper.ProcessAsync(this, async () =>
            {
                var result = await _efService.EfGetQueryable(null);
                if (!result.Success)
                {
                    AlertHelper.ShowError(this, string.Join("\n", result.Errors));
                }

                gridData = new LinqServerModeSource()
                {
                    KeyExpression = "Id",
                    QueryableSource = result.Data
                        .Select(r => new
                        {
                            r.Id,
                            r.Name,
                        })
                };

                customGridControl1.gridControl1.DataSource = null;
                 await FillerHelper.SetData(customGridControl1.gridControl1, gridData);

                flag = true;
            });
            return flag;
        }
        public async override Task<bool> ValidateForm()
        {
            await base.ValidateForm();

            var errors = new List<(Control Control, string Message)>();

            if (string.IsNullOrWhiteSpace(txeRoleName.Text))
                errors.Add((txeRoleName, MessageHelper.GetMessage(204)));

            foreach (var err in errors)
            {
                dxError.SetError(err.Control, err.Message);
                AlertHelper.ShowWarning(this, err.Message);
            }

            return errors.Count == 0;
        }
        public async override Task ClearForm()
        {
            await base.ClearForm();
            this.txeRoleName.EditValue = null;
        }
        public async override Task ActionDelete()
        {
            var id = customGridControl1.gridView1.GetFocusedRowCellValue("Id");

            if (id == null)
            {
                AlertHelper.ShowWarning(this, "لطفاً یک سطر را برای حذف انتخاب کنید");
                return ;
            }

            var confirm = ConfirmDialogHelper.Show(
                message: "آیا از حذف  اطلاعات انتخاب شده، اطمینان دارید؟",
                title: "درخواست حذف"
            );

            if (confirm != DialogResult.Yes)
                return ;

            var result = await _repoService.RepoDeleteAsync(Convert.ToInt32(id));

            if (result.Success)
            {
                await ActionReload();
                AlertHelper.ShowSuccess(this, result.Message);
            }
            else
            {
                AlertHelper.ShowError(this, string.Join("\n", result.Errors));
            }
            return ;
        }
        public async override Task ActionEdit()
        {
            await ClearForm();

            var id = customGridControl1.gridView1.GetFocusedRowCellValue("Id");
            if (id == null) return ;

            var result = await _repoService.RepoGetByIdAsync(Convert.ToInt32(id));

            if (!result.Success || result.Data == null)
            {
                AlertHelper.ShowError(this, "خطا در دریافت اطلاعات");
                return ;
            }

            Entity = result.Data;

            sccMain.Collapsed = false;
            txeRoleName.Text = Entity.Name;
        }
        public async override Task ActionSave()
        {
            var role = Entity ?? new Role();
            string actionName = role.Id == 0 ? "ثبت" : "ویرایش";

            if (!await ValidateForm())
                return ;

            var confirm = ConfirmDialogHelper.Show(
                message: $"آیا از {actionName} اطلاعات انتخاب شده، اطمینان دارید؟",
                title: $"درخواست {actionName}"
            );

            if (confirm != DialogResult.Yes)
                return ;

            try
            {
                role.Name = txeRoleName.Text.Trim();

                ServiceResult<bool> result;

                if (role.Id == 0)
                    result = await _repoService.RepoInsertAsync(role);
                else
                    result = await _repoService.RepoUpdateAsync(role);

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
        public async override Task InitializeGrid()
        {
            var reload = await ActionReload();
            if (reload)
            {
                FillFormGirdProperties(gridData, typeof(Role));
                await SetTitle(customGridControl1.gridView1);
                GridHelper.ReDesignColumns(customGridControl1.gridView1);
            }
        }
        public async override Task SetTitle(GridView grid)
        {
            await base.SetTitle(grid);
            if (grid.Columns["Id"] != null)
                grid.Columns["Id"].Caption = "کد نقش کاربری";
            if (grid.Columns["Name"] != null)
                grid.Columns["Name"].Caption = "نام نقش کاربری";
        }
    }
}
