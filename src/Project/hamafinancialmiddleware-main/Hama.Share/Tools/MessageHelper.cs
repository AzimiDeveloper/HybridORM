using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hama.Share.Tools
{
    public  class MessageHelper
    {
        private static List<ErrorHelper> errors = new List<ErrorHelper>() {

              new ErrorHelper(){Code = 000 , Name = "DataBase Not Available"} ,
              new ErrorHelper(){Code = 100 , Name = "دوره مالی تعریف نشده است"} ,
              new ErrorHelper(){Code = 106 , Name = "سند قبلی با موفقیت ثبت شد، مایل به ثبت سند جدید هستید؟"} ,
              new ErrorHelper(){Code = 108 , Name = "مبلغ وارد پولی دوم باید ماهیت  مبلغ واحد پولی اول باشد"} ,
              new ErrorHelper(){Code = 109 , Name = "با نمایش سند، سند فعلی در حال ویرایش از دسترس شما خارج میشود، آیا تمایل به نمایش سند درخواستی دارید؟"} ,
              new ErrorHelper(){Code = 110 , Name = "سندی با اطلاعات درخواستی وجود ندارد"} ,
              new ErrorHelper(){Code = 111 , Name = "یک کمپانی انتخاب کنید"} ,
              new ErrorHelper(){Code = 112 , Name = "تایید درخواست"} ,
              new ErrorHelper(){Code = 113 , Name = "وارد نشده است"} ,
              new ErrorHelper(){Code = 114 , Name = "نام ستون به لاتین الزامی میباشد"} ,
              new ErrorHelper(){Code = 115 , Name = "رشته اتصالی نامعتبر میباشد"} ,
              new ErrorHelper(){Code = 116 , Name = "این بخش پیاده سازی نشده است"} ,
              new ErrorHelper(){Code = 117 , Name = "تاریخ سند وارد نمیتواند کوچکتر از دوره مالی باشد"} ,
              new ErrorHelper(){Code = 118 , Name = "تاریخ سند وارد نمیتواند بزرگتر از دوره مالی باشد"} ,
              new ErrorHelper(){Code = 119 , Name = "تاریخ سند نمیتواند از تاریخ آخرین سند تصویب شده کمتر باشد"} ,
              new ErrorHelper(){Code = 120 , Name = "هیچ سندی وجود ندارد"} ,
              new ErrorHelper(){Code = 121 , Name = "انتخاب سند بالادستی از لیست الزامی میباشد"} ,
              new ErrorHelper(){Code = 122 , Name = "درج تعداد اسناد الزامی میباشد"} ,
              new ErrorHelper(){Code = 123 , Name = "انتخاب روش محاسبه الزامی میباشد"} ,
              new ErrorHelper(){Code = 124 , Name = "سند ارسالی قابلیت تبدیل به سند حسابداری ندارد"} ,
              new ErrorHelper(){Code = 125 , Name = "هیچ الگوی شبیه سازی جهت سند ارسال وجود ندارد"} ,
              new ErrorHelper(){Code = 126 , Name = "برای الگوی انتخابی جزئیاتی ثبت نشده است"} ,
              new ErrorHelper(){Code = 127 , Name = "مقدار انتخابی از لیست، بسته بندی انتخابی ثبت نشده دارد"} ,
              new ErrorHelper(){Code = 128 , Name = "مقدار انتخابی از لیست، روش قیمت گذاری اسناد خروج انتخابی ثبت نشده دارد"} ,
              new ErrorHelper(){Code = 129 , Name = "هیچ نوع سندی تعریف نشده است"} ,
              new ErrorHelper(){Code = 130 , Name = "برای ذخیره سازی لطفا ابتدا سند در حال ویرایش را تعیین تکلیف نمایید"} ,
              new ErrorHelper(){Code = 131 , Name = " برای شبیه سازی لطفا ابتدا سند در حال ویرایش را تعیین تکلیف نمایید"} ,
              new ErrorHelper(){Code = 132 , Name = "برای شبیه سازی لطفا ابتدا سند را ذخیره کنید"} ,
              new ErrorHelper(){Code = 133 , Name = $"اسناد با شماره عطف Value"} ,
              new ErrorHelper(){Code = 134 , Name = $"آیا مایل به حذف بند سند انتخابی میباشید؟"} ,
              new ErrorHelper(){Code = 135 , Name = "کپی"} ,
              new ErrorHelper(){Code = 136 , Name = "اسناد با شماره عطف " } ,
              new ErrorHelper(){Code = 137 , Name = "اطلاعات ثبتی سند جاری کامل وارد نشده است" } ,
              new ErrorHelper(){Code = 138 , Name =  "آیا مایل به لغو ادامه فرآیند تولید سند میباشد؟" } ,
              new ErrorHelper(){Code = 139 , Name =  "کاربرگرامی" } ,
              new ErrorHelper(){Code = 140 , Name = "سند جدید" } ,
              new ErrorHelper(){Code = 141 , Name =  "الزامی میباشد" } ,
              new ErrorHelper(){Code = 142 , Name =  $"برای این سند باید اسناد ضمیمه از نوع name برای هر ردیف سند انتخاب کنید"} ,
              new ErrorHelper(){Code = 143 , Name =  $" - حداقل sumLimited سند باید انتخاب شود "} ,
              new ErrorHelper(){Code = 144 , Name =  "کدامنیتی اشتباه وارد شده است"} ,
              new ErrorHelper(){Code = 145 , Name =  "نام کاربری یا رمز عبور غیر مجاز میابشد"} ,
              new ErrorHelper(){Code = 146 , Name = "احتمالا یک نسخه از ابر سامانه سازمانی ویهان در حال استفاده می باشد ، آیا مایل به اجرای مجدد سامانه می باشید ؟"} ,
              new ErrorHelper(){Code = 147 , Name ="آیا قصد خروج از سامانه را دارید؟"} ,
              new ErrorHelper(){Code = 148 , Name = "نمایه های درخواستی، موفقیت حذف شدند"} ,
              new ErrorHelper(){Code = 149 , Name ="نمایه با موفقیت ذخیره شد"} ,
              new ErrorHelper(){Code = 150 , Name = "دوره مالی در سیستم ثبت نشده است"} ,
              new ErrorHelper(){Code = 151 , Name = "آیا مایل به نمایش فایل ذخیره شده می باشید ؟"} ,
              new ErrorHelper(){Code = 152 , Name = "مسیر ذخیره سازی خروجی را مشخص کنید "} ,
              new ErrorHelper(){Code = 153 , Name = $" سطح مجاز انتخاب از لیست "} ,
              new ErrorHelper(){Code = 154 , Name = "میباشد"} ,
              new ErrorHelper(){Code = 155 , Name = $" سطح مجاز انتخاب از لیست کمتر از "} ,
              new ErrorHelper(){Code = 156 , Name =$"اسناد typeShow برای سند با شماره عطف " } ,
              new ErrorHelper(){Code = 157 , Name ="خطا در دسترسی به سرورلاگ" } ,
              new ErrorHelper(){Code = 158 , Name ="لطفا ابتدا نوع مستند را ذخیره کنید و سپس گزارش تعریف کنید"} ,
              new ErrorHelper(){Code = 159 , Name ="لطفا ابتدا نوع مستند را ذخیره کنید و سپس مسیج ثبت کنید"} ,
             
               new ErrorHelper(){Code = 189 , Name = "نام فیلد نباید کارکتر فاصله داشته باشد"},
               new ErrorHelper(){Code = 190 , Name = "تاریخ شروع نمیتواند بزرگتر از تاریخ پایان باشد"},
               new ErrorHelper(){Code = 191 , Name = "شناسه سرفصل اصلی برای تشخیص حساب خودکار در تنظیمات وارد نشده است"},
               new ErrorHelper(){Code = 192 , Name = "درخواست حذف با خطا مواجه شده است ابتدا کاربران و شرکت را از این دوره مالی حذف کنید"},
               new ErrorHelper(){Code = 193 , Name = "ابتدا باید ستونهای سند تعریف شده باشد"},
               new ErrorHelper(){Code = 194 , Name = "درج نام فیلد ستون الزامی میباشد"},
               new ErrorHelper(){Code = 195 , Name = "درج نام نمایشی ستون الزامی میباشد"},
               new ErrorHelper(){Code = 196 , Name = "درج ترتیب ستون الزامی میباشد"},
               new ErrorHelper(){Code = 197 , Name = "انتخاب نوع ستون الزامی میباشد"},
               new ErrorHelper(){Code = 198 , Name = "ابتدا سند را باید ذخیره کرده و سپس برای آن محتوی تولید کنید"},
               new ErrorHelper(){Code = 199 , Name = "لطفا وضعیت اطلاعات ثبت شده را تکمیل یا کنسل نمایید"},

               new ErrorHelper(){Code = 200 , Name = "نام والد را وارد کنید"},
               new ErrorHelper(){Code = 202 , Name = "فرمت اشتباه وارد شده است"},
               new ErrorHelper(){Code = 203 , Name = "درج مقادیر تکراری مجاز نمی باشد"},
               new ErrorHelper(){Code = 204 , Name = "درج این فیلد الزامی میباشد"},
               new ErrorHelper(){Code = 205 , Name = "امکان حذف وجود ندارد"},
               new ErrorHelper(){Code = 206 , Name = "درخواست حذف با موفقیت انجام شد"},
               new ErrorHelper(){Code = 207 , Name = "  عملیات درخواستی شما با موفقیت انجام شد"},
               new ErrorHelper(){Code = 208 , Name = "  عملیات درخواستی شما با خطا مواجه شده است"},
               new ErrorHelper(){Code = 209 , Name = $"آیا مایل به حذف Value میباشید؟"},
               new ErrorHelper(){Code = 210 , Name = "امکان حذف اطلاعات به علت وابستگی وجود ندارد؟"},
               new ErrorHelper(){Code = 211 , Name = $"آیا مایل به حذف Value میباشید؟"},
               new ErrorHelper(){Code = 212 , Name = "والد نمیتواند زیرمجموعه خودش باشد"},
               new ErrorHelper(){Code = 213 , Name = "والد استفاده شده است و نمیتواند انتخاب شود"},
               new ErrorHelper(){Code = 214 , Name = "این والد است و نمیتواند حذف شود"},
               new ErrorHelper(){Code = 215 , Name = "تعیین لیست تسهیم الزامی میباشد"},
               new ErrorHelper(){Code = 216 , Name = "تعیین لیست جزئیات قرارداد الزامی میباشد"},
               new ErrorHelper(){Code = 217 , Name = $"آیا مایل به تغییر وضعیت Value میباشید؟"},


            new ErrorHelper(){Code = 300 , Name = "!تبریک"},
            new ErrorHelper(){Code = 301 , Name = "!خطا"},
            new ErrorHelper(){Code = 302 , Name = "خطای اعتبارسنجی"},
            new ErrorHelper(){Code = 303 , Name = "!توجه"},
            
            };

        public static string GetMessage(int code)
        {
            var err = errors.FirstOrDefault(a => a.Code == code);
            if (err == null)
                return "";
            else
                return err.Name;
        }

    }

    public class ErrorHelper
    {
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
