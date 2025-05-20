using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Text.Json;

namespace Hama.WinApp.Views.Components
{
    public partial class CustomHTMLViewer: UserControl
    {
        public CustomHTMLViewer()
        {
            InitializeComponent();
        }

        public bool ValidateXml(string escapedXmlString, string xsdPath, out string? validationError)
        {
            validationError = null;
            bool isValid = true;
            string? localError = null;

            try
            {
                // مرحله 1: تمیز کردن رشته escape‌شده
                var decodedXml = JsonSerializer.Deserialize<string>(escapedXmlString); // تبدیل به XML واقعی
                if (decodedXml == null)
                {
                    validationError = "رشته XML پس از تبدیل مقدار ندارد.";
                    return false;
                }

                decodedXml = CleanXml(decodedXml); // حذف BOM و فاصله اضافی

                // مرحله 2: تبدیل به XmlDocument و پیدا کردن عنصر InsertVoucher
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(decodedXml);

                var mgr = new XmlNamespaceManager(xmlDoc.NameTable);
                mgr.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
                mgr.AddNamespace("acc", "http://tempuri.org/AccountingService");

                var insertVoucherNode = xmlDoc.SelectSingleNode("//acc:InsertVoucher", mgr);
                if (insertVoucherNode == null)
                {
                    validationError = "عنصر InsertVoucher یافت نشد.";
                    return false;
                }

                // مرحله 3: تنظیم XSD و اعتبارسنجی
                var settings = new XmlReaderSettings();
                settings.Schemas.Add("http://tempuri.org/AccountingService", xsdPath);
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

                settings.ValidationEventHandler += (sender, e) =>
                {
                    isValid = false;
                    localError = e.Message;
                };

                using var nodeReader = new XmlNodeReader(insertVoucherNode);
                using var validatingReader = XmlReader.Create(nodeReader, settings);
                while (validatingReader.Read()) { }

                validationError = localError;
                return isValid;
            }
            catch (Exception ex)
            {
                validationError = ex.Message;
                return false;
            }
        }

        public string CleanXml(string input)
        {
            return input.Trim('\uFEFF', '\u200B', '\u200E', '\u200F').Trim();
        }


        public bool IsValidXml(string xml)
        {
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(xml);
                return true;
            }
            catch (XmlException ex)
            {
                return false;
            }
        }
        public async Task LoadXmlToHTML(string _xml)
        {
            try
            {
                // تنظیم مسیر فایل HTML پیش‌نمایش
                string path = Path.Combine(Application.StartupPath, "wwwroot", "monaco", "preview.html");
                previewWebView.Source = new Uri(path);

                // اطمینان از راه‌اندازی WebView2
                if (previewWebView.CoreWebView2 == null)
                    await previewWebView.EnsureCoreWebView2Async();

                // صبر تا زمانی که تابع جاوااسکریپتی آماده شود
                while (true)
                {
                    var ready = await previewWebView.CoreWebView2.ExecuteScriptAsync("typeof window.setXmlData === 'function'");
                    if (ready.Trim('"') == "true")
                        break;

                    await Task.Delay(100);
                }

                // تبدیل XML به رشته امن جاوااسکریپت
                string jsEncoded = System.Text.Json.JsonSerializer.Serialize(_xml);

                // ارسال به تابع جاوااسکریپتی
                await previewWebView.CoreWebView2.ExecuteScriptAsync($"window.setXmlData({jsEncoded});");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, "خطا در بارگذاری پیش‌نمایش: " + ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
