using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Hama.Core.Models;
using Hama.Service.Interfaces.ORM;
using Hama.WinApp.Helpers.UI.Grid;
using Hama.WinApp.Helpers.UI.Fillers;
using Hama.WinApp.Helpers.UI.Notifications;
using Hama.WinApp.Helpers.UI.Loading;
using DevExpress.XtraPivotGrid;
using Hama.Share.Tools;
using Hama.WinApp.Helpers.UI.Controls;
using Microsoft.Extensions.DependencyInjection;
using DevExpress.Data.Linq;
using System.IO;
using Hama.Share.Results;
using System.Text.Json;
using DevExpress.XtraGauges.Core.Styles;

namespace Hama.WinApp.Views.Forms.Documents
{
    public partial class NosaAccountingXMLDesigner : BaseForm
    {
        public NosaAccountingForm _nosaAccountingForm { get; set; }
        public DocumentPattern Entity { get; set; }
        public ColumnProperty[] Columns { get; set; } = Array.Empty<ColumnProperty>();
        private readonly IBaseServiceEf<DocumentPatternCategory> _efCategoryService;
        private readonly IBaseRepoDbService<DocumentPattern> _repoService;
        private readonly IServiceProvider _provider;

        public NosaAccountingXMLDesigner(IServiceProvider provider, IBaseServiceEf<DocumentPatternCategory> efCategoryService, IBaseRepoDbService<DocumentPattern> repoService)
        {
            InitializeComponent();
            _provider = provider;
            _visibleBarItems = new[]
            {
                barButtonItemSave,
            };

            InitializeBarItemVisible(_visibleBarItems);
            _efCategoryService = efCategoryService;
            _repoService = repoService;
        }

        public async override Task<bool> ActionReload()
        {
            await base.ActionReload();
            await this.xmlEditorControl.LoadXML();
            return true;
        }
        public async override Task InitializeForm()
        {
            txeDate.ButtonClick += SelectValueFromSourceColumn;
            txeVoucherNumber.ButtonClick += SelectValueFromSourceColumn;
            txeCurrency.ButtonClick += SelectValueFromSourceColumn;
            txeDebit.ButtonClick += SelectValueFromSourceColumn;
            txeCredit.ButtonClick += SelectValueFromSourceColumn;

            await base.InitializeForm();
        }
        public async override Task ClearForm()
        {
            this.txeDate.Text = DateTimeHelper.ToPersianDateTime(DateTime.Now);
            this.txeDescription.Text = "اولین سند حسابداری درمان";
            this.txeCurrency.Text = "IRR";
            this.txeVoucherNumber.Text = "1";

            this.txeAccountCode.Text = "102201";
            this.txeCredit.Text = "10562000";
            this.txeDebit.Text = "0";
            this.mmeLineDescription.Text = "بستانکاری آقای عظیمی - واریزی";

            this.lciDocumentPatternTitle.Text = "الگوی ";
            this.lueDocumentPatternCategoryId.EditValue = null;


            await base.ClearForm();
        }
        public async override Task InitializeList()
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

                var DocumentPatternCategoryData = new LinqServerModeSource()
                {
                    KeyExpression = "Id",
                    QueryableSource = result.Data.Select(r => new { r.Id, r.Name })
                };

