using Hama.Core.Models;
using Hama.Service.Interfaces.ORM;
using Hama.Service.Interfaces.Users;
using Hama.Share.Models.Login;
using Hama.WinApp.Helpers.UI.Controls;
using Hama.WinApp.Helpers.UI.Loading;
using Hama.WinApp.Helpers.UI.Notifications;
using Hama.WinApp.Installers;
using Hama.WinApp.Licenses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Hama.WinApp.Views.Forms
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IAuthService _authService;
        private readonly IServiceProvider _provider;
        private EO.WinForm.WebControl webControl1;
        private EO.WebBrowser.WebView webView1;

        public LoginForm(IAuthService authService, IServiceProvider provider)
        {
            InitializeComponent();
            _authService = authService;
            _provider = provider;
            InitializeHTML();
        }

        private void InitializeHTML()
        {
            EO.WebBrowser.Runtime.AddLicense(Licensekey.LicensekeyEO);
            webControl1 = new EO.WinForm.WebControl();
            webView1 = new EO.WebBrowser.WebView();
            webControl1.Dock = DockStyle.Fill;
            webControl1.WebView = webView1;
            var html = Properties.Resources.LoginHtmlGreen;
            webView1.LoadHtml(html);
            Controls.Add(webControl1);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("WXI", "Calmness");
            AlertHelper.alertControl = this.alertControl1;

            pictureEditCaptcha.Image = CaptchaHelper.CreateCaptchaImage();
            this.buttonEditCaptcha.Text = CaptchaHelper.captchaChars;

            progressBarControlLogin.Visible = false;

            if (Debugger.IsAttached)
            {
                cbeUsername.Text = "admin";
                btePassword.Text = "1234";
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    simpleButtonSignIn_Click(sender, e);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            AppContext.SetData("IsRtl", true);
        }

        private async void simpleButtonSignIn_Click(object sender, EventArgs e)
        {
            this.simpleButtonSignIn.Enabled = false;

            await LoadingHelper.ProcessAsync(this, async () =>
            {
                try
                {
                    if (tgsUpdatePrepareData.IsOn)
                    {
                        var installService = new InstallPermissionService(
                          Program.ServiceProvider.GetRequiredService<IBaseRepoDbService<Permission>>(),
                          Program.ServiceProvider.GetRequiredService<IBaseRepoDbService<Role>>(),
                          Program.ServiceProvider.GetRequiredService<IBaseRepoDbService<User>>(),
                          Program.ServiceProvider.GetRequiredService<IBaseServiceEf<Permission>>(),
                          Program.ServiceProvider.GetRequiredService<IBaseServiceEf<Role>>(),
                          Program.ServiceProvider.GetRequiredService<IBaseServiceEf<User>>()
                      );


                        var permissionResult = await installService.ExtractPermissionsFromAllFormsAsync();
                        if (!permissionResult.Success)
                        {
                            AlertHelper.ShowError(this, $"خطا در آماده‌سازی داده‌های اولیه:\n{string.Join("\n", permissionResult.Errors)}", 400);
                            return;
                        }

                        var userResult = await installService.SeedInitialUserAsync();
                        if (!userResult.Success)
                        {
                            AlertHelper.ShowError(this, $"خطا در آماده‌سازی داده‌های اولیه:\n{string.Join("\n", userResult.Errors)}", 400);
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    AlertHelper.ShowError(this, $"خطا در آماده‌سازی داده‌های اولیه:\n{ex.Message}", 400);
                }

                var result = await _authService.LoginAsync(new LoginRequest
                {
                    UserName = cbeUsername.EditValue?.ToString(),
                    Password = btePassword.EditValue?.ToString()
                });

                if (result.Success)
                {
                    AppContext.SetData("CurrentUser", result.Data);
                    AlertHelper.ShowSuccess(this, $"خوش آمدید {result.Data!.UserName}", 200);

                    var mainForm = _provider.GetRequiredService<MainForm>(); // ✅ نسخه DI صحیح
                    this.Hide();
                    mainForm.Show();
                }
                else
                {
                    AlertHelper.ShowError(this, $"ورود ناموفق: {string.Join(", ", result.Errors)}", 400);
                }
            });
        }

        private void buttonEditCaptcha_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            pictureEditCaptcha.Image = CaptchaHelper.CreateCaptchaImage();
        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            layoutControl_Login.Top = (this.Height / 2) - (layoutControl_Login.Height / 2);
            layoutControl_Login.Left = (this.Width / 2) - (layoutControl_Login.Width / 2);
            layoutControlItemCaptcha.Height = 90;
        }

        private void LoginTwo_Shown(object sender, EventArgs e)
        {
            AppContext.SetData("IsRtl", true);
        }
        private void LoginTwo_Resize(object sender, EventArgs e)
        {
            layoutControl_Login.Top = (this.Height / 2) - (layoutControl_Login.Height / 2);
            layoutControl_Login.Left = (this.Width / 2) - (layoutControl_Login.Width / 2);
            layoutControlItemCaptcha.Height = 90;
        }


    }
}
