using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int UniversityId { get; set; }
        public DateTime Starttime { get; set; }
        public string Description { get; set; }
        public int DirectionId { get; set; }
    }
}