                await FillerHelper.SetData(lueDocumentPatternCategoryId, DocumentPatternCategoryData, "Id", "Name", "Name");
            });
        }
        public async override Task<bool> ValidateForm()
        {
            var xmlData = await GetXmlDataAsync();
            await base.ValidateForm();
            var errors = new System.Collections.Generic.List<(Control, string)>();

            if (string.IsNullOrWhiteSpace(txeDocumentPatternTitle.Text))
                errors.Add((txeDocumentPatternTitle, MessageHelper.GetMessage(204)));
            else
            if (lueDocumentPatternCategoryId.EditValue == null)
                errors.Add((lueDocumentPatternCategoryId, MessageHelper.GetMessage(204)));
            else
            if (string.IsNullOrWhiteSpace(xmlData))
                errors.Add((xmlEditorControl, "شابلون هنوز تعریف نشده است"));
            else
            if (this.HtmlEditorControl.IsValidXml(xmlData))
                errors.Add((xmlEditorControl, "فرمت شابلون نامعتبر میباشد"));
            else
            {
                // مسیر فایل XSD - می‌تونی اینو از فایل یا Embedded Resource بخونی
                string xsdPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Schemas", "voucher-schema.xsd");


                if (!File.Exists(xsdPath))
                {
                    errors.Add((xmlEditorControl, "فایل XSD برای اعتبارسنجی یافت نشد"));
                }
                else if (!this.HtmlEditorControl.ValidateXml(xmlData, xsdPath, out string? validationError))
                {
                    errors.Add((xmlEditorControl, $"فرمت شابلون نامعتبر است: {validationError}"));
                }
            }


            foreach (var err in errors)
            {
                dxError.SetError(err.Item1, err.Item2);
                AlertHelper.ShowWarning(this, err.Item2);
            }

            return errors.Count == 0;
        }
        public async override Task ActionSave()
        {
            var entity = Entity ?? new DocumentPattern();
            await base.ActionSave();

            if (!await ValidateForm())
                return;

            try
            {
                entity.Title = txeDocumentPatternTitle.Text.Trim();

                // مرحله 1: تمیز کردن رشته escape‌شده
                var decodedXml = JsonSerializer.Deserialize<string>(await GetXmlDataAsync()); // تبدیل به XML واقعی
                if (decodedXml == null)
                {
                    return;
                }

                decodedXml = this.HtmlEditorControl.CleanXml(decodedXml); // حذف BOM و فاصله اضافی
                entity.Content = decodedXml;
                entity.CreatedAt = DateTime.Now;
                entity.IsActive = true;
                entity.CategoryId = Convert.ToInt32(lueDocumentPatternCategoryId.EditValue);
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
                    _nosaAccountingForm._newDocumentPattern = entity;
                    await _nosaAccountingForm.InitializeList();
                    _nosaAccountingForm.luePatternId.EditValue = entity.Id;
                    this.Close();
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

        public async Task<string> GetXmlDataAsync()
        {
            try
            {
                var data = await xmlEditorControl.getValue();
                return data?.ToString() ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }


        private void SelectValueFromSourceColumn(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            NosaAccountingColumnSelectorForm form = _provider.GetRequiredService<NosaAccountingColumnSelectorForm>();
            form._baseControl = sender as BaseControl;
            form.Columns = Columns;
            FormHelper.ShowMdiForm(form, this, false);
        }


        private async void sbeAddLine_Click(object sender, EventArgs e)
        {
            var newArticle = Share.Tools.XmlHelper.BuildVoucherLine(accountCode: txeAccountCode.Text, lineDescription: mmeLineDescription.Text, debit: txeDebit.Text, credit: txeCredit.Text);
            await this.xmlEditorControl.InsertContentInsideLinesAsync(newArticle);
        }
        private async void sbeAddHeader_Click(object sender, EventArgs e)
        {
            await this.xmlEditorControl.ClearEditorAsync();
            var headerBegin = Share.Tools.XmlHelper.BuildVoucherXmlWithoutLines(number: txeVoucherNumber.Text, date: txeDate.Text, description: txeDescription.Text, currency: txeCurrency.Text);
            var headerEnd = Share.Tools.XmlHelper.CloseVoucherXml();
            await this.xmlEditorControl.InsertTextToEditor($"{headerBegin} {Environment.NewLine} {headerEnd}");

        }

        private async void tpcXMLHTml_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            var xmlData = await GetXmlDataAsync();
            await this.HtmlEditorControl.LoadXmlToHTML(xmlData);
        }


    }
}