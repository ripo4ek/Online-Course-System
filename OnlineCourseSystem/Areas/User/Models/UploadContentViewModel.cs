using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class UploadContentViewModel
    {
        public int CourseId { get; set; }
        public List<CourseTaskViewModel> Models { get; set; }
    }
}
