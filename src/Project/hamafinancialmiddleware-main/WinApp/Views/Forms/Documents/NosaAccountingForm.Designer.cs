using Hama.WinApp.Views.Components;
using System.Drawing;
using System.Windows.Forms;

namespace Hama.WinApp.Views.Forms.Documents
{
    partial class NosaAccountingForm
    {
        private CustomGridControl customGridControl1;

        private void InitializeComponent()
        {
            customGridControl1 = new CustomGridControl();
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            sbeAddDocumentPattern = new DevExpress.XtraEditors.SimpleButton();
            luePatternId = new DevExpress.XtraEditors.SearchLookUpEdit();
            searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            lciPatternId = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)dxError).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)luePatternId.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchLookUpEdit1View).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciPatternId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            SuspendLayout();
            // 
            // alertControl1
            // 
            alertControl1.AppearanceCaption.Font = new Font("B Titr", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 178);
            alertControl1.AppearanceCaption.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Warning;
            alertControl1.AppearanceCaption.Options.UseFont = true;
            alertControl1.AppearanceCaption.Options.UseForeColor = true;
            alertControl1.AppearanceCaption.Options.UseTextOptions = true;
            alertControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            alertControl1.AppearanceText.Font = new Font("B Nazanin", 12F, FontStyle.Bold, GraphicsUnit.Point, 178);
            alertControl1.AppearanceText.ForeColor = Color.FromArgb(0, 0, 0, 0);
            alertControl1.AppearanceText.Options.UseFont = true;
            alertControl1.AppearanceText.Options.UseForeColor = true;
            alertControl1.AppearanceText.Options.UseTextOptions = true;
            alertControl1.AppearanceText.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            alertControl1.AppearanceText.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            alertControl1.AppearanceText.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            // 
            // customGridControl1
            // 
            customGridControl1.Location = new Point(24, 71);
            customGridControl1.Name = "customGridControl1";
            customGridControl1.RightToLeft = RightToLeft.Yes;
            customGridControl1.Size = new Size(752, 452);
            customGridControl1.TabIndex = 0;
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(customGridControl1);
            layoutControl1.Controls.Add(sbeAddDocumentPattern);
            layoutControl1.Controls.Add(luePatternId);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new Point(0, 53);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            layoutControl1.Root = Root;
            layoutControl1.Size = new Size(800, 547);
            layoutControl1.TabIndex = 1;
            layoutControl1.Text = "الگوی ثبت در حسابداری";
            // 
            // sbeAddDocumentPattern
            // 
            sbeAddDocumentPattern.Location = new Point(24, 45);
            sbeAddDocumentPattern.Name = "sbeAddDocumentPattern";
            sbeAddDocumentPattern.Size = new Size(129, 22);
            sbeAddDocumentPattern.StyleController = layoutControl1;
            sbeAddDocumentPattern.TabIndex = 5;
            sbeAddDocumentPattern.Text = "ساخت الگوی جدید";
            sbeAddDocumentPattern.Click += sbeAddDocumentPattern_Click;
            // 
            // luePatternId
            // 
            luePatternId.Location = new Point(157, 45);
            luePatternId.MenuManager = barManager1;
            luePatternId.Name = "luePatternId";
            luePatternId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            luePatternId.Properties.PopupView = searchLookUpEdit1View;
            luePatternId.Size = new Size(572, 20);
            luePatternId.StyleController = layoutControl1;
            luePatternId.TabIndex = 0;
            // 
            // searchLookUpEdit1View
            // 
            searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlGroup1 });
            Root.Name = "Root";
            Root.Size = new Size(800, 547);
            Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lciPatternId, layoutControlItem1, layoutControlItem2 });
            layoutControlGroup1.Location = new Point(0, 0);
            layoutControlGroup1.Name = "layoutControlGroup1";
            layoutControlGroup1.Size = new Size(780, 527);
            layoutControlGroup1.Text = "الگوی ثبت در حسابداری";
            // 
            // lciPatternId
            // 
            lciPatternId.Control = luePatternId;
            lciPatternId.Location = new Point(133, 0);
            lciPatternId.Name = "lciPatternId";
            lciPatternId.Size = new Size(623, 26);
            lciPatternId.Text = "نوع الگو";
            lciPatternId.TextSize = new Size(35, 13);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = sbeAddDocumentPattern;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(133, 26);
            layoutControlItem1.TextSize = new Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = customGridControl1;
            layoutControlItem2.Location = new Point(0, 26);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(756, 456);
            layoutControlItem2.TextSize = new Size(0, 0);
            layoutControlItem2.TextVisible = false;
            // 
            // NosaAccountingForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(layoutControl1);
            Name = "NosaAccountingForm";
            Text = "ثبت سند در نوسا - بیمه درمان";
            Controls.SetChildIndex(layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)dxError).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)luePatternId.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchLookUpEdit1View).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciPatternId).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem lciPatternId;
        private DevExpress.XtraEditors.SimpleButton sbeAddDocumentPattern;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        public DevExpress.XtraEditors.SearchLookUpEdit luePatternId;
    }
}
