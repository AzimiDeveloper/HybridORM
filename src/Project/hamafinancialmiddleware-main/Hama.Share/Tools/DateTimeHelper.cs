using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hama.Share.Tools
{
    public class DateTimeHelper
    {

        public static DateTime ToMiladi_StartTimeDay(string persianDate)
        {
            try
            {
                string[] formats = { "yyyy/MM/dd", "yyyy/M/d", "yyyy/MM/d", "yyyy/M/dd" };
                DateTime d1 = DateTime.ParseExact(persianDate, formats,
                                                  /*CultureInfo.CurrentCulture*/ new CultureInfo("fa"), DateTimeStyles.None);
                var responseDate = new DateTime(d1.Year, d1.Month, d1.Day, 0, 0, 0);
                return responseDate;
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public static DateTime ToMiladi_EndTimedDay(string persianDate)
        {
            try
            {

                string[] formats = { "yyyy/MM/dd", "yyyy/M/d", "yyyy/MM/d", "yyyy/M/dd" };
                DateTime d1 = DateTime.ParseExact(persianDate, formats, new CultureInfo("fa"), DateTimeStyles.None);
                var responseDate = new DateTime(d1.Year, d1.Month, d1.Day, 23,59, 59);
                return responseDate;
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public static string ToPersianDateTime(DateTime dateTime)
        {
            return dateTime.ToString("g", new CultureInfo("fa"));
        }

        public static string ToPersianDate(DateTime dateTime)
        {
            return PersianDateValidation(dateTime.ToString("d", new CultureInfo("fa")));
        }

        public static string PersianDateValidation(string date)
        {
            var splitDate = date.Split('/');
            if (splitDate.Count() != 3 && date.Length < 8)
                return "";
            try
            {
                int yy = Convert.ToInt32(splitDate[0]);
                int mm = Convert.ToInt32(splitDate[1]);
                int dd = Convert.ToInt32(splitDate[2]);

                PersianCalendar persianCalendar = new PersianCalendar();
                var IsLeapYear = persianCalendar.IsLeapYear(yy);

                string mmm = "";
                string ddd = "";
                string yyy = yy.ToString();

                if (mm > 12)
                {
                    mmm = "12";
                    mm = 12;
                }
                if (mm == 0)
                {
                    mmm = "01";
                    mm = 1;
                }
                if (mm <= 9)
                {
                    mmm = "0" + mm.ToString();
                }
                if (mm >= 10 && mm <= 12)
                {
                    mmm = mm.ToString();
                }

                if (mm >= 1 && mm <= 6 && dd >= 31)
                {
                    ddd = "31";
                    dd = 31;
                }
                if (mm >= 1 && mm <= 6 && dd < 31)
                {
                    ddd = dd.ToString();

                }

                if (mm >= 7 && mm <= 11 && dd >= 30)
                {
                    ddd = "30";
                    dd = 30;
                }

                if (mm >= 7 && mm <= 11 && dd < 30)
                {
                    ddd = dd.ToString();

                }

                if (!IsLeapYear && mm == 12)
                {
                    if (dd > 29)
                    {
                        ddd = "29";
                    }
                    else
                    {
                        ddd = dd.ToString();
                    }
                }
                else if (IsLeapYear && mm == 12)
                {
                    if (dd > 30)
                    {
                        ddd = "30";
                    }
                    else
                    {
                        ddd = dd.ToString();
                    }

                }
                if (dd == 0)
                {
                    ddd = "01";
                    dd = 1;
                }

                if (dd <= 9)
                {
                    ddd = "0" + dd.ToString();
                }


                date = yyy + "/" + mmm + "/" + ddd;
                return date;
            }
            catch
            {
                return "";
            }
        }
    }
}
