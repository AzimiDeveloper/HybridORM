using Hama.Share.Models.Nosa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hama.Share.Tools
{
    public class VoucherHelper
    {
        public static VoucherHeaderDto ParseVoucherHeader(string xml)
        {
            return new VoucherHeaderDto
            {
                VoucherNumber = ExtractTagValue(xml, "acc:VoucherNumber"),
                Date = ExtractTagValue(xml, "acc:Date"),
                Description = ExtractTagValue(xml, "acc:Description"),
                Currency = ExtractTagValue(xml, "acc:Currency")
            };
        }
        public static List<VoucherLineDto> ParseVoucherLines(List<string> xmlLines)
        {
            var lines = new List<VoucherLineDto>();

            foreach (var line in xmlLines)
            {
                var dto = new VoucherLineDto
                {
                    AccountCode =  ExtractTagValue(line, "acc:AccountCode"),
                    Description = ExtractTagValue(line, "acc:Description"),
                    Debit = ExtractTagValue(line, "acc:Debit"),
                    Credit = ExtractTagValue(line, "acc:Credit")
                };

                lines.Add(dto);
            }

            return lines;
        }
        private static string ExtractTagValue(string xml, string tag)
        {
            int start = xml.IndexOf($"<{tag}>", StringComparison.OrdinalIgnoreCase);
            int end = xml.IndexOf($"</{tag}>", StringComparison.OrdinalIgnoreCase);

            if (start == -1 || end == -1 || end <= start)
                return string.Empty;

            int contentStart = start + tag.Length + 2; // طول بازشده <tag>
            return xml.Substring(contentStart, end - contentStart).Trim();
        }
        public static string BuildVoucherXml(VoucherDto voucher)
        {
            var sb = new StringBuilder();

            // شروع ساختار پیام SOAP
            sb.AppendLine("<!-- شروع پیام SOAP -->");
            sb.AppendLine(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:acc=""http://tempuri.org/AccountingService"">");

            // هدر پیام (تهی است در نوسا)
            sb.AppendLine("  <soapenv:Header/>");

            // بدنه اصلی پیام SOAP
            sb.AppendLine("  <soapenv:Body>");
            sb.AppendLine("    <acc:InsertVoucher>");
            sb.AppendLine("      <acc:Voucher>");

            // مشخصات هدر سند: شماره، تاریخ، شرح و واحد پول
            sb.AppendLine($"        <acc:VoucherNumber>{voucher.Header.VoucherNumber}</acc:VoucherNumber>");
            sb.AppendLine($"        <acc:Date>{voucher.Header.Date}</acc:Date>");
            sb.AppendLine($"        <acc:Description>{voucher.Header.Description}</acc:Description>");
            sb.AppendLine($"        <acc:Currency>{voucher.Header.Currency}</acc:Currency>");

            // شروع بخش بندهای سند (Lines)
            sb.AppendLine("        <acc:Lines>");

            // حلقه ساخت بندهای سند
            foreach (var line in voucher.Lines)
            {
                sb.AppendLine("          <acc:VoucherLine>");
                sb.AppendLine($"            <acc:AccountCode>{line.AccountCode}</acc:AccountCode>");
                sb.AppendLine($"            <acc:Description>{line.Description}</acc:Description>");
                sb.AppendLine($"            <acc:Debit>{line.Debit}</acc:Debit>");
                sb.AppendLine($"            <acc:Credit>{line.Credit}</acc:Credit>");
                sb.AppendLine("          </acc:VoucherLine>");
            }

            // پایان لیست بندها و اطلاعات سند
            sb.AppendLine("        </acc:Lines>");
            sb.AppendLine("      </acc:Voucher>");
            sb.AppendLine("    </acc:InsertVoucher>");
            sb.AppendLine("  </soapenv:Body>");
            sb.AppendLine("</soapenv:Envelope>");

            // پایان پیام SOAP
            sb.AppendLine("<!-- پایان پیام SOAP -->");

            return sb.ToString();
        }


    }
}
