using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class CourseDetailsViewModel
    {
        public bool IsEnrolled => Course.Users.Select(u=>u.ApplicationUser).Contains(CurrentUser);
        public ApplicationUser CurrentUser { get; set; }

        public Course Course { get; set; }

    }
}
