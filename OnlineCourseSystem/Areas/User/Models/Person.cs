using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string[] Hobbies { get; set; }
    }
}
