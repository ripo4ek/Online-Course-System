using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models.Dtos
{
    public class ApiContainer
    {
        public IEnumerable<CourseDto> Data = new List<CourseDto>();
        public int CurrentPage { get; set; }
        public  int PageLimit { get; set; }
        public int Fetched { get; set; }
        public int TotalRecord { get; set; }
    }
}
