using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseSystem.Domain.Model
{
    public class CoursesToUsers
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
