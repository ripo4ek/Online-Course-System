using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using OnlineCourseSystem.Domain.Model.Tasks;

namespace OnlineCourseSystem.Domain.Model
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<CoursesToUsers> Courses { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }

        public ICollection<CourseStatistic> CourseStatistics { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Status { get; set; }

        public string PhotoUrl { get; set; }
        public string Description { get; set; }
    }
}
