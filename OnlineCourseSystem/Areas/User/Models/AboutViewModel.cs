using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class AboutViewModel
    {
        public PlatformStatsViewModel Stats { get; set; }
        public IEnumerable<HomeAuthorsViewModel> Authors { get; set; }
    }
}
