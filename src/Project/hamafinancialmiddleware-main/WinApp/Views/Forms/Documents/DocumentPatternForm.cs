using DevExpress.Data.Linq;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using Hama.Core.Models;
using Hama.Service.Interfaces.ORM;
using Hama.Share.Results;
using Hama.Share.Tools;
using Hama.WinApp.Views.Components;
using Hama.WinApp.Helpers.UI.Fillers;
using Hama.WinApp.Helpers.UI.Grid;
using Hama.WinApp.Helpers.UI.Loading;
using Hama.WinApp.Helpers.UI.Notifications;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hama.WinApp.Views.Forms.Documents
{
    public partial class DocumentPatternForm : BaseForm
    {
        private readonly IBaseServiceEf<DocumentPattern> _efService;
        private readonly IBaseRepoDbService<DocumentPattern> _repoService;
        private readonly IBaseServiceEf<DocumentPatternCategory> _efCategoryService;

        public DocumentPattern Entity { get; set; }
        private LinqServerModeSource DocumentPatternCategoryData = new();

        public DocumentPatternForm(
            IBaseServiceEf<DocumentPattern> efService,
            IBaseRepoDbService<DocumentPattern> repoService,
            IBaseServiceEf<DocumentPatternCategory> efCategoryService)
        {
            InitializeComponent();

            _efService = efService;
            _repoService = repoService;
            _efCategoryService = efCategoryService;

            _visibleBarItems = new BarItem[]
            {
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
                var result = await _efService.EfGetQueryable(includes: "Category,CreatedByUser");
                if (!result.Success)
                {
                    AlertHelper.ShowError(this, string.Join("\n", result.Errors));
                    return;
                }

                gridData = new LinqServerModeSource()
                {
                    KeyExpression = "Id",
                    QueryableSource = result.Data.Select(x => new
                    {
                        x.Id,
                        x.Title,
                        CategoryName = x.Category.Name,
                        x.IsActive,
                        CreatedAt = DateTimeHelper.ToPersianDate(x.CreatedAt),
                        User = x.CreatedByUser.FirstName + " " + x.CreatedByUser.LastName
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
            var errors = new System.Collections.Generic.List<(Control, string)>();

            if (string.IsNullOrWhiteSpace(txeTitle.Text))
                errors.Add((txeTitle, MessageHelper.GetMessage(204)));

            if (string.IsNullOrWhiteSpace(mmeContent.Text))
                errors.Add((mmeContent, MessageHelper.GetMessage(204)));

            if (lueCategoryId.EditValue == null)
                errors.Add((lueCategoryId, MessageHelper.GetMessage(204)));

            foreach (var err in errors)
            {
                dxError.SetError(err.Item1, err.Item2);
                AlertHelper.ShowWarning(this, err.Item2);
            }

            return errors.Count == 0;
        }
        public override async Task ClearForm()
        {
            await base.ClearForm();
            txeTitle.EditValue = null;
            mmeContent.EditValue = null;
            tgsIsActive.IsOn = true;
            lueCategoryId.EditValue = null;
            Entity = null;
        }
        public override async Task ActionDelete()
        {
            var id = customGridControl1.gridView1.GetFocusedRowCellValue("Id");
            if (id == null)
            {
                AlertHelper.ShowWarning(this, "لطفاً یک سطر را برای حذف انتخاب کنید.");
                return;
            }

            var confirm = ConfirmDialogHelper.Show("آیا از حذف اطلاعات انتخاب شده، اطمینان دارید؟", "درخواست حذف");
            if (confirm != DialogResult.Yes)
                return;

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
        }
        public override async Task ActionEdit()
        {
            await ClearForm();

            var id = customGridControl1.gridView1.GetFocusedRowCellValue("Id");
            if (id == null) return;

            var result = await _repoService.RepoGetByIdAsync(Convert.ToInt32(id));
            if (!result.Success || result.Data == null)
            {
                AlertHelper.ShowError(this, "خطا در دریافت اطلاعات");
                return;
            }

            Entity = result.Data;
            txeTitle.EditValue = Entity.Title;
            mmeContent.EditValue = Entity.Content;
            tgsIsActive.IsOn = Entity.IsActive;
            lueCategoryId.EditValue = Entity.CategoryId;

            sccMain.Collapsed = false;
        }
        public override async Task ActionSave()
        {
            var entity = Entity ?? new DocumentPattern();
            string actionName = entity.Id == 0 ? "ثبت" : "ویرایش";

            if (!await ValidateForm())
                return;

            var confirm = ConfirmDialogHelper.Show($"آیا از {actionName} اطلاعات انتخاب شده، اطمینان دارید؟", $"درخواست {actionName}");
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                entity.Title = txeTitle.Text.Trim();
                entity.Content = mmeContent.Text.Trim();
                entity.CreatedAt = DateTime.Now;
                entity.IsActive = tgsIsActive.IsOn;
                entity.CategoryId = Convert.ToInt32(lueCategoryId.EditValue);
                entity.CreatedByUserId = CurrentUser.Id;

                ServiceResult<bool> result;
                if (entity.Id == 0)
                    result = await _repoService.RepoInsertAsync(entity);
                else
                    result = await _repoService.RepoUpdateAsync(entity);

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
                FillFormGirdProperties(gridData, typeof(DocumentPattern));
                await SetTitle(customGridControl1.gridView1);
                GridHelper.ReDesignColumns(customGridControl1.gridView1);
            }
        }
        public override async Task InitializeList()
        {
            await base.InitializeList();
            await LoadingHelper.ProcessAsync(this, async () =>
            {
                var result = await _efCategoryService.EfGetQueryable(null);
                if (!result.Success)
                {
                    AlertHelper.ShowError(this, string.Join("\n", result.Errors));
                    return;
                }

                DocumentPatternCategoryData = new LinqServerModeSource()
                {
                    KeyExpression = "Id",
                    QueryableSource = result.Data.Select(r => new { r.Id, r.Name })
                };

                await FillerHelper.SetData(lueCategoryId, DocumentPatternCategoryData, "Id", "Name", "Name");
            });

        }
        public override async Task SetTitle(GridView grid)
        {
            await base.SetTitle(grid);
            if (grid.Columns["Id"] != null)
                grid.Columns["Id"].Visible = false;

            if (grid.Columns["Title"] != null)
                grid.Columns["Title"].Caption = "عنوان الگو";

            if (grid.Columns["CreatedAt"] != null)
                grid.Columns["CreatedAt"].Caption = "تاریخ ایجاد";

            if (grid.Columns["IsActive"] != null)
                grid.Columns["IsActive"].Caption = "فعال؟";

            if (grid.Columns["CategoryName"] != null)
                grid.Columns["CategoryName"].Caption = "دسته‌بندی";

            if (grid.Columns["User"] != null)
                grid.Columns["User"].Caption = "کاربر";
        }
    }
}
