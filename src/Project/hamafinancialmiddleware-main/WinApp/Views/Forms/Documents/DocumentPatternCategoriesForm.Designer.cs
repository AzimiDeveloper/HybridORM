using Hama.WinApp.Views.Components;

namespace Hama.WinApp.Views.Forms.DocumentPatterns
{
    partial class DocumentPatternCategoriesForm
    {
        private DevExpress.XtraEditors.TextEdit txeName;
        private DevExpress.XtraEditors.SplitContainerControl sccMain;
        private DevExpress.XtraLayout.LayoutControl layoutControlForm;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupForm;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemName;
        private CustomGridControl customGridControl1;

        private void InitializeComponent()
        {
            sccMain = new DevExpress.XtraEditors.SplitContainerControl();
            layoutControlForm = new DevExpress.XtraLayout.LayoutControl();
            txeName = new DevExpress.XtraEditors.TextEdit();
            layoutControlGroupForm = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItemName = new DevExpress.XtraLayout.LayoutControlItem();
            customGridControl1 = new CustomGridControl();
            ((System.ComponentModel.ISupportInitialize)dxError).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sccMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sccMain.Panel1).BeginInit();
            sccMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sccMain.Panel2).BeginInit();
            sccMain.Panel2.SuspendLayout();
            sccMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControlForm).BeginInit();
            layoutControlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txeName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupForm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemName).BeginInit();
            SuspendLayout();
            // 
            // alertControl1
            // 
            alertControl1.AppearanceCaption.Font = new System.Drawing.Font("B Titr", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 178);
            alertControl1.AppearanceCaption.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Warning;
            alertControl1.AppearanceCaption.Options.UseFont = true;
            alertControl1.AppearanceCaption.Options.UseForeColor = true;
            alertControl1.AppearanceCaption.Options.UseTextOptions = true;
            alertControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            alertControl1.AppearanceText.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 178);
            alertControl1.AppearanceText.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
            alertControl1.AppearanceText.Options.UseFont = true;
            alertControl1.AppearanceText.Options.UseForeColor = true;
            alertControl1.AppearanceText.Options.UseTextOptions = true;
            alertControl1.AppearanceText.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            alertControl1.AppearanceText.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            alertControl1.AppearanceText.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            // 
            // sccMain
            // 
            sccMain.Dock = System.Windows.Forms.DockStyle.Fill;
            sccMain.Location = new System.Drawing.Point(0, 53);
            sccMain.Name = "sccMain";
            // 
            // sccMain.Panel1
            // 
            sccMain.Panel1.Controls.Add(layoutControlForm);
            // 
            // sccMain.Panel2
            // 
            sccMain.Panel2.Controls.Add(customGridControl1);
            sccMain.Size = new System.Drawing.Size(782, 512);
            sccMain.SplitterPosition = 250;
            sccMain.TabIndex = 0;
            // 
            // layoutControlForm
            // 
            layoutControlForm.Controls.Add(txeName);
            layoutControlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlForm.Location = new System.Drawing.Point(0, 0);
            layoutControlForm.Name = "layoutControlForm";
            layoutControlForm.OptionsView.RightToLeftMirroringApplied = true;
            layoutControlForm.Root = layoutControlGroupForm;
            layoutControlForm.Size = new System.Drawing.Size(250, 512);
            layoutControlForm.TabIndex = 1;
            // 
            // txeName
            // 
            txeName.Location = new System.Drawing.Point(12, 51);
            txeName.Name = "txeName";
            txeName.Properties.MaxLength = 100;
            txeName.Size = new System.Drawing.Size(226, 20);
            txeName.StyleController = layoutControlForm;
            txeName.TabIndex = 0;
            // 
            // layoutControlGroupForm
            // 
            layoutControlGroupForm.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroupForm.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItemName });
            layoutControlGroupForm.Name = "layoutControlGroupForm";
            layoutControlGroupForm.Size = new System.Drawing.Size(250, 512);
            layoutControlGroupForm.Text = "اطلاعات دسته‌بندی الگو";
            // 
            // layoutControlItemName
            // 
            layoutControlItemName.Control = txeName;
            layoutControlItemName.Location = new System.Drawing.Point(0, 0);
            layoutControlItemName.Name = "layoutControlItemName";
            layoutControlItemName.Size = new System.Drawing.Size(230, 471);
            layoutControlItemName.Text = "عنوان دسته‌بندی";
            layoutControlItemName.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            layoutControlItemName.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItemName.TextSize = new System.Drawing.Size(78, 13);
            layoutControlItemName.TextToControlDistance = 5;
            // 
            // customGridControl1
            // 
            customGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            customGridControl1.Location = new System.Drawing.Point(0, 0);
            customGridControl1.Name = "customGridControl1";
            customGridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            customGridControl1.Size = new System.Drawing.Size(522, 512);
            customGridControl1.TabIndex = 1;
            // 
            // DocumentPatternCategoriesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            ClientSize = new System.Drawing.Size(782, 589);
            Controls.Add(sccMain);
            Name = "DocumentPatternCategoriesForm";
            Text = "تعریف دسته‌بندی الگوی سند";
            Controls.SetChildIndex(sccMain, 0);
            ((System.ComponentModel.ISupportInitialize)dxError).EndInit();
            ((System.ComponentModel.ISupportInitialize)sccMain.Panel1).EndInit();
            sccMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sccMain.Panel2).EndInit();
            sccMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sccMain).EndInit();
            sccMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControlForm).EndInit();
            layoutControlForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txeName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupForm).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemName).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
