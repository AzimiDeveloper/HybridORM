using DevExpress.XtraBars;
using System.Windows.Forms;
using System.Windows;

namespace Hama.WinApp.Views.Forms
{
    partial class LoginForm
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
            layoutControl_Login = new DevExpress.XtraLayout.LayoutControl();
            tgsUpdatePrepareData = new DevExpress.XtraEditors.ToggleSwitch();
            barManager1 = new BarManager(components);
            bar1 = new Bar();
            skinPaletteDropDownButtonItem1 = new SkinPaletteDropDownButtonItem();
            barDockControlTop = new BarDockControl();
            barDockControlBottom = new BarDockControl();
            barDockControlLeft = new BarDockControl();
            barDockControlRight = new BarDockControl();
            skinDropDownButtonItem1 = new SkinDropDownButtonItem();
            buttonEditCaptcha = new DevExpress.XtraEditors.ButtonEdit();
            pictureEditCaptcha = new DevExpress.XtraEditors.PictureEdit();
            simpleButtonSignIn = new DevExpress.XtraEditors.SimpleButton();
            btePassword = new DevExpress.XtraEditors.ButtonEdit();
            cbeUsername = new DevExpress.XtraEditors.ComboBoxEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItemCaptcha = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            lciUpdatePrepareData = new DevExpress.XtraLayout.LayoutControlItem();
            progressBarControlLogin = new DevExpress.XtraEditors.ProgressBarControl();
            barManager2 = new BarManager(components);
            bar6 = new Bar();
            barDockControl1 = new BarDockControl();
            barDockControl2 = new BarDockControl();
            barDockControl3 = new BarDockControl();
            barDockControl4 = new BarDockControl();
            alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(components);
            ((System.ComponentModel.ISupportInitialize)layoutControl_Login).BeginInit();
            layoutControl_Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tgsUpdatePrepareData.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)buttonEditCaptcha.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEditCaptcha.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btePassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbeUsername.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemCaptcha).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem16).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lciUpdatePrepareData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)progressBarControlLogin.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)barManager2).BeginInit();
            SuspendLayout();
            // 
            // layoutControl_Login
            // 
            layoutControl_Login.BackColor = System.Drawing.Color.White;
            layoutControl_Login.Controls.Add(tgsUpdatePrepareData);
            layoutControl_Login.Controls.Add(buttonEditCaptcha);
            layoutControl_Login.Controls.Add(pictureEditCaptcha);
            layoutControl_Login.Controls.Add(simpleButtonSignIn);
            layoutControl_Login.Controls.Add(btePassword);
            layoutControl_Login.Controls.Add(cbeUsername);
            layoutControl_Login.Controls.Add(labelControl1);
            layoutControl_Login.Location = new System.Drawing.Point(274, 117);
            layoutControl_Login.Name = "layoutControl_Login";
            layoutControl_Login.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(947, 240, 776, 680);
            layoutControl_Login.OptionsView.RightToLeftMirroringApplied = true;
            layoutControl_Login.Root = Root;
            layoutControl_Login.Size = new System.Drawing.Size(350, 400);
            layoutControl_Login.TabIndex = 5;
            layoutControl_Login.Text = "layoutControl1";
            // 
            // tgsUpdatePrepareData
            // 
            tgsUpdatePrepareData.Location = new System.Drawing.Point(12, 218);
            tgsUpdatePrepareData.MenuManager = barManager1;
            tgsUpdatePrepareData.Name = "tgsUpdatePrepareData";
            tgsUpdatePrepareData.Properties.OffText = "غیرفعال";
            tgsUpdatePrepareData.Properties.OnText = "فعال";
            tgsUpdatePrepareData.Size = new System.Drawing.Size(160, 18);
            tgsUpdatePrepareData.StyleController = layoutControl_Login;
            tgsUpdatePrepareData.TabIndex = 5;
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new Bar[] { bar1 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.Form = this;
            barManager1.Items.AddRange(new BarItem[] { skinDropDownButtonItem1, skinPaletteDropDownButtonItem1 });
            barManager1.MaxItemId = 2;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(skinPaletteDropDownButtonItem1) });
            bar1.Text = "Tools";
            // 
            // skinPaletteDropDownButtonItem1
            // 
            skinPaletteDropDownButtonItem1.ActAsDropDown = true;
            skinPaletteDropDownButtonItem1.ButtonStyle = BarButtonStyle.DropDown;
            skinPaletteDropDownButtonItem1.Id = 1;
            skinPaletteDropDownButtonItem1.Name = "skinPaletteDropDownButtonItem1";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new System.Drawing.Size(939, 24);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 702);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new System.Drawing.Size(939, 0);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 678);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(939, 24);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 678);
            // 
            // skinDropDownButtonItem1
            // 
            skinDropDownButtonItem1.ActAsDropDown = true;
            skinDropDownButtonItem1.ButtonStyle = BarButtonStyle.DropDown;
            skinDropDownButtonItem1.Id = 0;
            skinDropDownButtonItem1.Name = "skinDropDownButtonItem1";
            // 
            // buttonEditCaptcha
            // 
            buttonEditCaptcha.Location = new System.Drawing.Point(12, 194);
            buttonEditCaptcha.Name = "buttonEditCaptcha";
            buttonEditCaptcha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            buttonEditCaptcha.Size = new System.Drawing.Size(160, 20);
            buttonEditCaptcha.StyleController = layoutControl_Login;
            buttonEditCaptcha.TabIndex = 3;
            buttonEditCaptcha.ButtonClick += buttonEditCaptcha_ButtonClick;
            // 
            // pictureEditCaptcha
            // 
            pictureEditCaptcha.Location = new System.Drawing.Point(12, 102);
            pictureEditCaptcha.Name = "pictureEditCaptcha";
            pictureEditCaptcha.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEditCaptcha.Size = new System.Drawing.Size(160, 88);
            pictureEditCaptcha.StyleController = layoutControl_Login;
            pictureEditCaptcha.TabIndex = 1;
            // 
            // simpleButtonSignIn
            // 
            simpleButtonSignIn.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            simpleButtonSignIn.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            simpleButtonSignIn.Appearance.Options.UseBackColor = true;
            simpleButtonSignIn.Appearance.Options.UseFont = true;
            simpleButtonSignIn.Location = new System.Drawing.Point(12, 240);
            simpleButtonSignIn.MinimumSize = new System.Drawing.Size(0, 30);
            simpleButtonSignIn.Name = "simpleButtonSignIn";
            simpleButtonSignIn.Size = new System.Drawing.Size(326, 30);
            simpleButtonSignIn.StyleController = layoutControl_Login;
            simpleButtonSignIn.TabIndex = 4;
            simpleButtonSignIn.Text = "ورود";
            simpleButtonSignIn.Click += simpleButtonSignIn_Click;
            // 
            // btePassword
            // 
            btePassword.Location = new System.Drawing.Point(12, 78);
            btePassword.Name = "btePassword";
            btePassword.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(), new DevExpress.XtraEditors.Controls.EditorButton() });
            btePassword.Size = new System.Drawing.Size(160, 20);
            btePassword.StyleController = layoutControl_Login;
            btePassword.TabIndex = 2;
            // 
            // cbeUsername
            // 
            cbeUsername.Location = new System.Drawing.Point(12, 54);
            cbeUsername.Name = "cbeUsername";
            cbeUsername.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbeUsername.Size = new System.Drawing.Size(160, 20);
            cbeUsername.StyleController = layoutControl_Login;
            cbeUsername.TabIndex = 0;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Appearance.Options.UseTextOptions = true;
            labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl1.Location = new System.Drawing.Point(12, 12);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(326, 38);
            labelControl1.StyleController = layoutControl_Login;
            labelControl1.TabIndex = 1;
            labelControl1.Text = "Hama MiddleWare";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, emptySpaceItem1, layoutControlItem4, layoutControlItem5, layoutControlItem8, layoutControlItemCaptcha, layoutControlItem16, lciUpdatePrepareData });
            Root.Name = "Root";
            Root.Size = new System.Drawing.Size(350, 400);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = labelControl1;
            layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new System.Drawing.Size(330, 42);
            layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            emptySpaceItem1.AllowHotTrack = false;
            emptySpaceItem1.Location = new System.Drawing.Point(0, 262);
            emptySpaceItem1.Name = "emptySpaceItem1";
            emptySpaceItem1.Size = new System.Drawing.Size(330, 118);
            emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem4.Control = cbeUsername;
            layoutControlItem4.Location = new System.Drawing.Point(0, 42);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.Size = new System.Drawing.Size(330, 24);
            layoutControlItem4.Text = "نام کاربری :";
            layoutControlItem4.TextSize = new System.Drawing.Size(154, 17);
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem5.Control = btePassword;
            layoutControlItem5.Location = new System.Drawing.Point(0, 66);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new System.Drawing.Size(330, 24);
            layoutControlItem5.Text = "رمز عبور :";
            layoutControlItem5.TextSize = new System.Drawing.Size(154, 17);
            // 
            // layoutControlItem8
            // 
            layoutControlItem8.Control = simpleButtonSignIn;
            layoutControlItem8.Location = new System.Drawing.Point(0, 228);
            layoutControlItem8.Name = "layoutControlItem8";
            layoutControlItem8.Size = new System.Drawing.Size(330, 34);
            layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItemCaptcha
            // 
            layoutControlItemCaptcha.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            layoutControlItemCaptcha.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItemCaptcha.Control = pictureEditCaptcha;
            layoutControlItemCaptcha.Location = new System.Drawing.Point(0, 90);
            layoutControlItemCaptcha.MinSize = new System.Drawing.Size(190, 60);
            layoutControlItemCaptcha.Name = "layoutControlItemCaptcha";
            layoutControlItemCaptcha.Size = new System.Drawing.Size(330, 92);
            layoutControlItemCaptcha.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItemCaptcha.Text = "کد کپچا :";
            layoutControlItemCaptcha.TextSize = new System.Drawing.Size(154, 17);
            // 
            // layoutControlItem16
            // 
            layoutControlItem16.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F);
            layoutControlItem16.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem16.Control = buttonEditCaptcha;
            layoutControlItem16.Location = new System.Drawing.Point(0, 182);
            layoutControlItem16.Name = "layoutControlItem16";
            layoutControlItem16.Size = new System.Drawing.Size(330, 24);
            layoutControlItem16.Text = "برای اصلاح کد کلیک کنید :";
            layoutControlItem16.TextSize = new System.Drawing.Size(154, 17);
            // 
            // lciUpdatePrepareData
            // 
            lciUpdatePrepareData.Control = tgsUpdatePrepareData;
            lciUpdatePrepareData.Location = new System.Drawing.Point(0, 206);
            lciUpdatePrepareData.Name = "lciUpdatePrepareData";
            lciUpdatePrepareData.Size = new System.Drawing.Size(330, 22);
            lciUpdatePrepareData.Text = "بازسازی و بروزرسانی پایه";
            lciUpdatePrepareData.TextLocation = DevExpress.Utils.Locations.Right;
            lciUpdatePrepareData.TextSize = new System.Drawing.Size(154, 13);
            // 
            // progressBarControlLogin
            // 
            progressBarControlLogin.Dock = DockStyle.Top;
            progressBarControlLogin.Location = new System.Drawing.Point(0, 24);
            progressBarControlLogin.Name = "progressBarControlLogin";
            progressBarControlLogin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            progressBarControlLogin.Size = new System.Drawing.Size(939, 3);
            progressBarControlLogin.TabIndex = 7;
            // 
            // barManager2
            // 
            barManager2.Bars.AddRange(new Bar[] { bar6 });
            barManager2.DockControls.Add(barDockControl1);
            barManager2.DockControls.Add(barDockControl2);
            barManager2.DockControls.Add(barDockControl3);
            barManager2.DockControls.Add(barDockControl4);
            barManager2.Form = this;
            barManager2.StatusBar = bar6;
            // 
            // bar6
            // 
            bar6.BarName = "Status bar";
            bar6.CanDockStyle = BarCanDockStyle.Bottom;
            bar6.DockCol = 0;
            bar6.DockRow = 0;
            bar6.DockStyle = BarDockStyle.Bottom;
            bar6.OptionsBar.AllowQuickCustomization = false;
            bar6.OptionsBar.DrawDragBorder = false;
            bar6.OptionsBar.UseWholeRow = true;
            bar6.Text = "Status bar";
            // 
            // barDockControl1
            // 
            barDockControl1.CausesValidation = false;
            barDockControl1.Dock = DockStyle.Top;
            barDockControl1.Location = new System.Drawing.Point(0, 0);
            barDockControl1.Manager = barManager2;
            barDockControl1.Size = new System.Drawing.Size(939, 0);
            // 
            // barDockControl2
            // 
            barDockControl2.CausesValidation = false;
            barDockControl2.Dock = DockStyle.Bottom;
            barDockControl2.Location = new System.Drawing.Point(0, 702);
            barDockControl2.Manager = barManager2;
            barDockControl2.Size = new System.Drawing.Size(939, 20);
            // 
            // barDockControl3
            // 
            barDockControl3.CausesValidation = false;
            barDockControl3.Dock = DockStyle.Left;
            barDockControl3.Location = new System.Drawing.Point(0, 0);
            barDockControl3.Manager = barManager2;
            barDockControl3.Size = new System.Drawing.Size(0, 702);
            // 
            // barDockControl4
            // 
            barDockControl4.CausesValidation = false;
            barDockControl4.Dock = DockStyle.Right;
            barDockControl4.Location = new System.Drawing.Point(939, 0);
            barDockControl4.Manager = barManager2;
            barDockControl4.Size = new System.Drawing.Size(0, 702);
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
            // LoginForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(939, 722);
            Controls.Add(progressBarControlLogin);
            Controls.Add(layoutControl_Login);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Controls.Add(barDockControl3);
            Controls.Add(barDockControl4);
            Controls.Add(barDockControl2);
            Controls.Add(barDockControl1);
            KeyPreview = true;
            MinimizeBox = false;
            Name = "LoginForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            FormClosed += Login_FormClosed;
            Load += Login_Load;
            Shown += LoginTwo_Shown;
            KeyDown += Login_KeyDown;
            Resize += LoginTwo_Resize;
            ((System.ComponentModel.ISupportInitialize)layoutControl_Login).EndInit();
            layoutControl_Login.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tgsUpdatePrepareData.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)buttonEditCaptcha.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEditCaptcha.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)btePassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbeUsername.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)emptySpaceItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItemCaptcha).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem16).EndInit();
            ((System.ComponentModel.ISupportInitialize)lciUpdatePrepareData).EndInit();
            ((System.ComponentModel.ISupportInitialize)progressBarControlLogin.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)barManager2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl layoutControl_Login;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSignIn;
        private DevExpress.XtraEditors.ButtonEdit btePassword;
        private DevExpress.XtraEditors.ComboBoxEdit cbeUsername;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.PictureEdit pictureEditCaptcha;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemCaptcha;
        private DevExpress.XtraEditors.ButtonEdit buttonEditCaptcha;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControlLogin;
        private BarManager barManager1;
        private Bar bar1;
        private SkinDropDownButtonItem skinDropDownButtonItem1;
        private SkinPaletteDropDownButtonItem skinPaletteDropDownButtonItem1;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControl3;
        private BarManager barManager2;
        private Bar bar6;
        private BarDockControl barDockControl1;
        private BarDockControl barDockControl2;
        private BarDockControl barDockControl4;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraEditors.ToggleSwitch tgsUpdatePrepareData;
        private DevExpress.XtraLayout.LayoutControlItem lciUpdatePrepareData;
    }
}