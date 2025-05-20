using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid.ViewInfo;
using DevExpress.XtraRichEdit.API.Native;
using Hama.WinApp.Helpers.UI.Fillers;
using Hama.WinApp.Helpers.UI.Grid;
using Hama.WinApp.Helpers.UI.Loading;
using Hama.WinApp.Helpers.UI.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hama.WinApp.Views.Forms.Documents
{
    public partial class NosaAccountingColumnSelectorForm : BaseForm
    {
        public ColumnProperty[] Columns { get; set; } = Array.Empty<ColumnProperty>();
        public DevExpress.XtraEditors.BaseControl _baseControl { get; set; }

        public NosaAccountingColumnSelectorForm()
        {
            InitializeComponent();

            _visibleBarItems = new[]
            {
                barButtonItemSave,
            };
            InitializeBarItemVisible(_visibleBarItems);
        }

        public async override Task ClearForm()
        {
            this.lueColumnType.EditValue = "Normal";
            await base.ClearForm();
        }
        public async override Task InitializeList()
        {
            await FillerHelper.SetData(lbcColumns, Columns.OrderBy(a => a.Name), nameof(ColumnProperty.Name), nameof(ColumnProperty.Name), nameof(ColumnProperty.Name));

            // پر کردن لیست عملگرها
            var operators = new List<string>
            {
                "Normal",
                "Average",
                "Max",
                "Min",
                "Sum",
                "Count"
            };

            lueColumnType.Properties.DataSource = operators;
            lueColumnType.Properties.NullText = "[انتخاب نوع عملگر]";
            lueColumnType.Properties.ShowHeader = false;


            await base.InitializeList();
        }
        public async override Task InitializeForm()
        {

            var copyButton = new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                ImageOptions = { SvgImage = SVGHelper.GetSVGImage(SVGHelper.enumSVGDevExpress.SVG_actions_copy) }, // اگر آیکون اختصاصی داری
                ToolTip = "ذخیره در کلیبورد"
            };
            var insertButton = new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                ImageOptions = { SvgImage = SVGHelper.GetSVGImage(SVGHelper.enumSVGDevExpress.SVG_actions_add) }, // اگر آیکون اختصاصی داری
                ToolTip = "اضافه به کلیبورد"
            };

            txeColumnValue.Properties.Buttons.Clear();
            txeColumnValue.Properties.Buttons.Add(copyButton);// index 0
            txeColumnValue.Properties.Buttons.Add(insertButton); // index 1
            txeColumnValue.Properties.ButtonClick += txeColumnValue_ButtonClick;
            txeColumnValue.Properties.DoubleClick += Properties_DoubleClick;
            lbcColumns.DoubleClick += lbcColumns_DoubleClick;

            await base.InitializeForm();
        }
        public async override Task ActionSave()
        {
            _baseControl.Text = txeColumnValue.Text;
            await base.ActionSave();
            this.Close();
        }

        private void CopyValue()
        {
            if (!string.IsNullOrEmpty(txeColumnValue.Text))
            {
                Clipboard.SetText(txeColumnValue.Text);
                AlertHelper.ShowInformation(this, "مقدار در کلیبورد ذخیره شد!");
            }
        }

        private async void txeColumnValue_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
                CopyValue();
            else
                await ActionSave();
        }
        private async void Properties_DoubleClick(object sender, EventArgs e)
        {
            await ActionSave();
        }
        private void lbcColumns_DoubleClick(object sender, EventArgs e)
        {
            if (lbcColumns.SelectedItem is ColumnProperty selectedColumn)
            {
                var columnName = selectedColumn.Name;
                var columnType = lueColumnType.EditValue?.ToString() ?? "Normal";

                txeColumnValue.Text = $"[{columnType}({columnName})]";
            }
        }
    }
}
