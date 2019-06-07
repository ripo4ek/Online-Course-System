using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class CategoriesViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
