using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class HomeEventViewModel
    {

        public string Name { get; set; }
        public string Address { get; set; }

        public DateTime Time { get; set; }

        public string ImageUrl { get; set; }
        public string SampleText { get; set; }
    }
}
