using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class PlatformStatsViewModel
    {
        public int UserCount { get; set; }
        public int CourseCount { get; set; }
        public int YearsCount { get; set; } = 1;
        public int AuthorsCount { get; set; } 
    }
}
