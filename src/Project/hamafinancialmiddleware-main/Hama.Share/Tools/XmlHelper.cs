using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hama.Share.Tools
{
    public class XmlHelper
    {
        public static string  ExtractVoucherHeader(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
                return string.Empty;

            const string startTag = "<acc:Lines>";
            const string endTag = "</acc:Lines>";

            int startIndex = xml.IndexOf(startTag, StringComparison.OrdinalIgnoreCase);
            int endIndex = xml.IndexOf(endTag, StringComparison.OrdinalIgnoreCase);

            if (startIndex == -1 || endIndex == -1)
                return xml; // اگر پیدا نکرد، کل XML را برگردان

            // حذف بخش بین <acc:Lines> و </acc:Lines>
            string before = xml.Substring(0, startIndex + startTag.Length);
            string after = xml.Substring(endIndex);

            return before + after;
        }
        public static List<string> ExtractVoucherLines(string xml)
        {
            var result = new List<string>();
            if (string.IsNullOrWhiteSpace(xml)) return result;

            const string startTag = "<acc:VoucherLine>";
            const string endTag = "</acc:VoucherLine>";

            int currentIndex = 0;

            while (true)
            {
                int startIndex = xml.IndexOf(startTag, currentIndex, StringComparison.OrdinalIgnoreCase);
                if (startIndex == -1) break;

                int endIndex = xml.IndexOf(endTag, startIndex, StringComparison.OrdinalIgnoreCase);
                if (endIndex == -1) break;

                int length = endIndex + endTag.Length - startIndex;
                string voucherLine = xml.Substring(startIndex, length);

                result.Add(voucherLine.Trim());
                currentIndex = endIndex + endTag.Length;
            }

            return result;
        }
        public static string BuildVoucherXmlWithoutLines(string number, string date, string description, string currency)
        {
            return $@"
<!-- شروع پیام SOAP -->
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:acc=""http://tempuri.org/AccountingService"">
  <!-- هدر پیام -->
  <soapenv:Header/>
  <!-- بدنه پیام -->
  <soapenv:Body>
    <!-- درخواست ثبت سند حسابداری -->
    <acc:InsertVoucher>
      <!-- اطلاعات سند -->
      <acc:Voucher>
        <!-- شماره سند -->
        <acc:VoucherNumber>{number}</acc:VoucherNumber>
        <!-- تاریخ سند -->
        <acc:Date>{date:yyyy-MM-dd}</acc:Date>
        <!-- شرح کلی سند -->
        <acc:Description>{description}</acc:Description>
        <!-- واحد پول -->
        <acc:Currency>{currency}</acc:Currency>
        <!-- لیست بندهای سند -->
        <acc:Lines>";
        }
        public static string BuildVoucherLine(string accountCode, string lineDescription, string debit, string credit)
        {
            return $@"
          <!-- بند سند -->
          <acc:VoucherLine>
            <!-- کد حساب -->
            <acc:AccountCode>{accountCode}</acc:AccountCode>
            <!-- شرح بند سند -->
            <acc:Description>{lineDescription}</acc:Description>
            <!-- بدهکار -->
            <acc:Debit>{debit}</acc:Debit>
            <!-- بستانکار -->
            <acc:Credit>{credit}</acc:Credit>
          </acc:VoucherLine>";
        }
        public static string CloseVoucherXml()
        {
            return @"
        </acc:Lines>
        <!-- پایان لیست بندهای سند -->
      </acc:Voucher>
      <!-- پایان اطلاعات سند -->
    </acc:InsertVoucher>
    <!-- پایان درخواست ثبت سند -->
  </soapenv:Body>
  <!-- پایان بدنه پیام -->
</soapenv:Envelope>
<!-- پایان پیام SOAP -->";
        }

    }
}
