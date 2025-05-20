using DevExpress.Utils.Svg;
using DevExpress.XtraBars.Alerter;
using Hama.WinApp.Helpers.UI.Loading;
using System;
using System.Windows.Forms;

namespace Hama.WinApp.Helpers.UI.Notifications
{

    public static class AlertHelper
    {
        public static AlertControl alertControl;

        public static void ShowCustomMessage(Form frm, string caption, string text, SvgImage svgImage, int? statusCode = null)
        {
            ExecuteOnUIThread(frm, () =>
            {
                var finalText = FormatMessage(caption, text, statusCode);
                alertControl.AppearanceText.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.WindowText;
                alertControl.AppearanceCaption.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
                alertControl.Show(frm, caption, finalText, "", svgImage, null);
            });
        }

        public static void ShowSuccess(Form frm, string text, int? statusCode = null)
        {
            if (string.IsNullOrEmpty(text))
                text = "عملیات درخواستی با موفقیت انجام شد";

            ExecuteOnUIThread(frm, () =>
            {
                var finalText = FormatMessage("موفقیت", text, statusCode);
                alertControl.AppearanceText.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.WindowText;
                alertControl.AppearanceCaption.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
                alertControl.Show(frm, "موفقیت", finalText, "", SVGHelper.GetSVGImage(SVGHelper.enumSVGDevExpress.SVG_paymentpaid), null);
            });
        }

        public static void ShowError(Form frm, string text, int? statusCode = null)
        {
            if (string.IsNullOrEmpty(text))
                text = "عملیات درخواستی با خطا مواجه شد";

            ExecuteOnUIThread(frm, () =>
            {
                var finalText = FormatMessage("خطا", text, statusCode);
                alertControl.AppearanceText.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.WindowText;
                alertControl.AppearanceCaption.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
                alertControl.Show(frm, "خطا", finalText, "", SVGHelper.GetSVGImage(SVGHelper.enumSVGDevExpress.SVG_paymentunpaid), null);
            });
        }

        public static void ShowWarning(Form frm, string text, int? statusCode = null)
        {
            ExecuteOnUIThread(frm, () =>
            {
                var finalText = FormatMessage("هشدار", text, statusCode);
                alertControl.AppearanceText.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.WindowText;
                alertControl.AppearanceCaption.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Warning;
                alertControl.Show(frm, "هشدار", finalText, "", SVGHelper.GetSVGImage(SVGHelper.enumSVGDevExpress.SVG_bo_attention), null);
            });
        }

        public static void ShowInformation(Form frm, string text, int? statusCode = null)
        {
            ExecuteOnUIThread(frm, () =>
            {
                var finalText = FormatMessage("اطلاعات", text, statusCode);
                alertControl.AppearanceText.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.WindowText;
                alertControl.AppearanceCaption.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
                alertControl.Show(frm, "اطلاعات", finalText, "", SVGHelper.GetSVGImage(SVGHelper.enumSVGDevExpress.SVG_bo_attention), null);
            });
        }

        private static string FormatMessage(string caption, string message, int? statusCode)
        {
            var sb = new System.Text.StringBuilder();

            if (statusCode.HasValue)
                sb.AppendLine($"{caption} : کد {statusCode.Value}");

            // اگر message با همون caption شروع می‌شه، حذفش کن
            if (message!= null && message.StartsWith($"{caption} :", StringComparison.OrdinalIgnoreCase))
            {
                message = message.Substring($"{caption} :".Length).TrimStart();
            }

            sb.AppendLine(message);
            return sb.ToString().Trim();
        }


        private static void ExecuteOnUIThread(Form frm, Action action)
        {
            if (frm.InvokeRequired)
                frm.Invoke(action);
            else
                action();
        }
    }
}