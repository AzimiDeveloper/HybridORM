using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using Hama.WinApp.Views.Components;
using System.Windows.Forms;

namespace Hama.WinApp.Views.Forms.Users
{
    partial class PermissionsForm
    {
        private System.ComponentModel.IContainer components = null;
        private SplitContainerControl sccCrud;
        private LayoutControl layoutControl1;
        private TextEdit txeName;
        private MemoEdit txeDescription;
        private LayoutControlGroup layoutControlGroup1;
        private LayoutControlItem lciName;
        private LayoutControlItem lciDescription;
        private TabPane tabPane1;
        private TabNavigationPage tnpPermissions;
        private CustomGridControl customGridControl1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            sccCrud = new SplitContainerControl();
            layoutControl1 = new LayoutControl();
            txeName = new TextEdit();
            txeDescription = new MemoEdit();
            layoutControlGroup1 = new LayoutControlGroup();
            lciName = new LayoutControlItem();
            lciDescription = new LayoutControlItem();
            tabPane1 = new TabPane();
            tnpPermissions = new TabNavigationPage();
            customGridControl1 = new CustomGridControl();
            sleParentId = new SearchLookUpEdit();
            lciParentId = new LayoutControlItem();
            searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)dxError).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sccCrud).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sccCrud.Panel1).BeginInit();
            sccCrud.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sccCrud.Panel2).BeginInit();
            sccCrud.Panel2.SuspendLayout();
            sccCrud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txeName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txeDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabPane1).BeginInit();
            tabPane1.SuspendLayout();
            tnpPermissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sleParentId.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciParentId).BeginInit();
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
            // sccCrud
            // 
            sccCrud.Dock = DockStyle.Fill;
            sccCrud.Location = new System.Drawing.Point(0, 24);
            sccCrud.Name = "sccCrud";
            // 
            // sccCrud.Panel1
            // 
            sccCrud.Panel1.Controls.Add(layoutControl1);
            // 
            // sccCrud.Panel2
            // 
            sccCrud.Panel2.Controls.Add(tabPane1);
            sccCrud.Size = new System.Drawing.Size(1051, 541);
            sccCrud.SplitterPosition = 231;
            sccCrud.TabIndex = 4;
            // 
            // layoutControl1
            // 
            layoutControl1.Controls.Add(sleParentId);
            layoutControl1.Controls.Add(txeName);
            layoutControl1.Controls.Add(txeDescription);
            layoutControl1.Dock = DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 0);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            layoutControl1.Root = layoutControlGroup1;
            layoutControl1.Size = new System.Drawing.Size(231, 541);
            layoutControl1.TabIndex = 0;
            // 
            // txeName
            // 
            txeName.Location = new System.Drawing.Point(12, 89);
            txeName.Name = "txeName";
            txeName.Properties.MaxLength = 100;
            txeName.Size = new System.Drawing.Size(207, 20);
            txeName.StyleController = layoutControl1;
            txeName.TabIndex = 4;
            // 
            // txeDescription
            // 
            txeDescription.Location = new System.Drawing.Point(12, 129);
            txeDescription.Name = "txeDescription";
            txeDescription.Properties.MaxLength = 250;
            txeDescription.Size = new System.Drawing.Size(207, 400);
            txeDescription.StyleController = layoutControl1;
            txeDescription.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            layoutControlGroup1.Items.AddRange(new BaseLayoutItem[] { lciName, lciDescription, lciParentId });
            layoutControlGroup1.Name = "layoutControlGroup1";
            layoutControlGroup1.Size = new System.Drawing.Size(231, 541);
            layoutControlGroup1.Text = "منابع دسترسی";
            // 
            // lciName
            // 
            lciName.Control = txeName;
            lciName.Location = new System.Drawing.Point(0, 40);
            lciName.Name = "lciName";
            lciName.Size = new System.Drawing.Size(211, 40);
            lciName.Text = "نام دسترسی";
            lciName.TextLocation = DevExpress.Utils.Locations.Top;
            lciName.TextSize = new System.Drawing.Size(63, 13);
            // 
            // lciDescription
            // 
            lciDescription.Control = txeDescription;
            lciDescription.Location = new System.Drawing.Point(0, 80);
            lciDescription.Name = "lciDescription";
            lciDescription.Size = new System.Drawing.Size(211, 420);
            lciDescription.Text = "توضیحات";
            lciDescription.TextLocation = DevExpress.Utils.Locations.Top;
            lciDescription.TextSize = new System.Drawing.Size(63, 13);
            // 
            // tabPane1
            // 
            tabPane1.Controls.Add(tnpPermissions);
            tabPane1.Dock = DockStyle.Fill;
            tabPane1.Location = new System.Drawing.Point(0, 0);
            tabPane1.Name = "tabPane1";
            tabPane1.Pages.AddRange(new NavigationPageBase[] { tnpPermissions });
            tabPane1.RegularSize = new System.Drawing.Size(810, 541);
            tabPane1.SelectedPage = tnpPermissions;
            tabPane1.Size = new System.Drawing.Size(810, 541);
            tabPane1.TabIndex = 0;
            // 
            // tnpPermissions
            // 
            tnpPermissions.Caption = "دسترسی‌ها";
            tnpPermissions.Controls.Add(customGridControl1);
            tnpPermissions.Name = "tnpPermissions";
            tnpPermissions.Size = new System.Drawing.Size(810, 508);
            // 
            // customGridControl1
            // 
            customGridControl1.Dock = DockStyle.Fill;
            customGridControl1.Location = new System.Drawing.Point(0, 0);
            customGridControl1.Name = "customGridControl1";
            customGridControl1.RightToLeft = RightToLeft.Yes;
            customGridControl1.Size = new System.Drawing.Size(810, 508);
            customGridControl1.TabIndex = 0;
            // 
            // sleParentId
            // 
            sleParentId.Location = new System.Drawing.Point(12, 49);
            sleParentId.MenuManager = barManager1;
            sleParentId.Name = "sleParentId";
            sleParentId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            sleParentId.Properties.PopupView = searchLookUpEdit1View;
            sleParentId.Size = new System.Drawing.Size(207, 20);
            sleParentId.StyleController = layoutControl1;
            sleParentId.TabIndex = 6;
            // 
            // lciParentId
            // 
            lciParentId.Control = sleParentId;
            lciParentId.Location = new System.Drawing.Point(0, 0);
            lciParentId.Name = "lciParentId";
            lciParentId.Size = new System.Drawing.Size(211, 40);
            lciParentId.Text = "والد";
            lciParentId.TextLocation = DevExpress.Utils.Locations.Top;
            lciParentId.TextSize = new System.Drawing.Size(63, 13);
            // 
            // searchLookUpEdit1View
            // 
            searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // PermissionsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            ClientSize = new System.Drawing.Size(1051, 589);
            Controls.Add(sccCrud);
            Name = "PermissionsForm";
            Text = "مدیریت دسترسی‌ها";
            Controls.SetChildIndex(sccCrud, 0);
            ((System.ComponentModel.ISupportInitialize)dxError).EndInit();
            ((System.ComponentModel.ISupportInitialize)sccCrud.Panel1).EndInit();
            sccCrud.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sccCrud.Panel2).EndInit();
            sccCrud.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sccCrud).EndInit();
            sccCrud.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txeName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txeDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciName).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabPane1).EndInit();
            tabPane1.ResumeLayout(false);
            tnpPermissions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sleParentId.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciParentId).EndInit();
            ((System.ComponentModel.ISupportInitialize)searchLookUpEdit1View).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private SearchLookUpEdit sleParentId;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private LayoutControlItem lciParentId;
    }
}
