using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hama.WinApp.Views.Forms;

namespace Hama.WinApp.Helpers.UI.Loading
{
    public static class LoadingHelper
    {
        /// <summary>
        /// برای عملیات async که await استفاده می‌کنند (فرم قفل نمی‌شود)
        /// </summary>
        public static async Task ProcessAsync(Form parentForm, Func<Task> operation)
        {
            var waitForm = new WaitFormFancy();
            waitForm.Show(parentForm);
            waitForm.Refresh(); // نمایش سریع فرم

            try
            {
                await Task.Delay(10); // فرصت به UI برای رسم فرم
                await operation.Invoke();
            }
            finally
            {
                if (!waitForm.IsDisposed)
                {
                    waitForm.BeginInvoke(new Action(() => waitForm.Close()));
                }
            }
        }

        /// <summary>
        /// برای عملیات sync که await ندارند (فرم قفل می‌شود، اما نمایش داده می‌شود)
        /// </summary>
        public static void Process(Form parentForm, Action operation)
        {
            var waitForm = new WaitFormFancy();
            waitForm.Show(parentForm);
            waitForm.Refresh(); // 💡 تضمین نمایش فرم

            // اجرای عملیات در پس‌زمینه
            Task.Run(() =>
            {
                try
                {
                    operation();
                }
                finally
                {
                    if (!waitForm.IsDisposed)
                    {
                        waitForm.BeginInvoke(new Action(() => waitForm.Close()));
                    }
                }
            });
        }


        /// <summary>
        /// حالت هوشمند که اگر متد async باشه await می‌کنه، وگرنه sync اجرا می‌کنه
        /// </summary>
        public static Task ProcessAuto(Form parentForm, Delegate operation)
        {
            if (operation is Func<Task> asyncOp)
            {
                return ProcessAsync(parentForm, asyncOp);
            }

            if (operation is Action syncOp)
            {
                Process(parentForm, syncOp);
                return Task.CompletedTask;
            }

            throw new ArgumentException("Unsupported delegate type. Use Action or Func<Task>.");
        }
    }
}
