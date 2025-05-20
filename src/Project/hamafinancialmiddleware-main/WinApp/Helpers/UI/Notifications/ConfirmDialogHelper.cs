using DevExpress.XtraEditors;
using DevExpress.Utils.Svg;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using Hama.WinApp.Helpers.UI.Loading;

namespace Hama.WinApp.Helpers.UI.Notifications
{
    public static class ConfirmDialogHelper
    {
        public static DialogResult Show(string message, string title = "تأیید عملیات", string positiveText = "تأیید", string negativeText = "لغو")
        {
            // نمایش پس‌زمینه نیمه‌شفاف
            var backdrop = new Form
            {
                BackColor = Color.Black,
                Opacity = 0.3,
                ShowInTaskbar = false,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual,
                Size = Screen.PrimaryScreen.Bounds.Size,
                Location = new Point(0, 0),
                TopMost = true
            };
            backdrop.Show();

            var form = new XtraForm
            {
                StartPosition = FormStartPosition.CenterScreen,
                Text = title,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ControlBox = true,
                ShowIcon = false,
                ShowInTaskbar = false,
                Size = new Size(420, 180),
                TopMost = true,
                BackColor = UserLookAndFeel.Default.SkinMaskColor,
                FormBorderEffect = FormBorderEffect.Shadow
            };

            // انیمیشن نمایش فرم
            form.Opacity = 0;
            var fadeIn = new Timer { Interval = 10 };
            fadeIn.Tick += (s, e) =>
            {
                if (form.Opacity < 1)
                    form.Opacity += 0.08;
                else
                    fadeIn.Stop();
            };
            fadeIn.Start();

            var lblMessage = new Label
            {
                Text = message,
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Tahoma", 10f, FontStyle.Regular),
                ForeColor = DXSkinColors.ForeColors.ControlText
            };

            // دکمه تأیید
            var btnYes = new SimpleButton
            {
                Font = new Font("B Titr", 10f, FontStyle.Regular),
                Text = positiveText,
                DialogResult = DialogResult.Yes,
                Width = 110,
                Height = 36,
                LookAndFeel = { UseDefaultLookAndFeel = true },
                ImageOptions =
                {
                    SvgImage = SVGHelper.GetSVGImage(SVGHelper.enumSVGDevExpress.SVG_checkbox),
                    SvgImageSize = new Size(24, 24),
                    SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full
                },
            };
            btnYes.Appearance.ForeColor = DXSkinColors.ForeColors.Information;

            // دکمه لغو
            var btnNo = new SimpleButton
            {
                Font = new Font("B Titr", 10f, FontStyle.Regular),
                Text = negativeText,
                DialogResult = DialogResult.No,
                Width = 100,
                Height = 36,
                LookAndFeel = { UseDefaultLookAndFeel = true },
                ImageOptions =
                {
                    SvgImage = SVGHelper.GetSVGImage(SVGHelper.enumSVGDevExpress.SVG_cancel),
                    SvgImageSize = new Size(24, 24),
                    SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full
                }
            };
            btnNo.Appearance.ForeColor = DXSkinColors.ForeColors.Critical;

            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(10),
                Height = 60,
                BackColor = Color.Transparent
            };
            buttonPanel.Controls.Add(btnNo);
            buttonPanel.Controls.Add(btnYes);

            form.Controls.Add(lblMessage);
            form.Controls.Add(buttonPanel);
            form.AcceptButton = btnYes;
            form.CancelButton = btnNo;

            // گوشه گرد
            form.Region = Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, form.Width, form.Height, 20, 20));

            var result = form.ShowDialog();

            backdrop.Close();
            backdrop.Dispose();

            return result;
        }
    }

    internal static class NativeMethods
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern nint CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
    }
}
