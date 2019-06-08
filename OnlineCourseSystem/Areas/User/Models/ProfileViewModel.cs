using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class ProfileViewModel
    {
        public bool IsCourseCreator { get; set; }
        public bool HaveBlogs { get; set; }
        public bool HaveEvents { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }

        public string AvatarUrl { get; set; }

        public int CoursesInProgress { get; set; }
        public int CoursesComplete { get; set; }
        public int CoursesInTotal { get; set; }

        public IEnumerable<CourseProfileViewModel> Courses { get; set; }

        public IEnumerable<OwnCourseProfileViewModel> MyCourses { get; set; }
        public IEnumerable<PostProfileViewModel> Events { get; set; }
        public IEnumerable<PostProfileViewModel> Blogs { get; set; }
    }
}
