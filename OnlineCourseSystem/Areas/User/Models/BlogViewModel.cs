using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class BlogViewModel
    {
        public string Name { get; set; }

        public IFormFile Wallpaper { get; set; }

        public string Text { get; set; }
    }
}
