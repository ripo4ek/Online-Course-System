using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace OnlineCourseSystem.Domain.Model
{
    public class User : IdentityUser
    {
        public IEnumerable<CoursesToUsers> Courses { get; set; }
    }
}
