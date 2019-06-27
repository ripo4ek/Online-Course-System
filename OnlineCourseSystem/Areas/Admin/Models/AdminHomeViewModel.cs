using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.Admin.Models
{
    public class AdminHomeViewModel
    {
        public int UserCount { get; set; }
        public int CoursesCount { get; set; }

        public int CategoriesCount { get; set; }

        public int AuthorsCount { get; set; }

        public int NewsCount { get; set; }

        public int EventCount { get; set; }
    }
}
