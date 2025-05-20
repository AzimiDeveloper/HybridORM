using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Hama.WinApp.Helpers.UI.Notifications;

namespace Hama.WinApp.Views.Components
{
    public partial class CustomXMLEditor : UserControl
    {
        public CustomXMLEditor()
        {
            InitializeComponent();
        }
        public async Task LoadXML()
        {
            try
            {
                string htmlPath = Path.Combine(Application.StartupPath, "wwwroot", "monaco", "monaco.html");
                XMLEditor.Source = new Uri(htmlPath);

                if (XMLEditor.CoreWebView2 == null)
                    await XMLEditor.EnsureCoreWebView2Async();

                while (true)
                {
                    string ready = await XMLEditor.CoreWebView2.ExecuteScriptAsync("window.editorReady === true");
                    if (ready.Trim('"') == "true") break;
                    await Task.Delay(100);
                }

            }
            catch (Exception ex)
            {
                AlertHelper.ShowError(this.ParentForm, $"خطا در آماده سازی سند :\n{string.Join("\n", ex.Message)}\n{string.Join("\n", ex.InnerException.Message)}", 400);
            }
        }
        public async Task<string> getValue()
        {
            return await this.XMLEditor.ExecuteScriptAsync("window.getEditorValue()");
        }
        public async Task InsertTextToEditor(string text)
        {
            try
            {
                if (XMLEditor.CoreWebView2 != null)
                {
                    string safeText = text
                        .Replace("\\", "\\\\")
                        .Replace("'", "\\'")
                        .Replace("\"", "\\\"")
                        .Replace("\r", "")
                        .Replace("\n", "\\n");

                    string js = $"window.insertText('{safeText}')";
                    await XMLEditor.CoreWebView2.ExecuteScriptAsync(js);
                }
            }
            catch (Exception ex)
            {
                AlertHelper.ShowError(this.ParentForm, $"خطا در درج متن به سند :\n{string.Join("\n", ex.Message)}\n{string.Join("\n", ex.InnerException.Message)}", 400);
            }
        }
        public async Task InsertContentInsideLinesAsync(string content)
        {
            try
            {
                if (XMLEditor.CoreWebView2 == null)
                    await XMLEditor.EnsureCoreWebView2Async();

                while (true)
                {
                    var ready = await XMLEditor.CoreWebView2.ExecuteScriptAsync("window.editorReady === true");
                    if (ready.Trim('"') == "true") break;
                    await Task.Delay(100);
                }

                var rawValue = await XMLEditor.CoreWebView2.ExecuteScriptAsync("window.getEditorValue()");
                var xml = System.Text.Json.JsonSerializer.Deserialize<string>(rawValue);

                var tag = "</acc:Lines>";
                var index = xml.IndexOf(tag);
                if (index == -1) return;

                int lineStart = xml.LastIndexOf('\n', index);
                string line = xml.Substring(lineStart + 1, index - lineStart - 1);
                string indentation = new string(line.TakeWhile(char.IsWhiteSpace).ToArray());

                // حذف فاصله‌های ابتدایی/انتهایی content، سپس indent هر خط
                string formattedContent = string.Join(
                    "\n",
                    content.Trim().Split('\n').Select(line => indentation + line.TrimEnd())
                );

                string before = xml.Substring(0, index).TrimEnd();
                string after = xml.Substring(index);

                string newXml = before + "\n" + formattedContent + "\n" + indentation + after;

                var jsonEncoded = System.Text.Json.JsonSerializer.Serialize(newXml);
                await XMLEditor.CoreWebView2.ExecuteScriptAsync($"window.editor.setValue({jsonEncoded});");
            }
            catch (Exception ex)
            {
                AlertHelper.ShowError(this.ParentForm, $"خطا در درج بند سند :\n{string.Join("\n", ex.Message)}\n{string.Join("\n", ex.InnerException.Message)}", 400);
            }
        }
        public async Task ClearEditorAsync()
        {
            try
            {
                if (XMLEditor.CoreWebView2 == null)
                    await XMLEditor.EnsureCoreWebView2Async();

                while (true)
                {
                    string ready = await XMLEditor.CoreWebView2.ExecuteScriptAsync("window.editorReady === true");
                    if (ready.Trim('"') == "true") break;
                    await Task.Delay(100);
                }

                // مقدار پیش‌فرض به جای رشته‌ی خالی
                string defaultXml = "";
                string safeText = defaultXml.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "\\n");
                await XMLEditor.CoreWebView2.ExecuteScriptAsync($"window.editor.setValue(\"{safeText}\");");
            }
            catch (Exception ex)
            {
                AlertHelper.ShowError(this.ParentForm, $"خطا در حذف متن سند :\n{string.Join("\n", ex.Message)}\n{string.Join("\n", ex.InnerException.Message)}", 400);
            }
        }



    }
}
