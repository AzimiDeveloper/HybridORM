using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hama.Share.Models.Nosa
{
    public class VoucherLineDto
    {
        public string AccountCode { get; set; }
        public string Description { get; set; }
        public string Debit { get; set; }
        public string Credit { get; set; }
    }
    public class VoucherHeaderDto
    {
        public string VoucherNumber { get; set; }
        public string Date { get; set; }              // یا DateTime؟ بسته به نیاز
        public string Description { get; set; }
        public string Currency { get; set; }
    }

    public class VoucherDto
    {
        public VoucherHeaderDto Header { get; set; }            // XML بدون خطوط
        public List<VoucherLineDto> Lines { get; set; }  // خطوط به‌شکل آبجکت
    }

}
