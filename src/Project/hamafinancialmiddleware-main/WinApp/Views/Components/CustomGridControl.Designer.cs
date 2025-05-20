namespace Hama.WinApp.Views.Components
{
    partial class CustomGridControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomGridControl));
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar2 = new DevExpress.XtraBars.Bar();
            GridRealTimeDate = new DevExpress.XtraBars.BarButtonItem();
            GridPreview = new DevExpress.XtraBars.BarButtonItem();
            GridExportToExcel = new DevExpress.XtraBars.BarButtonItem();
            GridExportToCSV = new DevExpress.XtraBars.BarButtonItem();
            GridExportToPDF = new DevExpress.XtraBars.BarButtonItem();
            GridExportToImage = new DevExpress.XtraBars.BarButtonItem();
            GridExportToDoc = new DevExpress.XtraBars.BarButtonItem();
            GridChart = new DevExpress.XtraBars.BarButtonItem();
            GridLayoutSave = new DevExpress.XtraBars.BarButtonItem();
            GridLayoutClear = new DevExpress.XtraBars.BarButtonItem();
            GridLayouts = new DevExpress.XtraBars.BarEditItem();
            LueGridLayouts = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            GridZoom = new DevExpress.XtraBars.BarEditItem();
            GridZoomTrackBar = new DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            barEditItem3 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            rluGridLayouts = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            pnlLoading = new DevExpress.XtraEditors.PanelControl();
            progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LueGridLayouts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GridZoomTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemLookUpEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rluGridLayouts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoading).BeginInit();
            pnlLoading.SuspendLayout();
            SuspendLayout();
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar2 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { GridLayoutSave, GridLayoutClear, GridPreview, GridExportToExcel, GridExportToCSV, GridExportToPDF, GridExportToImage, GridExportToDoc, GridRealTimeDate, GridChart, GridLayouts, GridZoom, barEditItem1, barEditItem2, barEditItem3 });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 18;
            barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { rluGridLayouts, LueGridLayouts, GridZoomTrackBar, repositoryItemTextEdit1, repositoryItemTextEdit2, repositoryItemLookUpEdit1 });
            // 
            // bar2
            // 
            bar2.BarName = "Main menu";
            bar2.DockCol = 0;
            bar2.DockRow = 0;
            bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(GridRealTimeDate), new DevExpress.XtraBars.LinkPersistInfo(GridPreview, true), new DevExpress.XtraBars.LinkPersistInfo(GridExportToExcel), new DevExpress.XtraBars.LinkPersistInfo(GridExportToCSV), new DevExpress.XtraBars.LinkPersistInfo(GridExportToPDF), new DevExpress.XtraBars.LinkPersistInfo(GridExportToImage), new DevExpress.XtraBars.LinkPersistInfo(GridExportToDoc), new DevExpress.XtraBars.LinkPersistInfo(GridChart, true), new DevExpress.XtraBars.LinkPersistInfo(GridLayoutSave, true), new DevExpress.XtraBars.LinkPersistInfo(GridLayoutClear), new DevExpress.XtraBars.LinkPersistInfo(GridLayouts), new DevExpress.XtraBars.LinkPersistInfo(GridZoom, true) });
            bar2.OptionsBar.MultiLine = true;
            bar2.OptionsBar.UseWholeRow = true;
            bar2.Text = "Main menu";
            // 
            // GridRealTimeDate
            // 
            GridRealTimeDate.Caption = "GridRealTimeDate";
            GridRealTimeDate.Id = 8;
            GridRealTimeDate.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GridRealTimeDate.ImageOptions.SvgImage");
            GridRealTimeDate.Name = "GridRealTimeDate";
            GridRealTimeDate.ItemClick += GridRealTimeDate_ItemClick;
            // 
            // GridPreview
            // 
            GridPreview.Caption = "GridPreview";
            GridPreview.Id = 2;
            GridPreview.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GridPreview.ImageOptions.SvgImage");
            GridPreview.Name = "GridPreview";
            GridPreview.ItemClick += GridPreview_ItemClick;
            // 
            // GridExportToExcel
            // 
            GridExportToExcel.Caption = "GridExportToExcel";
            GridExportToExcel.Id = 3;
            GridExportToExcel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GridExportToExcel.ImageOptions.SvgImage");
            GridExportToExcel.Name = "GridExportToExcel";
            GridExportToExcel.ItemClick += GridExportToExcel_ItemClick;
            // 
            // GridExportToCSV
            // 
            GridExportToCSV.Caption = "GridExportToCSV";
            GridExportToCSV.Id = 4;
            GridExportToCSV.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GridExportToCSV.ImageOptions.SvgImage");
            GridExportToCSV.Name = "GridExportToCSV";
            GridExportToCSV.ItemClick += GridExportToCSV_ItemClick;
            // 
            // GridExportToPDF
            // 
            GridExportToPDF.Caption = "GridExportToPDF";
            GridExportToPDF.Id = 5;
            GridExportToPDF.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GridExportToPDF.ImageOptions.SvgImage");
            GridExportToPDF.Name = "GridExportToPDF";
            GridExportToPDF.ItemClick += GridExportToPDF_ItemClick;
            // 
            // GridExportToImage
            // 
            GridExportToImage.Caption = "GridExportToImage";
            GridExportToImage.Id = 6;
            GridExportToImage.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GridExportToImage.ImageOptions.SvgImage");
            GridExportToImage.Name = "GridExportToImage";
            GridExportToImage.ItemClick += GridExportToImage_ItemClick;
            // 
            // GridExportToDoc
            // 
            GridExportToDoc.Caption = "GridExportToDoc";
            GridExportToDoc.Id = 7;
            GridExportToDoc.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GridExportToDoc.ImageOptions.SvgImage");
            GridExportToDoc.Name = "GridExportToDoc";
            GridExportToDoc.ItemClick += GridExportToDoc_ItemClick;
            // 
            // GridChart
            // 
            GridChart.Caption = "GridChart";
            GridChart.Id = 9;
            GridChart.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GridChart.ImageOptions.SvgImage");
            GridChart.Name = "GridChart";
            GridChart.ItemClick += GridChart_ItemClick;
            // 
            // GridLayoutSave
            // 
            GridLayoutSave.Caption = "GridLayoutSave";
            GridLayoutSave.Id = 0;
            GridLayoutSave.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GridLayoutSave.ImageOptions.SvgImage");
            GridLayoutSave.Name = "GridLayoutSave";
            GridLayoutSave.ItemClick += GridLayoutSave_ItemClick;
            // 
            // GridLayoutClear
            // 
            GridLayoutClear.Caption = "GridLayoutClear";
            GridLayoutClear.Id = 1;
            GridLayoutClear.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("GridLayoutClear.ImageOptions.SvgImage");
            GridLayoutClear.Name = "GridLayoutClear";
            GridLayoutClear.ItemClick += GridLayoutClear_ItemClick;
            // 
            // GridLayouts
            // 
            GridLayouts.Caption = "GridLayouts";
            GridLayouts.Edit = LueGridLayouts;
            GridLayouts.EditWidth = 150;
            GridLayouts.Id = 13;
            GridLayouts.Name = "GridLayouts";
            GridLayouts.Size = new System.Drawing.Size(150, 20);
            GridLayouts.EditValueChanged += GridLayouts_EditValueChanged;
            // 
            // LueGridLayouts
            // 
            LueGridLayouts.Appearance.BackColor = System.Drawing.Color.Transparent;
            LueGridLayouts.Appearance.Options.UseBackColor = true;
            LueGridLayouts.AutoHeight = false;
            LueGridLayouts.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            LueGridLayouts.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            LueGridLayouts.Name = "LueGridLayouts";
            // 
            // GridZoom
            // 
            GridZoom.Caption = "GridZoom";
            GridZoom.Edit = GridZoomTrackBar;
            GridZoom.Id = 14;
            GridZoom.MinWidth = 100;
            GridZoom.Name = "GridZoom";
            GridZoom.Size = new System.Drawing.Size(200, 20);
            GridZoom.EditValueChanged += GridZoom_EditValueChanged;
            // 
            // GridZoomTrackBar
            // 
            GridZoomTrackBar.InvertLayout = true;
            GridZoomTrackBar.Minimum = -10;
            GridZoomTrackBar.Name = "GridZoomTrackBar";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new System.Drawing.Size(960, 24);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 510);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new System.Drawing.Size(960, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 486);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(960, 24);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 486);
            // 
            // barEditItem1
            // 
            barEditItem1.Caption = "barEditItem1";
            barEditItem1.Edit = repositoryItemTextEdit1;
            barEditItem1.Id = 15;
            barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemTextEdit1
            // 
            repositoryItemTextEdit1.AutoHeight = false;
            repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barEditItem2
            // 
            barEditItem2.Caption = "barEditItem2";
            barEditItem2.Edit = repositoryItemTextEdit2;
            barEditItem2.Id = 16;
            barEditItem2.Name = "barEditItem2";
            // 
            // repositoryItemTextEdit2
            // 
            repositoryItemTextEdit2.AutoHeight = false;
            repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // barEditItem3
            // 
            barEditItem3.Caption = "barEditItem3";
            barEditItem3.Edit = repositoryItemLookUpEdit1;
            barEditItem3.Id = 17;
            barEditItem3.Name = "barEditItem3";
            // 
            // repositoryItemLookUpEdit1
            // 
            repositoryItemLookUpEdit1.AutoHeight = false;
            repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // rluGridLayouts
            // 
            rluGridLayouts.AutoHeight = false;
            rluGridLayouts.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            rluGridLayouts.Name = "rluGridLayouts";
            // 
            // gridControl1
            // 
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl1.Location = new System.Drawing.Point(0, 24);
            gridControl1.MainView = gridView1;
            gridControl1.MenuManager = barManager1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(960, 486);
            gridControl1.TabIndex = 4;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Appearance.FocusedCell.Options.UseTextOptions = true;
            gridView1.Appearance.FocusedCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridView1.AppearancePrint.EvenRow.Options.UseTextOptions = true;
            gridView1.AppearancePrint.EvenRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gridView1.AppearancePrint.GroupRow.Options.UseTextOptions = true;
            gridView1.AppearancePrint.GroupRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gridView1.AppearancePrint.Row.Options.UseTextOptions = true;
            gridView1.AppearancePrint.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            gridView1.MouseWheel += gridView1_MouseWheel;
            // 
            // pnlLoading
            // 
            pnlLoading.Controls.Add(progressPanel1);
            pnlLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlLoading.Location = new System.Drawing.Point(0, 24);
            pnlLoading.Name = "pnlLoading";
            pnlLoading.Size = new System.Drawing.Size(960, 486);
            pnlLoading.TabIndex = 9;
            pnlLoading.Visible = false;
            // 
            // progressPanel1
            // 
            progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            progressPanel1.Appearance.Options.UseBackColor = true;
            progressPanel1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            progressPanel1.AppearanceCaption.Options.UseFont = true;
            progressPanel1.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            progressPanel1.AppearanceDescription.Options.UseFont = true;
            progressPanel1.ImageHorzOffset = 20;
            progressPanel1.Location = new System.Drawing.Point(2, 2);
            progressPanel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            progressPanel1.Name = "progressPanel1";
            progressPanel1.Size = new System.Drawing.Size(649, 410);
            progressPanel1.TabIndex = 1;
            progressPanel1.Text = "progressPanel1";
            // 
            // CustomGridControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(pnlLoading);
            Controls.Add(gridControl1);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "CustomGridControl";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            Size = new System.Drawing.Size(960, 510);
            Load += EllastixGridControl_Load;
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)LueGridLayouts).EndInit();
            ((System.ComponentModel.ISupportInitialize)GridZoomTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit2).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemLookUpEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)rluGridLayouts).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlLoading).EndInit();
            pnlLoading.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem GridLayoutSave;
        private DevExpress.XtraBars.BarButtonItem GridLayoutClear;
        private DevExpress.XtraBars.BarButtonItem GridPreview;
        private DevExpress.XtraBars.BarButtonItem GridExportToExcel;
        private DevExpress.XtraBars.BarButtonItem GridExportToCSV;
        private DevExpress.XtraBars.BarButtonItem GridExportToPDF;
        private DevExpress.XtraBars.BarButtonItem GridExportToImage;
        private DevExpress.XtraBars.BarButtonItem GridExportToDoc;
        private DevExpress.XtraBars.BarButtonItem GridRealTimeDate;
        private DevExpress.XtraBars.BarButtonItem GridChart;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rluGridLayouts;
        public DevExpress.XtraBars.Bar bar2;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        public DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraBars.BarEditItem GridLayouts;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LueGridLayouts;
        private DevExpress.XtraBars.BarEditItem GridZoom;
        private DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar GridZoomTrackBar;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarEditItem barEditItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
		private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
		public DevExpress.XtraEditors.PanelControl pnlLoading;
	}
}
