using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class LastCoursesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string ImageUrl { get; set; } 

        public string Description { get; set; }
    }
}
