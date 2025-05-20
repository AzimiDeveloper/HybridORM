using DevExpress.Data.Linq;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using Hama.Core.Models;
using Hama.Share.Tools;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hama.WinApp.Views.Components;
using Hama.Service.Interfaces.ORM;
using Hama.WinApp.Helpers.UI.Notifications;
using Hama.WinApp.Helpers.UI.Grid;
using Hama.WinApp.Helpers.UI.Loading;
using Hama.WinApp.Helpers.UI.Fillers;
using Hama.Share.Results;

namespace Hama.WinApp.Views.Forms.DocumentPatterns
{
    public partial class DocumentPatternCategoriesForm : BaseForm
    {
        private readonly IBaseServiceEf<DocumentPatternCategory> _efService;
        private readonly IBaseRepoDbService<DocumentPatternCategory> _repoService;

        public DocumentPatternCategory Entity { get; set; }

        public DocumentPatternCategoriesForm(
            IBaseServiceEf<DocumentPatternCategory> efService,
            IBaseRepoDbService<DocumentPatternCategory> repoService)
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
                var result = await _efService.EfGetQueryable(null);
                if (!result.Success)
                {
                    AlertHelper.ShowError(this, string.Join("\n", result.Errors));
                }

                gridData = new LinqServerModeSource()
                {
                    KeyExpression = "Id",
                    QueryableSource = result.Data
                        .Select(d => new
                        {
                            d.Id,
                            d.Name
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
            if (string.IsNullOrWhiteSpace(txeName.Text))
            {
                dxError.SetError(txeName, "نام دسته بندی سند الزامی است.");
                return false;
            }
            return true;
        }
        public override async Task ClearForm()
        {
            await base.ClearForm();
            txeName.EditValue = null;
            Entity = null;
        }
        public override async Task ActionDelete()
        {
            var id = customGridControl1.gridView1.GetFocusedRowCellValue("Id");
            if (id == null)
            {
                AlertHelper.ShowWarning(this, "لطفاً یک ردیف را برای حذف انتخاب کنید.");
                return;
            }

            var confirm = ConfirmDialogHelper.Show("آیا از حذف دسته بندی سند انتخاب شده مطمئن هستید؟");
            if (confirm != DialogResult.Yes)
                return;

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
                AlertHelper.ShowError(this, "خطا در دریافت اطلاعات.");
                return;
            }

            Entity = result.Data;
            txeName.Text = Entity.Name;
            sccMain.Collapsed = false;
        }
        public override async Task ActionSave()
        {
            var category = Entity ?? new DocumentPatternCategory();
            string actionName = category.Id == 0 ? "ثبت" : "ویرایش";

            if (!await ValidateForm())
                return;

            var confirm = ConfirmDialogHelper.Show(
                message: $"آیا از {actionName} اطلاعات اطمینان دارید؟",
                title: $"درخواست {actionName}"
            );

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                category.Name = txeName.Text.Trim();

                ServiceResult<bool> result;
                if (category.Id == 0)
                    result = await _repoService.RepoInsertAsync(category);
                else
                    result = await _repoService.RepoUpdateAsync(category);

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
                grid.Columns["Name"].Caption = "نام دسته بندی سند";
        }
    }
}
