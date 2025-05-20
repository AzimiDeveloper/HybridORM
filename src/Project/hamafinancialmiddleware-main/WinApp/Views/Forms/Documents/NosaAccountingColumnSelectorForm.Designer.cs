namespace Hama.WinApp.Views.Forms.Documents
{
    partial class NosaAccountingColumnSelectorForm
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
            layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            lbcColumns = new DevExpress.XtraEditors.ListBoxControl();
            lueColumnType = new DevExpress.XtraEditors.LookUpEdit();
            txeColumnValue = new DevExpress.XtraEditors.ButtonEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            lciColumnType = new DevExpress.XtraLayout.LayoutControlItem();
            lciColumns = new DevExpress.XtraLayout.LayoutControlItem();
            lciColumnValue = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)dxError).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
            layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lbcColumns).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueColumnType.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txeColumnValue.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciColumnType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciColumns).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciColumnValue).BeginInit();
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
            // layoutControl1
            // 
            layoutControl1.Controls.Add(lbcColumns);
            layoutControl1.Controls.Add(lueColumnType);
            layoutControl1.Controls.Add(txeColumnValue);
            layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            layoutControl1.Location = new System.Drawing.Point(0, 111);
            layoutControl1.Name = "layoutControl1";
            layoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            layoutControl1.Root = Root;
            layoutControl1.Size = new System.Drawing.Size(324, 420);
            layoutControl1.TabIndex = 0;
            layoutControl1.Text = "layoutControl1";
            // 
            // lbcColumns
            // 
            lbcColumns.Location = new System.Drawing.Point(12, 68);
            lbcColumns.MultiColumn = true;
            lbcColumns.Name = "lbcColumns";
            lbcColumns.Size = new System.Drawing.Size(300, 300);
            lbcColumns.StyleController = layoutControl1;
            lbcColumns.TabIndex = 2;
            // 
            // lueColumnType
            // 
            lueColumnType.Location = new System.Drawing.Point(12, 28);
            lueColumnType.MenuManager = barManager1;
            lueColumnType.Name = "lueColumnType";
            lueColumnType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lueColumnType.Properties.NullText = "";
            lueColumnType.Size = new System.Drawing.Size(300, 20);
            lueColumnType.StyleController = layoutControl1;
            lueColumnType.TabIndex = 0;
            // 
            // txeColumnValue
            // 
            txeColumnValue.Location = new System.Drawing.Point(12, 388);
            txeColumnValue.MenuManager = barManager1;
            txeColumnValue.Name = "txeColumnValue";
            txeColumnValue.Properties.Appearance.BackColor = System.Drawing.Color.Cyan;
            txeColumnValue.Properties.Appearance.Options.UseBackColor = true;
            txeColumnValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            txeColumnValue.Size = new System.Drawing.Size(300, 20);
            txeColumnValue.StyleController = layoutControl1;
            txeColumnValue.TabIndex = 4;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { lciColumnType, lciColumns, lciColumnValue });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(324, 420);
            Root.TextVisible = false;
            // 
            // lciColumnType
            // 
            lciColumnType.Control = lueColumnType;
            lciColumnType.Location = new System.Drawing.Point(0, 0);
            lciColumnType.Name = "lciColumnType";
            lciColumnType.Size = new System.Drawing.Size(304, 40);
            lciColumnType.Text = "مبنای استفاده از فیلد";
            lciColumnType.TextLocation = DevExpress.Utils.Locations.Top;
            lciColumnType.TextSize = new System.Drawing.Size(101, 13);
            // 
            // lciColumns
            // 
            lciColumns.Control = lbcColumns;
            lciColumns.Location = new System.Drawing.Point(0, 40);
            lciColumns.Name = "lciColumns";
            lciColumns.Size = new System.Drawing.Size(304, 320);
            lciColumns.Text = "فیلدهای منبع ارسالی";
            lciColumns.TextLocation = DevExpress.Utils.Locations.Top;
            lciColumns.TextSize = new System.Drawing.Size(101, 13);
            // 
            // lciColumnValue
            // 
            lciColumnValue.Control = txeColumnValue;
            lciColumnValue.Location = new System.Drawing.Point(0, 360);
            lciColumnValue.Name = "lciColumnValue";
            lciColumnValue.Size = new System.Drawing.Size(304, 40);
            lciColumnValue.Text = "عبارت معادل";
            lciColumnValue.TextLocation = DevExpress.Utils.Locations.Top;
            lciColumnValue.TextSize = new System.Drawing.Size(101, 13);
            // 
            // NosaAccountingColumnSelectorForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(324, 531);
            Controls.Add(layoutControl1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Name = "NosaAccountingColumnSelectorForm";
            Text = "انتخاب از دیتای منبع ارسالی";
            Controls.SetChildIndex(layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)dxError).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
            layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)lbcColumns).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueColumnType.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txeColumnValue.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciColumnType).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciColumns).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciColumnValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.ListBoxControl lbcColumns;
        private DevExpress.XtraEditors.LookUpEdit lueColumnType;
        private DevExpress.XtraEditors.ButtonEdit txeColumnValue;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem lciColumnType;
        private DevExpress.XtraLayout.LayoutControlItem lciColumns;
        private DevExpress.XtraLayout.LayoutControlItem lciColumnValue;
    }
}