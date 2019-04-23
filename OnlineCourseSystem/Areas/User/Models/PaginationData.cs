using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class PaginationData
    {
        public int? PageLimit { get; set; }

        public int? RequestPage { get; set; }

        public string Category { get; set; }

        public string UserSearchInput { get; set; }
    }
}
