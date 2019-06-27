using Microsoft.AspNetCore.Http;

namespace OnlineCourseSystem.Areas.Admin.Models
{
    public class NewsViewModel
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public IFormFile Wallpaper { get; set; }

    }
}