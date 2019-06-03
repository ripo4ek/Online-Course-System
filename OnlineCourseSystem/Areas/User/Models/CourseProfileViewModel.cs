using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class CourseProfileViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string DurationInHours { get; set; }
        public string ImageUrl { get; set; }
    }
}
