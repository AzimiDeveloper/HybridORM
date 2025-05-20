using Hama.WinApp.Views.Components;

namespace Hama.WinApp.Views.Forms.Documents
{
    partial class DocumentPatternForm
    {
        private DevExpress.XtraEditors.TextEdit txeTitle;
        private DevExpress.XtraEditors.SplitContainerControl sccMain;
        private DevExpress.XtraLayout.LayoutControl layoutControlForm;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupForm;
        private DevExpress.XtraLayout.LayoutControlItem lciTitle;
        private CustomGridControl customGridControl1;

        private void InitializeComponent()
        {
            sccMain = new DevExpress.XtraEditors.SplitContainerControl();
            layoutControlForm = new DevExpress.XtraLayout.LayoutControl();
            txeTitle = new DevExpress.XtraEditors.TextEdit();
            layoutControlGroupForm = new DevExpress.XtraLayout.LayoutControlGroup();
            lciTitle = new DevExpress.XtraLayout.LayoutControlItem();
            customGridControl1 = new CustomGridControl();
            mmeContent = new DevExpress.XtraEditors.MemoEdit();
            lciContent = new DevExpress.XtraLayout.LayoutControlItem();
            tgsIsActive = new DevExpress.XtraEditors.ToggleSwitch();
            lciIsActive = new DevExpress.XtraLayout.LayoutControlItem();
            lueCategoryId = new DevExpress.XtraEditors.SearchLookUpEdit();
            lciCategoryId = new DevExpress.XtraLayout.LayoutControlItem();
            searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)dxError).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sccMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sccMain.Panel1).BeginInit();
            sccMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sccMain.Panel2).BeginInit();
            sccMain.Panel2.SuspendLayout();
            sccMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControlForm).BeginInit();
            layoutControlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txeTitle.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupForm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciTitle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mmeContent.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciContent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tgsIsActive.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciIsActive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueCategoryId.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciCategoryId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)searchLookUpEdit1View).BeginInit();
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
            sccMain.SplitterPosition = 342;
            sccMain.TabIndex = 0;
            // 
            // layoutControlForm
            // 
            layoutControlForm.Controls.Add(lueCategoryId);
            layoutControlForm.Controls.Add(tgsIsActive);
            layoutControlForm.Controls.Add(txeTitle);
            layoutControlForm.Controls.Add(mmeContent);
            layoutControlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlForm.Location = new System.Drawing.Point(0, 0);
            layoutControlForm.Name = "layoutControlForm";
            layoutControlForm.OptionsView.RightToLeftMirroringApplied = true;
            layoutControlForm.Root = layoutControlGroupForm;
            layoutControlForm.Size = new System.Drawing.Size(342, 512);
            layoutControlForm.TabIndex = 1;
            // 
            // txeTitle
            // 
            txeTitle.Location = new System.Drawing.Point(12, 51);
            txeTitle.Name = "txeTitle";
            txeTitle.Properties.MaxLength = 100;
            txeTitle.Size = new System.Drawing.Size(318, 20);
            txeTitle.StyleController = layoutControlForm;
            txeTitle.TabIndex = 0;
            // 
            // layoutControlGroupForm
            // 
            layoutControlGroupForm.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroupForm.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lciTitle, lciContent, lciCategoryId, lciIsActive });
            layoutControlGroupForm.Name = "layoutControlGroupForm";
            layoutControlGroupForm.Size = new System.Drawing.Size(342, 512);
            layoutControlGroupForm.Text = "مدیریت الگو";
            // 
            // lciTitle
            // 
            lciTitle.Control = txeTitle;
            lciTitle.Location = new System.Drawing.Point(0, 0);
            lciTitle.Name = "lciTitle";
            lciTitle.Size = new System.Drawing.Size(322, 42);
            lciTitle.Text = "عنوان ";
            lciTitle.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            lciTitle.TextLocation = DevExpress.Utils.Locations.Top;
            lciTitle.TextSize = new System.Drawing.Size(29, 13);
            lciTitle.TextToControlDistance = 5;
            // 
            // customGridControl1
            // 
            customGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            customGridControl1.Location = new System.Drawing.Point(0, 0);
            customGridControl1.Name = "customGridControl1";
            customGridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            customGridControl1.Size = new System.Drawing.Size(430, 512);
            customGridControl1.TabIndex = 1;
            // 
            // mmeContent
            // 
            mmeContent.Location = new System.Drawing.Point(12, 178);
            mmeContent.MenuManager = barManager1;
            mmeContent.Name = "mmeContent";
            mmeContent.Size = new System.Drawing.Size(318, 322);
            mmeContent.StyleController = layoutControlForm;
            mmeContent.TabIndex = 4;
            // 
            // lciContent
            // 
            lciContent.Control = mmeContent;
            lciContent.Location = new System.Drawing.Point(0, 129);
            lciContent.Name = "lciContent";
            lciContent.Size = new System.Drawing.Size(322, 342);
            lciContent.Text = "محتوی سند";
            lciContent.TextLocation = DevExpress.Utils.Locations.Top;
            lciContent.TextSize = new System.Drawing.Size(56, 13);
            // 
            // tgsIsActive
            // 
            tgsIsActive.Location = new System.Drawing.Point(12, 140);
            tgsIsActive.MenuManager = barManager1;
            tgsIsActive.Name = "tgsIsActive";
            tgsIsActive.Properties.OffText = "Off";
            tgsIsActive.Properties.OnText = "On";
            tgsIsActive.Size = new System.Drawing.Size(318, 18);
            tgsIsActive.StyleController = layoutControlForm;
            tgsIsActive.TabIndex = 5;
            // 
            // lciIsActive
            // 
            lciIsActive.Control = tgsIsActive;
            lciIsActive.Location = new System.Drawing.Point(0, 91);
            lciIsActive.Name = "lciIsActive";
            lciIsActive.Size = new System.Drawing.Size(322, 38);
            lciIsActive.Text = "وضعیت";
            lciIsActive.TextLocation = DevExpress.Utils.Locations.Top;
            lciIsActive.TextSize = new System.Drawing.Size(56, 13);
            // 
            // lueCategoryId
            // 
            lueCategoryId.Location = new System.Drawing.Point(12, 100);
            lueCategoryId.MenuManager = barManager1;
            lueCategoryId.Name = "lueCategoryId";
            lueCategoryId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lueCategoryId.Properties.PopupView = searchLookUpEdit1View;
            lueCategoryId.Size = new System.Drawing.Size(318, 20);
            lueCategoryId.StyleController = layoutControlForm;
            lueCategoryId.TabIndex = 6;
            // 
            // lciCategoryId
            // 
            lciCategoryId.Control = lueCategoryId;
            lciCategoryId.Location = new System.Drawing.Point(0, 42);
            lciCategoryId.Name = "lciCategoryId";
            lciCategoryId.Size = new System.Drawing.Size(322, 49);
            lciCategoryId.Text = "دسته بندی";
            lciCategoryId.TextLocation = DevExpress.Utils.Locations.Top;
            lciCategoryId.TextSize = new System.Drawing.Size(56, 13);
            // 
            // searchLookUpEdit1View
            // 
            searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // DocumentPatternForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            ClientSize = new System.Drawing.Size(782, 589);
            Controls.Add(sccMain);
            Name = "DocumentPatternForm";
            Text = "مدیریت الگوی سند";
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
            ((System.ComponentModel.ISupportInitialize)txeTitle.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupForm).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciTitle).EndInit();
            ((System.ComponentModel.ISupportInitialize)mmeContent.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciContent).EndInit();
            ((System.ComponentModel.ISupportInitialize)tgsIsActive.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciIsActive).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueCategoryId.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciCategoryId).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchLookUpEdit1View).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private DevExpress.XtraEditors.MemoEdit mmeContent;
        private DevExpress.XtraLayout.LayoutControlItem lciContent;
        private DevExpress.XtraEditors.SearchLookUpEdit lueCategoryId;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.ToggleSwitch tgsIsActive;
        private DevExpress.XtraLayout.LayoutControlItem lciCategoryId;
        private DevExpress.XtraLayout.LayoutControlItem lciIsActive;
    }
}
