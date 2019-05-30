using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class CourseTaskViewModel
    {
        public string SectionName { get; set; }
        public string TopicName { get; set; }

        public int VideoTaskId{ get; set; }
    }
}
