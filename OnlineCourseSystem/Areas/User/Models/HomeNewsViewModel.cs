using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class HomeNewsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Author { get; set; }

        public DateTime ReleaseTime { get; set; }

        public string TextPreview { get; set; }
    }
}
