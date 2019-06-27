using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class UploadCourseCover
    {
        public IFormFile File { get; set; }
        public int CourseId { get; set; }
    }
}
