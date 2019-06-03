using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class ProfileViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }

        public int CoursesInProgress { get; set; }
        public int CoursesComplete { get; set; }
        public int CoursesInTotal { get; set; }

        public IEnumerable<CourseProfileViewModel> Courses { get; set; }
    }
}
