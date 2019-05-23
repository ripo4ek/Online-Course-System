using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace OnlineCourseSystem.Domain.Model
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<CoursesToUsers> Courses { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
