using System;
using System.Data;
using System.Configuration;
using System.Web;

using System.Globalization;

/// <summary>
/// Summary description for DateConversion
/// </summary>
public class DateConversion
{
    public static string GD2JD(DateTime Gregorian)
    {
        PersianCalendar pc = new PersianCalendar();
        int y, m, d;
        y = pc.GetYear(Gregorian);
        m = pc.GetMonth(Gregorian);
        d = pc.GetDayOfMonth(Gregorian);
        string ans = string.Format("{0}/{1:d2}/{2:d2}", y, m, d);
        return ans;
    }

    public static string GD2JD(DateTime Gregorian,bool H)
    {
        PersianCalendar pc = new PersianCalendar();
        int y, m, d,h,M;
        y = pc.GetYear(Gregorian);
        m = pc.GetMonth(Gregorian);
        d = pc.GetDayOfMonth(Gregorian);
        h = pc.GetHour(Gregorian);

        M = pc.GetMinute(Gregorian);

        string ans = string.Format("{0}/{1:d2}/{2:d2} {3:d2}:{4:d2}", y, m, d,h,M);
        return ans;
    }

    public static DateTime JD2GD(string Jalali)
    {
        try
        {
            int y, m, d;
            y = int.Parse(Jalali.Substring(0, 4));
            m = int.Parse(Jalali.Substring(5, 2));
            d = int.Parse(Jalali.Substring(8, 2));
            PersianCalendar pc = new PersianCalendar();
            DateTime ans = new DateTime(y, m, d, pc);
            return ans;
        }
        catch
        {
            return DateTime.Now.AddYears(-100);
        }

    }
}
