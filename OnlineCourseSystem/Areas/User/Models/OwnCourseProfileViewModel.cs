using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class OwnCourseProfileViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Subscribers { get; set; }

        public int Raiting { get; set; } = 5;

    }
}
