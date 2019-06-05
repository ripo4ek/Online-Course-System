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
            if (str.Length >= 100)
            {
                return str.Substring(0, 100) + "...";
            }

            return str + "...";
        }
    }
}
