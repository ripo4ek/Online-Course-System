using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class CourseViewModel
    {
        public IEnumerable<string> Categories { get; set; }
        public string UserInput { get; set; }

        public string CategoryName { get; set; }
    }
}
