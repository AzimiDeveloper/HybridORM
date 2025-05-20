using DevExpress.Data;
using DevExpress.Data.Linq;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Hama.Core.Models;
using Hama.Service.Interfaces.ORM;
using Hama.Share.Models.Mock;
using Hama.Share.Models.Nosa;
using Hama.Share.Tools;
using Hama.WinApp.Helpers.UI.Controls;
using Hama.WinApp.Helpers.UI.Fillers;
using Hama.WinApp.Helpers.UI.Grid;
using Hama.WinApp.Helpers.UI.Loading;
using Hama.WinApp.Helpers.UI.Notifications;
using Hama.WinApp.Views.Components;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hama.WinApp.Views.Forms.Documents
{
    public partial class NosaAccountingForm : BaseForm
    {
        public DocumentPattern _newDocumentPattern { get; set; }
        private readonly IServiceProvider _provider;
        private readonly IBaseServiceEf<DocumentPattern> _efDocumentPatternService;
        private IEnumerable<object> _sourceData;
        private LinqServerModeSource DocumentPatternCategoryData = new();
        private Dictionary<int, bool> _rowSelections = new();


        public NosaAccountingForm(IBaseServiceEf<DocumentPattern> efDocumentPatternService, IServiceProvider provider)
        {
            InitializeComponent();
            _efDocumentPatternService = efDocumentPatternService;
            _provider = provider;

            _visibleBarItems = new[]
            {
                barButtonItemNew,
                barButtonItemSave,
                barButtonItemReload,
                barButtonItemSelectAll
            };

            InitializeBarItemVisible(_visibleBarItems);
            _provider = provider;
        }

        private ColumnProperty[] GetSourceColumns()
        {
            var result = new List<ColumnProperty>
            {
                new ColumnProperty { Name = "InternationalDate", DataType = typeof(DateTime) },
                new ColumnProperty { Name = "PersianDate", DataType = typeof(DateTime)}
            };

            var firstItem = _sourceData?.FirstOrDefault();
            if (firstItem != null)
            {
                var dynamicProps = firstItem.GetType().GetProperties()
                    .Select(p => new ColumnProperty
                    {
                        Name = p.Name,
                        DataType = p.PropertyType
                    });

                result.AddRange(dynamicProps);
            }

            return result.ToArray();
        }



        private async void sbeAddDocumentPattern_Click(object sender, EventArgs e)
        {
            var columns = GetSourceColumns();


            NosaAccountingXMLDesigner form = _provider.GetRequiredService<NosaAccountingXMLDesigner>();
            form._nosaAccountingForm = this;
            form.Columns = GetSourceColumns(); // ارسال لیست ستون‌ها

            var parentMainForm = this.ParentForm;
            if (parentMainForm != null)
                FormHelper.ShowMdiForm(form, parentMainForm, ((MainForm)parentMainForm).ModalMode);
            else
                FormHelper.ShowMdiForm(form, this, false);
            await form.ActionReload();
        }

        public override async Task<bool> ValidateForm()
        {
            await base.ValidateForm();
            var errors = new List<(Control, string)>();

            foreach (var err in errors)
            {
                dxError.SetError(err.Item1, err.Item2);
                AlertHelper.ShowWarning(this, err.Item2);
            }
            return errors.Count == 0;
        }
        public override async Task<bool> ActionReload()
        {
            await base.ActionReload();
            await LoadingHelper.ProcessAsync(this, async () =>
            {
                var mock = await MockGenerator.GenerateMockPolicies(100_000);
                var data = await FastDataTableConverter.ToDataTableAsync(mock, addSelectColumn: true);
                await FillerHelper.SetData(customGridControl1.gridControl1, data, Editable: true);
            });

            return true;
        }
        public override async Task ClearForm()
        {
            await base.ClearForm();



        }
        public override async Task InitializeList()
        {
            await base.InitializeList();
            await LoadingHelper.ProcessAsync(this, async () =>
            {
                var result = await _efDocumentPatternService.EfGetQueryable(null);
                if (!result.Success)
                {
                    AlertHelper.ShowError(this, string.Join("\n", result.Errors));
                    return;
                }

                DocumentPatternCategoryData = new LinqServerModeSource()
                {
                    KeyExpression = "Id",
                    QueryableSource = result.Data.Select(r => new { r.Id, Name = r.Title })
                };

                await FillerHelper.SetData(luePatternId, DocumentPatternCategoryData, "Id", "Name", "Name");
            });

        }
        public override async Task SetTitle(GridView grid)
        {
            await base.SetTitle(grid);

            if (grid.Columns["PolicyId"] != null)
                grid.Columns["PolicyId"].Caption = "شماره بیمه‌نامه";

            if (grid.Columns["FullName"] != null)
                grid.Columns["FullName"].Caption = "نام بیمه‌شده";


            if (grid.Columns["PolicyId"] != null)
                grid.Columns["PolicyId"].Tag = SummaryItemType.Count;

            if (grid.Columns["PremiumAmount"] != null)
                grid.Columns["PremiumAmount"].Tag = SummaryItemType.Sum;

            if (grid.Columns["PremiumAmount"] != null)
                grid.Columns["PremiumAmount"].Tag = SummaryItemType.Sum;

            if (grid.Columns["CoverageAmount"] != null)
                grid.Columns["CoverageAmount"].Tag = SummaryItemType.Sum;

            if (grid.Columns["Deductible"] != null)
                grid.Columns["Deductible"].Tag = SummaryItemType.Sum;


            if (grid.Columns["AgentId"] != null)
                grid.Columns["AgentId"].Tag = SummaryItemType.Average;
        }
        public override async Task ActionSave()
        {
            await base.ActionSave();

            // 1. بررسی انتخاب الگو
            if (luePatternId.EditValue == null)
            {
                AlertHelper.ShowWarning(this, "هیچ الگویی برای ذخیره‌سازی انتخاب نشده است.");
                return;
            }

            // 2. دریافت الگوی سند از دیتابیس
            var resultPattern = await _efDocumentPatternService.EfGetQueryable(a => a.Id == (int)luePatternId.EditValue);
            if (!resultPattern.Success)
            {
                AlertHelper.ShowError(this, string.Join("\n", resultPattern.Errors));
                return;
            }

            var xmlPatternContent = resultPattern.Data.FirstOrDefault()?.Content;
            if (string.IsNullOrWhiteSpace(xmlPatternContent))
            {
                AlertHelper.ShowWarning(this, "محتوای الگوی سند خالی است.");
                return;
            }

            // 3. استخراج اطلاعات هدر و بندها از الگو
            var xmlHeader = XmlHelper.ExtractVoucherHeader(xmlPatternContent);
            var xmlLines = XmlHelper.ExtractVoucherLines(xmlPatternContent);

            var headerDto = VoucherHelper.ParseVoucherHeader(xmlHeader);
            var patternLines = VoucherHelper.ParseVoucherLines(xmlLines);

            // 4. دریافت داده‌های انتخاب‌شده از گرید
            var dataTable = customGridControl1.gridControl1.DataSource as DataTable;
            if (dataTable == null)
            {
                AlertHelper.ShowWarning(this, "هیچ دیتایی برای پردازش وجود ندارد.");
                return;
            }

            var selectedRows = dataTable.AsEnumerable()
                .Where(row => row.Field<bool?>("IsSelected") == true)
                .ToList();

            if (selectedRows.Count == 0)
            {
                AlertHelper.ShowWarning(this, "هیچ رکوردی انتخاب نشده است.");
                return;
            }

            // 5. آماده‌سازی سند نهایی
            var finalVoucher = new VoucherDto
            {
                Header = headerDto,
                Lines = new List<VoucherLineDto>()
            };

            // 6. ساخت بندها از روی الگو و داده‌های انتخابی
            foreach (var patternLine in patternLines)
            {
                bool isAggregate =
                    ExpressionHelper.ContainsAggregatePlaceholder(patternLine.Debit) ||
                    ExpressionHelper.ContainsAggregatePlaceholder(patternLine.Credit);

                bool isNormal =
                    ExpressionHelper.ContainsNormalPlaceholder(patternLine.Debit) ||
                    ExpressionHelper.ContainsNormalPlaceholder(patternLine.Credit) ||
                    ExpressionHelper.ContainsNormalPlaceholder(patternLine.Description);

                if (isAggregate)
                {
                    // ✅ تجمیعی - فقط یک خط
                    var newLine = new VoucherLineDto
                    {
                        AccountCode = patternLine.AccountCode,
                        Description = ExpressionHelper.ProcessField(patternLine.Description, selectedRows.First(), selectedRows),
                        Debit = ExpressionHelper.ProcessField(patternLine.Debit, selectedRows.First(), selectedRows),
                        Credit = ExpressionHelper.ProcessField(patternLine.Credit, selectedRows.First(), selectedRows),
                    };
                    finalVoucher.Lines.Add(newLine);
                }
                else
                {
                    // ✅ تفکیکی - به ازای هر سطر یک خط
                    foreach (var row in selectedRows)
                    {
                        var newLine = new VoucherLineDto
                        {
                            AccountCode = patternLine.AccountCode,
                            Description = ExpressionHelper.ProcessField(patternLine.Description, row, selectedRows),
                            Debit = ExpressionHelper.ProcessField(patternLine.Debit, row, selectedRows),
                            Credit = ExpressionHelper.ProcessField(patternLine.Credit, row, selectedRows)
                        };
                        finalVoucher.Lines.Add(newLine);
                    }
                }
            }

            // 7. ساخت XML نهایی و نمایش
            var xmlFinal = VoucherHelper.BuildVoucherXml(finalVoucher);

            var previewForm = new VocucherPreviewForm();
            await previewForm.HtmlEditorControl.LoadXmlToHTML(xmlFinal);
            FormHelper.ShowMdiForm(previewForm, this, false);

            AlertHelper.ShowInformation(this, $"{selectedRows.Count:N0} ردیف پردازش و {finalVoucher.Lines.Count:N0} خط سند تولید شد.");
        }
        public override async Task InitializeGrid()
        {
            var reload = await ActionReload();
            if (!reload) return;

            // اعمال عنوان و خلاصه
            await SetTitle(customGridControl1.gridView1);
            await GridHelper.ReDesignColumns(customGridControl1.gridView1);

            var gridView = customGridControl1.gridView1;
            var gridControl = customGridControl1.gridControl1;

            // فقط ستون IsSelected قابل ویرایش باشد
            gridView.OptionsBehavior.Editable = true;
            gridView.OptionsBehavior.ImmediateUpdateRowPosition = true;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;

            // پیدا کردن ستون انتخاب
            var selectColumn = gridView.Columns["IsSelected"];
            if (selectColumn != null)
            {
                selectColumn.OptionsColumn.AllowEdit = true;
                selectColumn.OptionsColumn.AllowFocus = true;

                var checkEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
                {
                    ValueChecked = true,
                    ValueUnchecked = false,
                    AllowGrayed = false
                };

                checkEdit.EditValueChanged += (s, e) =>
                {
                    gridView.PostEditor();                // ذخیره سریع مقدار چک‌باکس
                    var rowHandle = gridView.FocusedRowHandle;
                    if (gridView.IsValidRowHandle(rowHandle))
                        gridView.InvalidateRow(rowHandle); // 💡 فقط redraw سبک، نه update کامل
                };

                //gridView.RowStyle += (s, e) =>
                //{
                //    if (e.RowHandle < 0) return;

                //    var view = (GridView)s;
                //    var val = view.GetRowCellValue(e.RowHandle, "IsSelected");

                //    if (val is bool selected && selected)
                //    {
                //        e.Appearance.BackColor = Color.LightGreen;
                //        e.Appearance.ForeColor = Color.Black;
                //    }
                //};



                gridControl.RepositoryItems.Add(checkEdit);
                selectColumn.ColumnEdit = checkEdit;
            }
        }
        public override async Task ActionSelectAll()
        {
            await base.ActionSelectAll();

            var gridView = customGridControl1.gridView1;
            var dataTable = customGridControl1.gridControl1.DataSource as DataTable;
            if (gridView == null || dataTable == null) return;

            gridView.PostEditor();

            // 💡 فقط RowHandleهای قابل‌مشاهده (نمایشی واقعی با فیلترهای کاربر)
            var visibleHandles = Enumerable.Range(0, gridView.RowCount)
                                           .Select(i => gridView.GetVisibleRowHandle(i))
                                           .Where(gridView.IsValidRowHandle)
                                           .ToList();

            // 🚀 شروع تغییر دسته‌ای روی DataTable
            dataTable.BeginLoadData();

            foreach (var rowHandle in visibleHandles)
            {
                var dataRow = gridView.GetDataRow(rowHandle);
                if (dataRow != null)
                    dataRow["IsSelected"] = !bool.Parse(dataRow["IsSelected"].ToString()); // سریع و مستقیم
            }

            dataTable.EndLoadData(); // اعمال تغییرات
            gridView.RefreshData(); // فقط رنگ‌ها
        }






    }


}
