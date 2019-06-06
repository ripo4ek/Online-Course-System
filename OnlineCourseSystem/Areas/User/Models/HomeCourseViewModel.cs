using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class HomeCourseViewModel
    {
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseAuthor { get; set; }
        public string CourseImage { get; set; }
        public int UsersScore { get; set; } = 5;
        public int UsersCount { get; set; }
    }
}
