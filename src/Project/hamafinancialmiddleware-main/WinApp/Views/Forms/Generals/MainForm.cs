using DevExpress.LookAndFeel;
using Hama.WinApp.Views.Forms.DocumentPatterns;
using Hama.WinApp.Views.Forms.Documents;
using Hama.WinApp.Views.Forms.Users;
using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Hama.WinApp.Helpers.UI.Controls;
using Hama.WinApp.Helpers.UI.Notifications;

namespace Hama.WinApp.Views.Forms
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IServiceProvider _provider;
        private readonly FormState formState = new();
        public bool ModalMode = true;
        private bool WhiteDark = true;
        public bool ScreenStatus { get; set; } = true;

        public MainForm(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;

            InitializeDesign();
            AlertHelper.alertControl = alertControl1;
            WhiteDark = true;
            InitializeBackground();
        }

        private void InitializeBackground()
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();

            if (!WhiteDark)
            {
                UserLookAndFeel.Default.SetSkinStyle("WXI", "Sharpness");
                this.BackgroundImage = Properties.Resources.HybridWinApp_Y;
            }
            else
            {
                UserLookAndFeel.Default.SetSkinStyle("WXI", "Calmness");
                this.BackgroundImage = Properties.Resources.HybridWinApp_G;
            }

            WhiteDark = !WhiteDark;
            this.BackgroundImageLayout = ImageLayout.Center;
        }

        private void FullScreen()
        {
            if (ScreenStatus)
            {
                ScreenStatus = false;
                accordionControlUser.Visible = false;
                formState.Maximize(this);
            }
            else
            {
                ScreenStatus = true;
                accordionControlUser.Visible = true;
                formState.Restore(this);
            }
        }

        private void InitializeDesign()
        {
            accordionControlApplication.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
            accordionControlApplication.CollapseAll();

            string currentSkinName = UserLookAndFeel.Default.ActiveSkinName;
            string currentPaletteName = UserLookAndFeel.Default.ActiveSvgPaletteName;

            if (currentSkinName == "WXI" && currentPaletteName == "Sharpness")
                this.BackgroundImage = Properties.Resources.HybridWinApp_Y;

            if (AppContext.GetData("IsRtl") == null || bool.Parse(AppContext.GetData("IsRtl").ToString()))
            {
                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;
            }
            else
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = false;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift)
            {
                if (accordionControlApplication.OptionsMinimizing.State == DevExpress.XtraBars.Navigation.AccordionControlState.Minimized)
                {
                    accordionControlApplication.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Normal;
                    accordionControlApplication.ExpandAll();
                }
                else
                {
                    accordionControlApplication.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
                    accordionControlApplication.CollapseAll();
                }
            }
            else if (e.KeyCode == Keys.F11)
            {
                FullScreen();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            Environment.Exit(0);
        }

        private void barButtonItemWhiteAndDark_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitializeBackground();
        }

        private void barButtonItemModalMode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ModalMode = !ModalMode;
        }

        private void barButtonItemFullScreen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FullScreen();
        }

        private void aceRolesForm_Click(object sender, EventArgs e)
        {
            var form = _provider.GetRequiredService<RolesForm>();
            FormHelper.ShowMdiForm(form, this, ModalMode);
        }

        private void acePermissionsForm_Click(object sender, EventArgs e)
        {
            var form = _provider.GetRequiredService<PermissionsForm>();
            FormHelper.ShowMdiForm(form, this, ModalMode);
        }

        private void aceAccessControlForm_Click(object sender, EventArgs e)
        {
            var form = _provider.GetRequiredService<UserPermissionForm>();
            FormHelper.ShowMdiForm(form, this, ModalMode);
        }

        private void aceUsersForm_Click(object sender, EventArgs e)
        {
            var form = _provider.GetRequiredService<UsersForm>();
            FormHelper.ShowMdiForm(form, this, ModalMode);
        }

        private void aceDocumentPatternsForm_Click(object sender, EventArgs e)
        {
            var form = _provider.GetRequiredService<DocumentPatternCategoriesForm>();
            FormHelper.ShowMdiForm(form, this, ModalMode);
        }

        private void aceDocumentPatternForm_Click(object sender, EventArgs e)
        {
            var form = _provider.GetRequiredService<DocumentPatternForm>();
            FormHelper.ShowMdiForm(form, this, ModalMode);
        }

        private void aceNosaAccountingForm_Click(object sender, EventArgs e)
        {
            var form = _provider.GetRequiredService<NosaAccountingForm>();
            FormHelper.ShowMdiForm(form, this, ModalMode);
        }
    }
}
