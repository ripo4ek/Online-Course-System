using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Data
{
    public static class StringFormatter
    {
        public static string FormatForPreview(string str)
        {
            if (str.Length >= 25)
            {
                return str.Substring(0, 25) + "...";
            }

            return str + "...";
        }
        public static string FormatForBigNews(string str)
        {
            if (str.Length >= 150)
            {
                return str.Substring(0, 150) + "...";
            }

            return str + "...";
        }
    }
}
