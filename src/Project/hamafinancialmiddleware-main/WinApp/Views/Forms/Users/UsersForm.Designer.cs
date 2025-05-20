using Hama.WinApp.Views.Components;

namespace Hama.WinApp.Views.Forms.Users
{
    partial class UsersForm
    {
        private DevExpress.XtraEditors.TextEdit txeUserName;
        private DevExpress.XtraEditors.TextEdit txeFirstName;
        private DevExpress.XtraEditors.TextEdit txeLastName;
        private DevExpress.XtraEditors.TextEdit txePassword;
        private DevExpress.XtraEditors.ToggleSwitch tglIsActive;
        private CustomGridControl customGridControl1;
        private DevExpress.XtraEditors.SplitContainerControl sccMain;
        private DevExpress.XtraLayout.LayoutControl layoutControlForm;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupForm;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemUserName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemFirstName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemLastName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemPassword;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemIsActive;

        private void InitializeComponent()
        {
            sccMain = new DevExpress.XtraEditors.SplitContainerControl();
            layoutControlForm = new DevExpress.XtraLayout.LayoutControl();
            txeUserName = new DevExpress.XtraEditors.TextEdit();
            txeFirstName = new DevExpress.XtraEditors.TextEdit();
            txeLastName = new DevExpress.XtraEditors.TextEdit();
            txePassword = new DevExpress.XtraEditors.TextEdit();
            tglIsActive = new DevExpress.XtraEditors.ToggleSwitch();
            layoutControlGroupForm = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItemUserName = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemFirstName = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemLastName = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemPassword = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemIsActive = new DevExpress.XtraLayout.LayoutControlItem();
            customGridControl1 = new  CustomGridControl();
            ((System.ComponentModel.ISupportInitialize)dxError).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sccMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sccMain.Panel1).BeginInit();
            sccMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sccMain.Panel2).BeginInit();
            sccMain.Panel2.SuspendLayout();
            sccMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)layoutControlForm).BeginInit();
            layoutControlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txeUserName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txeFirstName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txeLastName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txePassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tglIsActive.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupForm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemUserName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemFirstName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemLastName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemIsActive).BeginInit();
            SuspendLayout();
            // 
            // sccMain
            // 
            sccMain.Dock = System.Windows.Forms.DockStyle.Fill;
            sccMain.Location = new System.Drawing.Point(0, 24);
            sccMain.Name = "sccMain";
            sccMain.Panel1.Controls.Add(layoutControlForm);
            sccMain.Panel2.Controls.Add(customGridControl1);
            sccMain.Size = new System.Drawing.Size(1051, 541);
            sccMain.SplitterPosition = 235;
            sccMain.TabIndex = 0;
            // 
            // layoutControlForm
            // 
            layoutControlForm.Controls.Add(txeUserName);
            layoutControlForm.Controls.Add(txeFirstName);
            layoutControlForm.Controls.Add(txeLastName);
            layoutControlForm.Controls.Add(txePassword);
            layoutControlForm.Controls.Add(tglIsActive);
            layoutControlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControlForm.Location = new System.Drawing.Point(0, 0);
            layoutControlForm.Name = "layoutControlForm";
            layoutControlForm.OptionsView.RightToLeftMirroringApplied = true;
            layoutControlForm.Root = layoutControlGroupForm;
            layoutControlForm.Size = new System.Drawing.Size(235, 541);
            layoutControlForm.TabIndex = 1;
            layoutControlForm.Text = "layoutControlForm";
            // 
            // txeUserName
            // 
            txeUserName.Location = new System.Drawing.Point(12, 51);
            txeUserName.Name = "txeUserName";
            txeUserName.Properties.MaxLength = 100;
            txeUserName.Size = new System.Drawing.Size(211, 20);
            txeUserName.StyleController = layoutControlForm;
            txeUserName.TabIndex = 0;
            // 
            // txeFirstName
            // 
            txeFirstName.Location = new System.Drawing.Point(12, 93);
            txeFirstName.Name = "txeFirstName";
            txeFirstName.Properties.MaxLength = 50;
            txeFirstName.Size = new System.Drawing.Size(211, 20);
            txeFirstName.StyleController = layoutControlForm;
            txeFirstName.TabIndex = 1;
            // 
            // txeLastName
            // 
            txeLastName.Location = new System.Drawing.Point(12, 135);
            txeLastName.Name = "txeLastName";
            txeLastName.Properties.MaxLength = 50;
            txeLastName.Size = new System.Drawing.Size(211, 20);
            txeLastName.StyleController = layoutControlForm;
            txeLastName.TabIndex = 2;
            // 
            // txePassword
            // 
            txePassword.Location = new System.Drawing.Point(12, 177);
            txePassword.Name = "txePassword";
            txePassword.Properties.MaxLength = 256;
            txePassword.Properties.UseSystemPasswordChar = true;
            txePassword.Size = new System.Drawing.Size(211, 20);
            txePassword.StyleController = layoutControlForm;
            txePassword.TabIndex = 3;
            // 
            // tglIsActive
            // 
            tglIsActive.Location = new System.Drawing.Point(12, 219);
            tglIsActive.Name = "tglIsActive";
            tglIsActive.Properties.OffText = "غیرفعال";
            tglIsActive.Properties.OnText = "فعال";
            tglIsActive.Size = new System.Drawing.Size(211, 18);
            tglIsActive.StyleController = layoutControlForm;
            tglIsActive.TabIndex = 4;
            // 
            // layoutControlGroupForm
            // 
            layoutControlGroupForm.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroupForm.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
                layoutControlItemUserName,
                layoutControlItemFirstName,
                layoutControlItemLastName,
                layoutControlItemPassword,
                layoutControlItemIsActive});
            layoutControlGroupForm.Name = "layoutControlGroupForm";
            layoutControlGroupForm.Size = new System.Drawing.Size(235, 541);
            layoutControlGroupForm.Text = "مدیریت کاربران";
            // 
            // layoutControlItemUserName
            // 
            layoutControlItemUserName.Control = txeUserName;
            layoutControlItemUserName.Location = new System.Drawing.Point(0, 0);
            layoutControlItemUserName.Text = "نام کاربری";
            layoutControlItemUserName.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItemUserName.TextSize = new System.Drawing.Size(46, 13);
            // 
            // layoutControlItemFirstName
            // 
            layoutControlItemFirstName.Control = txeFirstName;
            layoutControlItemFirstName.Location = new System.Drawing.Point(0, 42);
            layoutControlItemFirstName.Text = "نام";
            layoutControlItemFirstName.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItemFirstName.TextSize = new System.Drawing.Size(13, 13);
            // 
            // layoutControlItemLastName
            // 
            layoutControlItemLastName.Control = txeLastName;
            layoutControlItemLastName.Location = new System.Drawing.Point(0, 84);
            layoutControlItemLastName.Text = "نام خانوادگی";
            layoutControlItemLastName.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItemLastName.TextSize = new System.Drawing.Size(58, 13);
            // 
            // layoutControlItemPassword
            // 
            layoutControlItemPassword.Control = txePassword;
            layoutControlItemPassword.Location = new System.Drawing.Point(0, 126);
            layoutControlItemPassword.Text = "رمز عبور";
            layoutControlItemPassword.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItemPassword.TextSize = new System.Drawing.Size(47, 13);
            // 
            // layoutControlItemIsActive
            // 
            layoutControlItemIsActive.Control = tglIsActive;
            layoutControlItemIsActive.Location = new System.Drawing.Point(0, 168);
            layoutControlItemIsActive.Text = "وضعیت";
            layoutControlItemIsActive.TextLocation = DevExpress.Utils.Locations.Top;
            layoutControlItemIsActive.TextSize = new System.Drawing.Size(34, 13);
            // 
            // customGridControl1
            // 
            customGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            customGridControl1.Location = new System.Drawing.Point(0, 0);
            customGridControl1.Name = "customGridControl1";
            customGridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            customGridControl1.Size = new System.Drawing.Size(806, 541);
            customGridControl1.TabIndex = 1;
            // 
            // UsersForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            ClientSize = new System.Drawing.Size(1051, 589);
            Controls.Add(sccMain);
            Name = "UsersForm";
            Text = "تعریف کاربران";
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
            ((System.ComponentModel.ISupportInitialize)txeUserName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txeFirstName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txeLastName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txePassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tglIsActive.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlGroupForm).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemUserName).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemFirstName).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemLastName).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemIsActive).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
