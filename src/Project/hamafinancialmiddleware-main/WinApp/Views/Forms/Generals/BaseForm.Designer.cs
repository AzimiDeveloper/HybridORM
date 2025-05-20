namespace Hama.WinApp.Views.Forms
{
    partial class BaseForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar2 = new DevExpress.XtraBars.Bar();
            barButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemReload = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemEdit = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemSend = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemCopy = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemFirst = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemPrevious = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemNext = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemLast = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemLock = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemBookmark = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemAttachment = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemComment = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemDownload = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemUpload = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemImportExcel = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemNavigation = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemPrint = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemSimulation = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemDoubleCheck = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemFastEntry = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemQRCode = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemSelectAll = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemState = new DevExpress.XtraBars.BarButtonItem();
            barStatusDatabaseConnect = new DevExpress.XtraBars.BarButtonItem();
            barStatusErrorList = new DevExpress.XtraBars.BarButtonItem();
            barStatusHelp = new DevExpress.XtraBars.BarButtonItem();
            barStatusInformation = new DevExpress.XtraBars.BarButtonItem();
            barStatusCompanyName = new DevExpress.XtraBars.BarHeaderItem();
            barStatusFinancialPeriod = new DevExpress.XtraBars.BarStaticItem();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            repositoryItemZoomTrackBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar();
            BarMenu = new DevExpress.XtraBars.Bar();
            dxError = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(components);
            alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(components);
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemZoomTrackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dxError).BeginInit();
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
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barButtonItemNew, barButtonItemSave, barButtonItemSend, barButtonItemEdit, barButtonItemCopy, barButtonItemDelete, barButtonItemReload, barButtonItemFirst, barButtonItemPrevious, barButtonItemNext, barButtonItemLast, barButtonItemLock, barButtonItemBookmark, barButtonItemAttachment, barButtonItemComment, barButtonItemNavigation, barButtonItemDownload, barButtonItemPrint, barSubItem1, barEditItem1, barButtonItemDoubleCheck, barStatusDatabaseConnect, barStatusErrorList, barStatusHelp, barStatusInformation, barStatusCompanyName, barStatusFinancialPeriod, barButtonItemSimulation, barButtonItemFastEntry, barButtonItemUpload, barButtonItemQRCode, barButtonItemSelectAll, barButtonItemState, barButtonItemImportExcel });
            barManager1.MaxItemId = 43;
            barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemTextEdit1, repositoryItemZoomTrackBar1 });
            // 
            // bar2
            // 
            bar2.BarName = "Main menu";
            bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            bar2.DockCol = 0;
            bar2.DockRow = 0;
            bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, barButtonItemNew, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, barButtonItemReload, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, barButtonItemEdit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, barButtonItemSave, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, barButtonItemDelete, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemSend, true), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemCopy, true), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemFirst, true), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemPrevious), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemNext), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemLast), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemLock, true), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemBookmark), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemAttachment), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemComment), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemDownload, true), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, barButtonItemUpload, DevExpress.XtraBars.BarItemPaintStyle.Standard), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemImportExcel), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemNavigation, true), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemPrint, true), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemSimulation), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemDoubleCheck), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemFastEntry), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, barButtonItemQRCode, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemSelectAll), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemState) });
            bar2.OptionsBar.AllowQuickCustomization = false;
            bar2.OptionsBar.DrawDragBorder = false;
            bar2.OptionsBar.MultiLine = true;
            bar2.OptionsBar.UseWholeRow = true;
            bar2.Text = "منوهای اصلی";
            // 
            // barButtonItemNew
            // 
            barButtonItemNew.Caption = "جدید";
            barButtonItemNew.Id = 0;
            barButtonItemNew.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemNew.ImageOptions.SvgImage");
            barButtonItemNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            barButtonItemNew.Name = "barButtonItemNew";
            // 
            // barButtonItemReload
            // 
            barButtonItemReload.Caption = "بازخوانی اطلاعات";
            barButtonItemReload.Id = 6;
            barButtonItemReload.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemReload.ImageOptions.SvgImage");
            barButtonItemReload.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F6);
            barButtonItemReload.Name = "barButtonItemReload";
            // 
            // barButtonItemEdit
            // 
            barButtonItemEdit.Caption = "ویرایش";
            barButtonItemEdit.Id = 3;
            barButtonItemEdit.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemEdit.ImageOptions.SvgImage");
            barButtonItemEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F7);
            barButtonItemEdit.Name = "barButtonItemEdit";
            // 
            // barButtonItemSave
            // 
            barButtonItemSave.Caption = "ذخیره سازی";
            barButtonItemSave.Id = 1;
            barButtonItemSave.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemSave.ImageOptions.SvgImage");
            barButtonItemSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F8);
            barButtonItemSave.Name = "barButtonItemSave";
            // 
            // barButtonItemDelete
            // 
            barButtonItemDelete.Caption = "حذف";
            barButtonItemDelete.Id = 5;
            barButtonItemDelete.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemDelete.ImageOptions.SvgImage");
            barButtonItemDelete.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F9);
            barButtonItemDelete.Name = "barButtonItemDelete";
            // 
            // barButtonItemSend
            // 
            barButtonItemSend.Caption = "ارسال";
            barButtonItemSend.Id = 2;
            barButtonItemSend.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemSend.ImageOptions.SvgImage");
            barButtonItemSend.Name = "barButtonItemSend";
            // 
            // barButtonItemCopy
            // 
            barButtonItemCopy.Caption = "کپی برداری";
            barButtonItemCopy.Id = 4;
            barButtonItemCopy.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemCopy.ImageOptions.SvgImage");
            barButtonItemCopy.Name = "barButtonItemCopy";
            // 
            // barButtonItemFirst
            // 
            barButtonItemFirst.Caption = "اولین";
            barButtonItemFirst.Id = 7;
            barButtonItemFirst.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemFirst.ImageOptions.SvgImage");
            barButtonItemFirst.Name = "barButtonItemFirst";
            // 
            // barButtonItemPrevious
            // 
            barButtonItemPrevious.Caption = "قبلی";
            barButtonItemPrevious.Id = 8;
            barButtonItemPrevious.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemPrevious.ImageOptions.SvgImage");
            barButtonItemPrevious.Name = "barButtonItemPrevious";
            // 
            // barButtonItemNext
            // 
            barButtonItemNext.Caption = "بعدی";
            barButtonItemNext.Id = 9;
            barButtonItemNext.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemNext.ImageOptions.SvgImage");
            barButtonItemNext.Name = "barButtonItemNext";
            // 
            // barButtonItemLast
            // 
            barButtonItemLast.Caption = "آخرین";
            barButtonItemLast.Id = 10;
            barButtonItemLast.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemLast.ImageOptions.SvgImage");
            barButtonItemLast.Name = "barButtonItemLast";
            // 
            // barButtonItemLock
            // 
            barButtonItemLock.Caption = "قفل کردن";
            barButtonItemLock.Id = 11;
            barButtonItemLock.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemLock.ImageOptions.SvgImage");
            barButtonItemLock.Name = "barButtonItemLock";
            // 
            // barButtonItemBookmark
            // 
            barButtonItemBookmark.Caption = "نشانه گذاری";
            barButtonItemBookmark.Id = 12;
            barButtonItemBookmark.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemBookmark.ImageOptions.SvgImage");
            barButtonItemBookmark.Name = "barButtonItemBookmark";
            // 
            // barButtonItemAttachment
            // 
            barButtonItemAttachment.Caption = "پیوست";
            barButtonItemAttachment.Id = 13;
            barButtonItemAttachment.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemAttachment.ImageOptions.SvgImage");
            barButtonItemAttachment.Name = "barButtonItemAttachment";
            // 
            // barButtonItemComment
            // 
            barButtonItemComment.Caption = "یاداشت";
            barButtonItemComment.Id = 14;
            barButtonItemComment.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemComment.ImageOptions.SvgImage");
            barButtonItemComment.Name = "barButtonItemComment";
            // 
            // barButtonItemDownload
            // 
            barButtonItemDownload.Caption = "دانلود";
            barButtonItemDownload.Id = 16;
            barButtonItemDownload.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemDownload.ImageOptions.SvgImage");
            barButtonItemDownload.Name = "barButtonItemDownload";
            // 
            // barButtonItemUpload
            // 
            barButtonItemUpload.Caption = "آپلود";
            barButtonItemUpload.Id = 37;
            barButtonItemUpload.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemUpload.ImageOptions.SvgImage");
            barButtonItemUpload.Name = "barButtonItemUpload";
            // 
            // barButtonItemImportExcel
            // 
            barButtonItemImportExcel.Caption = "سندفایلی";
            barButtonItemImportExcel.Id = 42;
            barButtonItemImportExcel.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemImportExcel.ImageOptions.SvgImage");
            barButtonItemImportExcel.Name = "barButtonItemImportExcel";
            // 
            // barButtonItemNavigation
            // 
            barButtonItemNavigation.Caption = "ارتباطات";
            barButtonItemNavigation.Id = 15;
            barButtonItemNavigation.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemNavigation.ImageOptions.SvgImage");
            barButtonItemNavigation.Name = "barButtonItemNavigation";
            // 
            // barButtonItemPrint
            // 
            barButtonItemPrint.Caption = "پرینت";
            barButtonItemPrint.Id = 17;
            barButtonItemPrint.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemPrint.ImageOptions.SvgImage");
            barButtonItemPrint.Name = "barButtonItemPrint";
            // 
            // barButtonItemSimulation
            // 
            barButtonItemSimulation.Caption = "شبیه سازی سند حسابداری";
            barButtonItemSimulation.Id = 35;
            barButtonItemSimulation.ImageOptions.SvgImage = Properties.Resources.bo_security_permission_action;
            barButtonItemSimulation.Name = "barButtonItemSimulation";
            // 
            // barButtonItemDoubleCheck
            // 
            barButtonItemDoubleCheck.Caption = "کنترل مجدد";
            barButtonItemDoubleCheck.Id = 25;
            barButtonItemDoubleCheck.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemDoubleCheck.ImageOptions.SvgImage");
            barButtonItemDoubleCheck.Name = "barButtonItemDoubleCheck";
            // 
            // barButtonItemFastEntry
            // 
            barButtonItemFastEntry.Caption = "ورود سریع اطلاعات";
            barButtonItemFastEntry.Id = 36;
            barButtonItemFastEntry.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemFastEntry.ImageOptions.SvgImage");
            barButtonItemFastEntry.Name = "barButtonItemFastEntry";
            // 
            // barButtonItemQRCode
            // 
            barButtonItemQRCode.Caption = "بارکد";
            barButtonItemQRCode.Id = 39;
            barButtonItemQRCode.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemQRCode.ImageOptions.SvgImage");
            barButtonItemQRCode.Name = "barButtonItemQRCode";
            // 
            // barButtonItemSelectAll
            // 
            barButtonItemSelectAll.Caption = "انتخاب همه";
            barButtonItemSelectAll.Id = 40;
            barButtonItemSelectAll.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemSelectAll.ImageOptions.SvgImage");
            barButtonItemSelectAll.Name = "barButtonItemSelectAll";
            // 
            // barButtonItemState
            // 
            barButtonItemState.Caption = "تغییر وضعیت";
            barButtonItemState.Id = 41;
            barButtonItemState.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemState.ImageOptions.SvgImage");
            barButtonItemState.Name = "barButtonItemState";
            // 
            // barStatusDatabaseConnect
            // 
            barStatusDatabaseConnect.Caption = "پایگاه داده";
            barStatusDatabaseConnect.Id = 26;
            barStatusDatabaseConnect.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barStatusDatabaseConnect.ImageOptions.SvgImage");
            barStatusDatabaseConnect.Name = "barStatusDatabaseConnect";
            // 
            // barStatusErrorList
            // 
            barStatusErrorList.Caption = "لیست خطا";
            barStatusErrorList.Id = 27;
            barStatusErrorList.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barStatusErrorList.ImageOptions.SvgImage");
            barStatusErrorList.Name = "barStatusErrorList";
            // 
            // barStatusHelp
            // 
            barStatusHelp.Caption = "راهنما";
            barStatusHelp.Id = 28;
            barStatusHelp.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barStatusHelp.ImageOptions.SvgImage");
            barStatusHelp.Name = "barStatusHelp";
            // 
            // barStatusInformation
            // 
            barStatusInformation.Caption = "اطلاعات";
            barStatusInformation.Id = 29;
            barStatusInformation.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barStatusInformation.ImageOptions.SvgImage");
            barStatusInformation.Name = "barStatusInformation";
            // 
            // barStatusCompanyName
            // 
            barStatusCompanyName.Caption = "نام شرکت";
            barStatusCompanyName.Id = 30;
            barStatusCompanyName.Name = "barStatusCompanyName";
            // 
            // barStatusFinancialPeriod
            // 
            barStatusFinancialPeriod.Caption = "دوره مالی";
            barStatusFinancialPeriod.Id = 31;
            barStatusFinancialPeriod.Name = "barStatusFinancialPeriod";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new System.Drawing.Size(1051, 24);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 589);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new System.Drawing.Size(1051, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 565);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(1051, 24);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 565);
            // 
            // barSubItem1
            // 
            barSubItem1.Caption = "barSubItem1";
            barSubItem1.Id = 18;
            barSubItem1.Name = "barSubItem1";
            // 
            // barEditItem1
            // 
            barEditItem1.Caption = "barEditItem1";
            barEditItem1.Edit = repositoryItemTextEdit1;
            barEditItem1.Id = 19;
            barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemTextEdit1
            // 
            repositoryItemTextEdit1.AutoHeight = false;
            repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemZoomTrackBar1
            // 
            repositoryItemZoomTrackBar1.Name = "repositoryItemZoomTrackBar1";
            // 
            // BarMenu
            // 
            BarMenu.BarName = "BarMenu";
            BarMenu.DockCol = 0;
            BarMenu.DockRow = 1;
            BarMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            BarMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItemDoubleCheck) });
            BarMenu.Text = "Tools";
            // 
            // dxError
            // 
            dxError.ContainerControl = this;
            // 
            // alertControl1
            // 
            alertControl1.AlwaysShowOnMainDisplay = true;
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
            alertControl1.AutoFormDelay = 5000;
            alertControl1.AutoHeight = true;
            alertControl1.FormDisplaySpeed = DevExpress.XtraBars.Alerter.AlertFormDisplaySpeed.Slow;
            alertControl1.FormLocation = DevExpress.XtraBars.Alerter.AlertFormLocation.BottomLeft;
            alertControl1.FormMaxCount = 5;
            alertControl1.FormShowingEffect = DevExpress.XtraBars.Alerter.AlertFormShowingEffect.FadeIn;
            alertControl1.HideAnimationType = DevExpress.XtraBars.Alerter.AlertFormShowingEffect.SlideHorizontal;
            alertControl1.ShowAnimationType = DevExpress.XtraBars.Alerter.AlertFormShowingEffect.MoveVertical;
            alertControl1.ShowPinButton = false;
            alertControl1.ShowToolTips = false;
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1051, 589);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Name = "BaseForm";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "BaseForm";
            Activated += BaseForm_Activated;
            Load += BaseForm_Load;
            Shown += BaseForm_Shown;
            Resize += BaseForm_Resize;
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemZoomTrackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dxError).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DevExpress.XtraBars.Bar BarMenu;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem barStatusDatabaseConnect;
        private DevExpress.XtraBars.BarButtonItem barStatusErrorList;
        private DevExpress.XtraBars.BarButtonItem barStatusHelp;
        private DevExpress.XtraBars.BarButtonItem barStatusInformation;
        private DevExpress.XtraBars.BarHeaderItem barStatusCompanyName;
        private DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar repositoryItemZoomTrackBar1;
        public DevExpress.XtraBars.BarButtonItem barButtonItemNew;
        public DevExpress.XtraBars.BarButtonItem barButtonItemSend;
        public DevExpress.XtraBars.BarButtonItem barButtonItemEdit;
        public DevExpress.XtraBars.BarButtonItem barButtonItemCopy;
        public DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        public DevExpress.XtraBars.BarButtonItem barButtonItemReload;
        public DevExpress.XtraBars.BarButtonItem barButtonItemFirst;
        public DevExpress.XtraBars.BarButtonItem barButtonItemPrevious;
        public DevExpress.XtraBars.BarButtonItem barButtonItemNext;
        public DevExpress.XtraBars.BarButtonItem barButtonItemLast;
        public DevExpress.XtraBars.BarButtonItem barButtonItemLock;
        public DevExpress.XtraBars.BarButtonItem barButtonItemBookmark;
        public DevExpress.XtraBars.BarButtonItem barButtonItemAttachment;
        public DevExpress.XtraBars.BarButtonItem barButtonItemComment;
        public DevExpress.XtraBars.BarButtonItem barButtonItemNavigation;
        public DevExpress.XtraBars.BarButtonItem barButtonItemDownload;
        public DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        public DevExpress.XtraBars.BarButtonItem barButtonItemDoubleCheck;
        protected DevExpress.XtraBars.BarButtonItem barButtonItemSave;
        protected DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxError;
        public DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        protected DevExpress.XtraBars.BarStaticItem barStatusFinancialPeriod;
        public DevExpress.XtraBars.BarButtonItem barButtonItemSimulation;
        public DevExpress.XtraBars.BarButtonItem barButtonItemFastEntry;
		public DevExpress.XtraBars.BarManager barManager1;
		protected DevExpress.XtraBars.BarButtonItem barButtonItemUpload;
        public DevExpress.XtraBars.BarButtonItem barButtonItemQRCode;
		public DevExpress.XtraBars.BarButtonItem barButtonItemSelectAll;
		public DevExpress.XtraBars.BarButtonItem barButtonItemState;
		public DevExpress.XtraBars.BarButtonItem barButtonItemImportExcel;
    }
}