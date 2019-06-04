using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class HomeViewModel
    {
        public IEnumerable<HomeCourseViewModel> Courses { get; set; }

        public IEnumerable<HomeAuthorsViewModel> Authors { get; set; }

        public IEnumerable<HomeEventViewModel> Events { get; set; }
        public PlatformStatsViewModel Stats { get; set; }

    }
}
