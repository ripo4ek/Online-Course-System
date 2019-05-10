using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace OnlineCourseSystem.Domain.Model
{
    public class Role : IdentityRole
    {
        public Role() : base()
        {
        }

        public Role(string roleName) : base(roleName)
        {
        }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
