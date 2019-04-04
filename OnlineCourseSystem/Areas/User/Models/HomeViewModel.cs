using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class HomeViewModel
    {
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseAuthor { get; set; }
        public string CourseImage { get; set; }
    }
}
