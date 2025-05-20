using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hama.WinApp.Views.Forms
{
    public partial class WaitFormFancy : XtraForm
    {
        private readonly Stopwatch _stopwatch = new();
        private bool _isTimerRunning = false;

        public WaitFormFancy()
        {
            InitializeComponent();
            InitializeUI();
            // ⏱️ Start timer
            _stopwatch.Start();
            _isTimerRunning = true;
            _ = UpdateTimerTextAsync(); // Fire and forget
        }

        private void InitializeUI()
        {
            this.Region = Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.Size = new Size(300, 120);
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Opacity = 0;
            this.Load += WaitFormFancy_Load;
        }

        private async void WaitFormFancy_Load(object sender, EventArgs e)
        {
            try
            {
                for (double opacity = 0; opacity <= 1; opacity += 0.05)
                {
                    if (this.IsDisposed) return;
                    this.Opacity = opacity;
                    await Task.Delay(50);
                }
                this.Opacity = 1;


            }
            catch { }
        }

        private async Task UpdateTimerTextAsync()
        {
            while (_isTimerRunning && !this.IsDisposed)
            {
                var elapsed = _stopwatch.Elapsed;
                var elapsedText = $"{elapsed.Minutes:D2}:{elapsed.Seconds:D2}.{elapsed.Milliseconds / 100:D1}";

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        progressPanel1.Description = $"در حال پردازش ({elapsedText})";
                    }));
                }
                else
                {
                    progressPanel1.Description = $"در حال پردازش ({elapsedText})";
                }

                await Task.Delay(100);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _isTimerRunning = false;
            _stopwatch.Stop();
            base.OnFormClosing(e);
        }

        internal static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
            public static extern IntPtr CreateRoundRectRgn(
                int nLeftRect,
                int nTopRect,
                int nRightRect,
                int nBottomRect,
                int nWidthEllipse,
                int nHeightEllipse);
        }
    }
}
