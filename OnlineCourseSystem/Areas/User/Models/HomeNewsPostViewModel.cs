using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class HomeNewsPostViewModel
    {
        public string Title { get; set; }

        public string ShortText { get; set; }

        public string ImageUrl { get; set; }

        public DateTime ReleaaseTime { get; set; }
    }
}
