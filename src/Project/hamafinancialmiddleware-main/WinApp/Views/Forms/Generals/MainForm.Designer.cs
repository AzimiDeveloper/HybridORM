using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.Model;
using System.Windows.Forms;
using System.Windows;

namespace Hama.WinApp.Views.Forms
{
    partial class MainForm
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.Animation.PushTransition pushTransition1 = new DevExpress.Utils.Animation.PushTransition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            accordionControlUser = new DevExpress.XtraBars.Navigation.AccordionControl();
            accordionControlUsrofile = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            workspaceManager1 = new DevExpress.Utils.WorkspaceManager(components);
            accordionControlApplication = new DevExpress.XtraBars.Navigation.AccordionControl();
            accordionControlElementDashboards = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aceUser = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aceUsersForm = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aceAccessControlForm = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            acePermissionsForm = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aceRolesForm = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aceDocuments = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aceDocumentPatternsForm = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aceDocumentPatternForm = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            aceNosaAccountingForm = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            CompanyType = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            repositoryItemRibbonSearchEdit1 = new DevExpress.XtraBars.Ribbon.Internal.RepositoryItemRibbonSearchEdit();
            repositoryItemRibbonSearchEdit2 = new DevExpress.XtraBars.Ribbon.Internal.RepositoryItemRibbonSearchEdit();
            accordionControlElement18 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            documentManagerMain = new DevExpress.XtraBars.Docking2010.DocumentManager(components);
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar2 = new DevExpress.XtraBars.Bar();
            skinBarSubItem1 = new DevExpress.XtraBars.SkinBarSubItem();
            skinDropDownButtonItem1 = new DevExpress.XtraBars.SkinDropDownButtonItem();
            skinPaletteDropDownButtonItem1 = new DevExpress.XtraBars.SkinPaletteDropDownButtonItem();
            barButtonItemWhiteAndDark = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemModalMode = new DevExpress.XtraBars.BarButtonItem();
            barButtonItemFullScreen = new DevExpress.XtraBars.BarButtonItem();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(components);
            alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(components);
            dashboardViewItem = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlElementTasks = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlElementUserAction = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlElementUserName = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator3 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            accordionControlElementMyProfile = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlElementBill = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator4 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            accordionControlElementlibrary = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlElementFAQ = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlSeparator5 = new DevExpress.XtraBars.Navigation.AccordionControlSeparator();
            accordionControlUserSwitchUser = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlUserExit = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            navigationGroup = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)accordionControlUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)accordionControlApplication).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemRibbonSearchEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemRibbonSearchEdit2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)documentManagerMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabbedView1).BeginInit();
            SuspendLayout();
            // 
            // accordionControlUser
            // 
            accordionControlUser.AllowItemSelection = true;
            accordionControlUser.Dock = DockStyle.Left;
            accordionControlUser.Location = new System.Drawing.Point(0, 25);
            accordionControlUser.Name = "accordionControlUser";
            accordionControlUser.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.False;
            accordionControlUser.OptionsMinimizing.FooterHeight = 60;
            accordionControlUser.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
            accordionControlUser.RootDisplayMode = DevExpress.XtraBars.Navigation.AccordionControlRootDisplayMode.Footer;
            accordionControlUser.Size = new System.Drawing.Size(26, 660);
            accordionControlUser.TabIndex = 6;
            accordionControlUser.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlUsrofile
            // 
            accordionControlUsrofile.Height = 60;
            accordionControlUsrofile.Name = "accordionControlUsrofile";
            accordionControlUsrofile.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            toolTipItem1.Text = "My Profile";
            superToolTip1.Items.Add(toolTipItem1);
            accordionControlUsrofile.SuperTip = superToolTip1;
            accordionControlUsrofile.Tag = "EmployeeView";
            // 
            // workspaceManager1
            // 
            workspaceManager1.TargetControl = this;
            workspaceManager1.TransitionType = pushTransition1;
            // 
            // accordionControlApplication
            // 
            accordionControlApplication.Dock = DockStyle.Left;
            accordionControlApplication.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { accordionControlElementDashboards, aceDocuments });
            accordionControlApplication.Location = new System.Drawing.Point(26, 25);
            accordionControlApplication.Name = "accordionControlApplication";
            accordionControlApplication.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.Always;
            accordionControlApplication.Size = new System.Drawing.Size(255, 660);
            accordionControlApplication.TabIndex = 12;
            accordionControlApplication.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElementDashboards
            // 
            accordionControlElementDashboards.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { aceUser });
            accordionControlElementDashboards.Expanded = true;
            accordionControlElementDashboards.Name = "accordionControlElementDashboards";
            accordionControlElementDashboards.Text = "داشبورد";
            // 
            // aceUser
            // 
            aceUser.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { aceUsersForm, aceAccessControlForm, acePermissionsForm, aceRolesForm });
            aceUser.Expanded = true;
            aceUser.Name = "aceUser";
            aceUser.Text = "کاربران و دسترسی";
            // 
            // aceUsersForm
            // 
            aceUsersForm.Name = "aceUsersForm";
            aceUsersForm.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aceUsersForm.Text = "مدیریت کاربران";
            aceUsersForm.Click += aceUsersForm_Click;
            // 
            // aceAccessControlForm
            // 
            aceAccessControlForm.Name = "aceAccessControlForm";
            aceAccessControlForm.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aceAccessControlForm.Text = "مدیریت دسترسی";
            aceAccessControlForm.Click += aceAccessControlForm_Click;
            // 
            // acePermissionsForm
            // 
            acePermissionsForm.Name = "acePermissionsForm";
            acePermissionsForm.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            acePermissionsForm.Text = "مدیریت منابع دسترسی";
            acePermissionsForm.Click += acePermissionsForm_Click;
            // 
            // aceRolesForm
            // 
            aceRolesForm.Expanded = true;
            aceRolesForm.Name = "aceRolesForm";
            aceRolesForm.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aceRolesForm.Text = "مدیریت نقش های کاربری";
            aceRolesForm.Click += aceRolesForm_Click;
            // 
            // aceDocuments
            // 
            aceDocuments.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { aceDocumentPatternsForm, aceDocumentPatternForm, aceNosaAccountingForm });
            aceDocuments.Expanded = true;
            aceDocuments.Name = "aceDocuments";
            aceDocuments.Text = "مرکز اسناد";
            // 
            // aceDocumentPatternsForm
            // 
            aceDocumentPatternsForm.Name = "aceDocumentPatternsForm";
            aceDocumentPatternsForm.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aceDocumentPatternsForm.Text = "مدیریت دسته بندی الگوی سند";
            aceDocumentPatternsForm.Click += aceDocumentPatternsForm_Click;
            // 
            // aceDocumentPatternForm
            // 
            aceDocumentPatternForm.Name = "aceDocumentPatternForm";
            aceDocumentPatternForm.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aceDocumentPatternForm.Text = "مدیریت الگوهای سند";
            aceDocumentPatternForm.Click += aceDocumentPatternForm_Click;
            // 
            // aceNosaAccountingForm
            // 
            aceNosaAccountingForm.Name = "aceNosaAccountingForm";
            aceNosaAccountingForm.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            aceNosaAccountingForm.Text = "پردازش و ارسال اسناد به حسابداری";
            aceNosaAccountingForm.Click += aceNosaAccountingForm_Click;
            // 
            // CompanyType
            // 
            CompanyType.Name = "CompanyType";
            // 
            // repositoryItemRibbonSearchEdit1
            // 
            repositoryItemRibbonSearchEdit1.AllowFocused = false;
            repositoryItemRibbonSearchEdit1.AutoHeight = false;
            repositoryItemRibbonSearchEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            repositoryItemRibbonSearchEdit1.Name = "repositoryItemRibbonSearchEdit1";
            repositoryItemRibbonSearchEdit1.NullText = "Search";
            // 
            // repositoryItemRibbonSearchEdit2
            // 
            repositoryItemRibbonSearchEdit2.AllowFocused = false;
            repositoryItemRibbonSearchEdit2.AutoHeight = false;
            repositoryItemRibbonSearchEdit2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            repositoryItemRibbonSearchEdit2.Name = "repositoryItemRibbonSearchEdit2";
            repositoryItemRibbonSearchEdit2.NullText = "Search";
            // 
            // accordionControlElement18
            // 
            accordionControlElement18.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { accordionControlUsrofile });
            accordionControlElement18.Expanded = true;
            accordionControlElement18.Name = "accordionControlElement18";
            accordionControlElement18.Text = "Element18";
            // 
            // documentManagerMain
            // 
            documentManagerMain.MdiParent = this;
            documentManagerMain.MenuManager = barManager1;
            documentManagerMain.View = tabbedView1;
            documentManagerMain.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] { tabbedView1 });
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar2, bar3 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { skinBarSubItem1, skinDropDownButtonItem1, skinPaletteDropDownButtonItem1, barButtonItemWhiteAndDark, barButtonItemModalMode, barButtonItemFullScreen });
            barManager1.MainMenu = bar2;
            barManager1.MaxItemId = 6;
            barManager1.StatusBar = bar3;
            // 
            // bar2
            // 
            bar2.BarName = "Main menu";
            bar2.DockCol = 0;
            bar2.DockRow = 0;
            bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(skinBarSubItem1), new DevExpress.XtraBars.LinkPersistInfo(skinDropDownButtonItem1), new DevExpress.XtraBars.LinkPersistInfo(skinPaletteDropDownButtonItem1), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemWhiteAndDark, true), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemModalMode), new DevExpress.XtraBars.LinkPersistInfo(barButtonItemFullScreen) });
            bar2.OptionsBar.MultiLine = true;
            bar2.OptionsBar.UseWholeRow = true;
            bar2.Text = "Main menu";
            // 
            // skinBarSubItem1
            // 
            skinBarSubItem1.Caption = "skinBarSubItem1";
            skinBarSubItem1.Id = 0;
            skinBarSubItem1.Name = "skinBarSubItem1";
            // 
            // skinDropDownButtonItem1
            // 
            skinDropDownButtonItem1.ActAsDropDown = true;
            skinDropDownButtonItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            skinDropDownButtonItem1.Id = 1;
            skinDropDownButtonItem1.Name = "skinDropDownButtonItem1";
            // 
            // skinPaletteDropDownButtonItem1
            // 
            skinPaletteDropDownButtonItem1.ActAsDropDown = true;
            skinPaletteDropDownButtonItem1.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            skinPaletteDropDownButtonItem1.Id = 2;
            skinPaletteDropDownButtonItem1.Name = "skinPaletteDropDownButtonItem1";
            // 
            // barButtonItemWhiteAndDark
            // 
            barButtonItemWhiteAndDark.Caption = "barButtonItem1";
            barButtonItemWhiteAndDark.Id = 3;
            barButtonItemWhiteAndDark.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemWhiteAndDark.ImageOptions.SvgImage");
            barButtonItemWhiteAndDark.Name = "barButtonItemWhiteAndDark";
            barButtonItemWhiteAndDark.ItemClick += barButtonItemWhiteAndDark_ItemClick;
            // 
            // barButtonItemModalMode
            // 
            barButtonItemModalMode.Caption = "barButtonItem2";
            barButtonItemModalMode.Id = 4;
            barButtonItemModalMode.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemModalMode.ImageOptions.SvgImage");
            barButtonItemModalMode.Name = "barButtonItemModalMode";
            barButtonItemModalMode.ItemClick += barButtonItemModalMode_ItemClick;
            // 
            // barButtonItemFullScreen
            // 
            barButtonItemFullScreen.Caption = "barButtonItem3";
            barButtonItemFullScreen.Id = 5;
            barButtonItemFullScreen.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItemFullScreen.ImageOptions.SvgImage");
            barButtonItemFullScreen.Name = "barButtonItemFullScreen";
            barButtonItemFullScreen.ItemClick += barButtonItemFullScreen_ItemClick;
            // 
            // bar3
            // 
            bar3.BarName = "Status bar";
            bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            bar3.DockCol = 0;
            bar3.DockRow = 0;
            bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            bar3.OptionsBar.AllowQuickCustomization = false;
            bar3.OptionsBar.DrawDragBorder = false;
            bar3.OptionsBar.UseWholeRow = true;
            bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new System.Drawing.Size(1296, 25);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 685);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new System.Drawing.Size(1296, 21);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 25);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 660);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(1296, 25);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 660);
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
            alertControl1.AutoFormDelay = 20000;
            alertControl1.AutoHeight = true;
            alertControl1.FormDisplaySpeed = DevExpress.XtraBars.Alerter.AlertFormDisplaySpeed.Slow;
            alertControl1.FormLocation = DevExpress.XtraBars.Alerter.AlertFormLocation.BottomLeft;
            alertControl1.FormShowingEffect = DevExpress.XtraBars.Alerter.AlertFormShowingEffect.MoveVertical;
            alertControl1.HideAnimationType = DevExpress.XtraBars.Alerter.AlertFormShowingEffect.SlideHorizontal;
            alertControl1.ShowAnimationType = DevExpress.XtraBars.Alerter.AlertFormShowingEffect.FadeIn;
            alertControl1.ShowPinButton = false;
            alertControl1.ShowToolTips = false;
            // 
            // dashboardViewItem
            // 
            dashboardViewItem.Height = 60;
            dashboardViewItem.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("dashboardViewItem.ImageOptions.SvgImage");
            dashboardViewItem.Name = "dashboardViewItem";
            dashboardViewItem.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            toolTipItem2.Text = "تجزیه و تحلیل";
            superToolTip2.Items.Add(toolTipItem2);
            dashboardViewItem.SuperTip = superToolTip2;
            dashboardViewItem.Tag = "AnalyticsView";
            // 
            // accordionControlElementTasks
            // 
            accordionControlElementTasks.Height = 60;
            accordionControlElementTasks.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("accordionControlElementTasks.ImageOptions.SvgImage");
            accordionControlElementTasks.Name = "accordionControlElementTasks";
            accordionControlElementTasks.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            toolTipTitleItem1.Text = "وظایف";
            toolTipItem3.Text = "می توانید دسترسی به لیست وظایف را فعال کنید.";
            superToolTip3.Items.Add(toolTipTitleItem1);
            superToolTip3.Items.Add(toolTipItem3);
            accordionControlElementTasks.SuperTip = superToolTip3;
            accordionControlElementTasks.Tag = "PatientCollectionView";
            // 
            // accordionControlElementUserAction
            // 
            accordionControlElementUserAction.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { accordionControlElementUserName, accordionControlSeparator3, accordionControlElementMyProfile, accordionControlElementBill, accordionControlSeparator4, accordionControlElementlibrary, accordionControlElementFAQ, accordionControlSeparator5, accordionControlUserSwitchUser, accordionControlUserExit });
            accordionControlElementUserAction.Expanded = true;
            accordionControlElementUserAction.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] { new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image), new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl), new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons), new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text, DevExpress.XtraBars.Navigation.HeaderElementAlignment.Right) });
            accordionControlElementUserAction.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("accordionControlElementUserAction.ImageOptions.SvgImage");
            accordionControlElementUserAction.Name = "accordionControlElementUserAction";
            accordionControlElementUserAction.Text = "کاربر";
            // 
            // accordionControlElementUserName
            // 
            accordionControlElementUserName.Name = "accordionControlElementUserName";
            accordionControlElementUserName.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlElementUserName.Text = "سوپر ادمین";
            // 
            // accordionControlSeparator3
            // 
            accordionControlSeparator3.Name = "accordionControlSeparator3";
            // 
            // accordionControlElementMyProfile
            // 
            accordionControlElementMyProfile.Name = "accordionControlElementMyProfile";
            accordionControlElementMyProfile.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlElementMyProfile.Text = "پروفایل من";
            // 
            // accordionControlElementBill
            // 
            accordionControlElementBill.Name = "accordionControlElementBill";
            accordionControlElementBill.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlElementBill.Text = "صورتحساب";
            // 
            // accordionControlSeparator4
            // 
            accordionControlSeparator4.Name = "accordionControlSeparator4";
            // 
            // accordionControlElementlibrary
            // 
            accordionControlElementlibrary.Name = "accordionControlElementlibrary";
            accordionControlElementlibrary.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlElementlibrary.Text = "library";
            // 
            // accordionControlElementFAQ
            // 
            accordionControlElementFAQ.Name = "accordionControlElementFAQ";
            accordionControlElementFAQ.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlElementFAQ.Text = "سوالات متداول";
            // 
            // accordionControlSeparator5
            // 
            accordionControlSeparator5.Name = "accordionControlSeparator5";
            // 
            // accordionControlUserSwitchUser
            // 
            accordionControlUserSwitchUser.Name = "accordionControlUserSwitchUser";
            accordionControlUserSwitchUser.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlUserSwitchUser.Text = "تغییر کاربر";
            // 
            // accordionControlUserExit
            // 
            accordionControlUserExit.Name = "accordionControlUserExit";
            accordionControlUserExit.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            accordionControlUserExit.Text = "خروج";
            // 
            // navigationGroup
            // 
            navigationGroup.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { accordionControlElementUserAction, accordionControlElementTasks, dashboardViewItem });
            navigationGroup.Expanded = true;
            navigationGroup.Name = "navigationGroup";
            navigationGroup.Text = "ارتباطات";
            navigationGroup.VisibleInFooter = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1296, 706);
            Controls.Add(accordionControlApplication);
            Controls.Add(accordionControlUser);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            DoubleBuffered = true;
            IsMdiContainer = true;
            KeyPreview = true;
            Name = "MainForm";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            RightToLeftLayout = true;
            WindowState = FormWindowState.Maximized;
            FormClosed += MainForm_FormClosed;
            KeyDown += MainForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)accordionControlUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)accordionControlApplication).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemRibbonSearchEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemRibbonSearchEdit2).EndInit();
            ((System.ComponentModel.ISupportInitialize)documentManagerMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabbedView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControlUser;
        private DevExpress.XtraBars.Navigation.AccordionControlElement navigationGroup;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlUsrofile;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementTasks;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControlApplication;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementDashboards;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceRolesForm;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceAccessControlForm;
        private DevExpress.XtraBars.Ribbon.Internal.RepositoryItemRibbonSearchEdit repositoryItemRibbonSearchEdit1;
        private DevExpress.XtraBars.Ribbon.Internal.RepositoryItemRibbonSearchEdit repositoryItemRibbonSearchEdit2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement18;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementUserAction;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementUserName;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator3;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator4;
        private DevExpress.XtraBars.Navigation.AccordionControlSeparator accordionControlSeparator5;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlUserSwitchUser;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlUserExit;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManagerMain;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.Utils.WorkspaceManager workspaceManager1;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement CompanyType;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementMyProfile;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementBill;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementlibrary;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementFAQ;
        private DevExpress.XtraBars.Navigation.AccordionControlElement dashboardViewItem;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.SkinBarSubItem skinBarSubItem1;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.SkinPaletteDropDownButtonItem skinPaletteDropDownButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemWhiteAndDark;
        private DevExpress.XtraBars.BarButtonItem barButtonItemModalMode;
        private DevExpress.XtraBars.BarButtonItem barButtonItemFullScreen;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acePermissionsForm;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceUser;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceUsersForm;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceDocuments;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceDocumentPatternsForm;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceDocumentPatternForm;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceNosaAccountingForm;
    }
}