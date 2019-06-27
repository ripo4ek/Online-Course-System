using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class CourseTaskViewModel
    {
        public bool VideoExist { get; set; }
        public string TaskName { get; set; }
        public string TopicName { get; set; }
        public int CourseId { get; set; }
        public int VideoTaskId{ get; set; }
    }
}
