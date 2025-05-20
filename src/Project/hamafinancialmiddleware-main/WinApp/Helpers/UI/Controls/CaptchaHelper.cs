using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hama.WinApp.Helpers.UI.Controls
{
    public static class CaptchaHelper
    {
        public static string captchaChars { get; set; }

        public static Bitmap CreateCaptchaImage()
        {
            Random r1 = new Random();
            captchaChars = r1.Next(1000, 9999).ToString();
            var image = new Bitmap(116, 35);
            var font = new Font("TimesNewRoman", 22, FontStyle.Bold/*, GraphicsUnit.Pixel*/);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString(captchaChars, font, Brushes.DeepSkyBlue, new Point(0, 0));
            return image;
        }
    }
}
