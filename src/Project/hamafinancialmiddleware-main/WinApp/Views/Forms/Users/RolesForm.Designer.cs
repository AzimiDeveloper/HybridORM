using Hama.WinApp.Views.Components;
using System.Windows.Forms;

namespace Hama.WinApp.Views.Forms.Users
{
    partial class RolesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sccMain = new DevExpress.XtraEditors.SplitContainerControl();
            lciCrud = new DevExpress.XtraLayout.LayoutControl();
            txeRoleName = new DevExpress.XtraEditors.TextEdit();
            RootCrud = new DevExpress.XtraLayout.LayoutControlGroup();
            lciRoleName = new DevExpress.XtraLayout.LayoutControlItem();
            esiCrud = new DevExpress.XtraLayout.EmptySpaceItem();
            tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            tnpTraditionalDisplay = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            customGridControl1 = new CustomGridControl();
            tpnGraphicMode = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            ((System.ComponentModel.ISupportInitialize)dxError).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sccMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sccMain.Panel1).BeginInit();
            sccMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sccMain.Panel2).BeginInit();
            sccMain.Panel2.SuspendLayout();
            sccMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lciCrud).BeginInit();
            lciCrud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txeRoleName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RootCrud).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciRoleName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)esiCrud).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabPane1).BeginInit();
            tabPane1.SuspendLayout();
            tnpTraditionalDisplay.SuspendLayout();
            SuspendLayout();
            // 
            // alertControl1
            // 
            alertControl1.AppearanceCaption.Font = new System.Drawing.Font("B Titr", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 178);
            alertControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Yellow;
            alertControl1.AppearanceCaption.Options.UseFont = true;
            alertControl1.AppearanceCaption.Options.UseForeColor = true;
            alertControl1.AppearanceCaption.Options.UseTextOptions = true;
            alertControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            alertControl1.AppearanceText.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 178);
            alertControl1.AppearanceText.ForeColor = System.Drawing.Color.White;
            alertControl1.AppearanceText.Options.UseFont = true;
            alertControl1.AppearanceText.Options.UseForeColor = true;
            alertControl1.AppearanceText.Options.UseTextOptions = true;
            alertControl1.AppearanceText.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            alertControl1.AppearanceText.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            alertControl1.AppearanceText.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            // 
            // sccMain
            // 
            sccMain.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            sccMain.Dock = DockStyle.Fill;
            sccMain.Location = new System.Drawing.Point(0, 53);
            sccMain.Name = "sccMain";
            // 
            // sccMain.Panel1
            // 
            sccMain.Panel1.Controls.Add(lciCrud);
            sccMain.Panel1.Text = "Panel1";
            // 
            // sccMain.Panel2
            // 
            sccMain.Panel2.Controls.Add(tabPane1);
            sccMain.Panel2.Text = "Panel2";
            sccMain.ShowSplitGlyph = DevExpress.Utils.DefaultBoolean.True;
            sccMain.Size = new System.Drawing.Size(911, 595);
            sccMain.SplitterPosition = 233;
            sccMain.TabIndex = 8;
            // 
            // lciCrud
            // 
            lciCrud.Controls.Add(txeRoleName);
            lciCrud.Dock = DockStyle.Fill;
            lciCrud.Location = new System.Drawing.Point(0, 0);
            lciCrud.Name = "lciCrud";
            lciCrud.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(755, 467, 650, 400);
            lciCrud.OptionsView.RightToLeftMirroringApplied = true;
            lciCrud.Root = RootCrud;
            lciCrud.Size = new System.Drawing.Size(233, 595);
            lciCrud.TabIndex = 0;
            lciCrud.Text = "layoutControl1";
            // 
            // txeRoleName
            // 
            txeRoleName.Location = new System.Drawing.Point(12, 49);
            txeRoleName.Name = "txeRoleName";
            txeRoleName.Size = new System.Drawing.Size(209, 20);
            txeRoleName.StyleController = lciCrud;
            txeRoleName.TabIndex = 6;
            // 
            // RootCrud
            // 
            RootCrud.CustomizationFormText = "نقش کاربری";
            RootCrud.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            RootCrud.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lciRoleName, esiCrud });
            RootCrud.Name = "RootCrud";
            RootCrud.Size = new System.Drawing.Size(233, 595);
            RootCrud.Text = "نقش کاربری";
            // 
            // lciRoleName
            // 
            lciRoleName.Control = txeRoleName;
            lciRoleName.Location = new System.Drawing.Point(0, 0);
            lciRoleName.Name = "lciRoleName";
            lciRoleName.Size = new System.Drawing.Size(213, 40);
            lciRoleName.Text = "نام نقش کاربری";
            lciRoleName.TextLocation = DevExpress.Utils.Locations.Top;
            lciRoleName.TextSize = new System.Drawing.Size(72, 13);
            // 
            // esiCrud
            // 
            esiCrud.AllowHotTrack = false;
            esiCrud.Location = new System.Drawing.Point(0, 40);
            esiCrud.Name = "esiCrud";
            esiCrud.Size = new System.Drawing.Size(213, 514);
            esiCrud.TextSize = new System.Drawing.Size(0, 0);
            // 
            // tabPane1
            // 
            tabPane1.Controls.Add(tnpTraditionalDisplay);
            tabPane1.Controls.Add(tpnGraphicMode);
            tabPane1.Dock = DockStyle.Fill;
            tabPane1.Location = new System.Drawing.Point(0, 0);
            tabPane1.Name = "tabPane1";
            tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] { tnpTraditionalDisplay });
            tabPane1.RegularSize = new System.Drawing.Size(668, 595);
            tabPane1.SelectedPage = tnpTraditionalDisplay;
            tabPane1.Size = new System.Drawing.Size(668, 595);
            tabPane1.TabIndex = 0;
            tabPane1.Text = "tabPane1";
            // 
            // tnpTraditionalDisplay
            // 
            tnpTraditionalDisplay.Caption = "اطلاعات";
            tnpTraditionalDisplay.Controls.Add(customGridControl1);
            tnpTraditionalDisplay.Name = "tnpTraditionalDisplay";
            tnpTraditionalDisplay.Size = new System.Drawing.Size(668, 562);
            // 
            // customGridControl1
            // 
            customGridControl1.Dock = DockStyle.Fill;
            customGridControl1.Location = new System.Drawing.Point(0, 0);
            customGridControl1.Name = "customGridControl1";
            customGridControl1.RightToLeft = RightToLeft.Yes;
            customGridControl1.Size = new System.Drawing.Size(668, 562);
            customGridControl1.TabIndex = 0;
            // 
            // tpnGraphicMode
            // 
            tpnGraphicMode.Caption = "tpnGraphicMode";
            tpnGraphicMode.Name = "tpnGraphicMode";
            tpnGraphicMode.Size = new System.Drawing.Size(200, 100);
            // 
            // RolesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(911, 648);
            Controls.Add(sccMain);
            Name = "RolesForm";
            Text = "مدیریت نقش کاربری";
            Controls.SetChildIndex(sccMain, 0);
            ((System.ComponentModel.ISupportInitialize)dxError).EndInit();
            ((System.ComponentModel.ISupportInitialize)sccMain.Panel1).EndInit();
            sccMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sccMain.Panel2).EndInit();
            sccMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sccMain).EndInit();
            sccMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)lciCrud).EndInit();
            lciCrud.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txeRoleName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)RootCrud).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciRoleName).EndInit();
            ((System.ComponentModel.ISupportInitialize)esiCrud).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabPane1).EndInit();
            tabPane1.ResumeLayout(false);
            tnpTraditionalDisplay.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl sccMain;
        private DevExpress.XtraLayout.LayoutControl lciCrud;
        private DevExpress.XtraEditors.TextEdit txeRoleName;
        private DevExpress.XtraLayout.LayoutControlGroup RootCrud;
        private DevExpress.XtraLayout.LayoutControlItem lciRoleName;
        private DevExpress.XtraLayout.EmptySpaceItem esiCrud;
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tnpTraditionalDisplay;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tpnGraphicMode;
        private Components.CustomGridControl customGridControl1;
    }
}