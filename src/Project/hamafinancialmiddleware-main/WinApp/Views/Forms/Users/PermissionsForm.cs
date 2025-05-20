using DevExpress.Data.Linq;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using Hama.Core.Models;
using Hama.Service.Interfaces.ORM;
using Hama.WinApp.Helpers.UI.Fillers;
using Hama.WinApp.Helpers.UI.Grid;
using Hama.WinApp.Helpers.UI.Loading;
using Hama.WinApp.Helpers.UI.Notifications;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hama.WinApp.Views.Forms.Users
{
    public partial class PermissionsForm : BaseForm
    {
        private readonly IBaseServiceEf<Permission> _efService;
        private readonly IBaseRepoDbService<Permission> _repoService;

        public Permission Entity { get; set; }

        public PermissionsForm(IBaseServiceEf<Permission> efService, IBaseRepoDbService<Permission> repoService)
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

        public override async Task<bool> ActionReload()
        {
            var flag = false;
            await LoadingHelper.ProcessAsync(this, async () =>
            {
                var result = await _efService.EfGetQueryable(includes: "Parent");

                if (!result.Success)
                {
                    AlertHelper.ShowError(this, string.Join("\n", result.Errors));
                }

                gridData = new LinqServerModeSource()
                {
                    KeyExpression = "Id",
                    QueryableSource = result.Data.Select(x => new
                    {
                        x.Id,
                        x.Name,
                        x.Description,
                        ParentName = x.Parent.Name
                    })
                };

                customGridControl1.gridControl1.DataSource = null;
                await FillerHelper.SetData(customGridControl1.gridControl1, gridData);
                await FillerHelper.SetData(sleParentId, gridData, "Id", "Description", "Name,Description");

                flag = true;
            });
            return flag;
        }
        public override async Task<bool> ValidateForm()
        {
            await base.ValidateForm();

            if (string.IsNullOrWhiteSpace(txeName.Text))
            {
                dxError.SetError(txeName, "نام دسترسی الزامی است.");
                return false;
            }

            return true;
        }
        public override async Task ClearForm()
        {
            await base.ClearForm();
            txeName.EditValue = null;
            txeDescription.EditValue = null;
            sleParentId.EditValue = null;
        }
        public override async Task ActionDelete()
        {
            var id = customGridControl1.gridView1.GetFocusedRowCellValue("Id");
            if (id == null) return;

            var confirm = ConfirmDialogHelper.Show("آیا از حذف مطمئن هستید؟");
            if (confirm != DialogResult.Yes) return;

            var result = await _repoService.RepoDeleteAsync(Convert.ToInt32(id));
            if (result.Success)
            {
                AlertHelper.ShowSuccess(this, result.Message);
                await ActionReload();
            }
            else
            {
                AlertHelper.ShowError(this, string.Join("\n", result.Errors));
            }
        }
        public override async Task ActionEdit()
        {
            await ClearForm();

            var id = customGridControl1.gridView1.GetFocusedRowCellValue("Id");
            if (id == null) return;

            var result = await _repoService.RepoGetByIdAsync(Convert.ToInt32(id));
            if (!result.Success || result.Data == null)
            {
                AlertHelper.ShowError(this, "دریافت اطلاعات با خطا مواجه شد.");
                return;
            }

            Entity = result.Data;
            txeName.Text = Entity.Name;
            txeDescription.Text = Entity.Description;
            sleParentId.EditValue = Entity.ParentId;
            sccCrud.Collapsed = false;
        }
        public override async Task ActionSave()
        {
            var role = Entity ?? new Permission();
            string actionName = role.Id == 0 ? "ثبت" : "ویرایش";

            if (!await ValidateForm())
                return;

            var confirm = ConfirmDialogHelper.Show(
                message: $"آیا از {actionName} اطلاعات انتخاب شده، اطمینان دارید؟",
                title: $"درخواست {actionName}"
            );

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                var entity = Entity ?? new Permission();
                entity.Name = txeName.Text.Trim();
                entity.Description = txeDescription.Text.Trim();
                if (sleParentId.EditValue != null)
                    entity.ParentId = Convert.ToInt32(sleParentId.EditValue);

                if (!await ValidateForm()) return;

                var result = entity.Id == 0
                    ? await _repoService.RepoInsertAsync(entity)
                    : await _repoService.RepoUpdateAsync(entity);

                if (result.Success)
                {
                    AlertHelper.ShowSuccess(this, result.Message);
                    await ActionNew();
                    await ActionReload();
                    Entity = null;
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
        public override async Task InitializeGrid()
        {
            var reload = await ActionReload();
            if (reload)
            {
                await SetTitle(customGridControl1.gridView1);
                GridHelper.ReDesignColumns(customGridControl1.gridView1);
            }
        }
        public override async Task SetTitle(GridView grid)
        {
            await base.SetTitle(grid);
            if (grid.Columns["Id"] != null)
                grid.Columns["Id"].Caption = "کد";

            if (grid.Columns["Name"] != null)
                grid.Columns["Name"].Caption = "نام دسترسی";

            if (grid.Columns["Description"] != null)
                grid.Columns["Description"].Caption = "توضیحات";

            if (grid.Columns["ParentName"] != null)
                grid.Columns["ParentName"].Caption = "والد";
        }
    }
}
