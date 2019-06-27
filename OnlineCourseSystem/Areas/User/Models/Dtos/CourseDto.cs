using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Models.Dtos
{
    public class CourseDto
    {

        public int Id { get; set; }
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public  string Author { get; set; }

        public string StartTime { get; set; }

        public int StudentCount { get; set; }

        public int UserRaiting { get; set; }
        public string Description { get; set; }

        public int Order { get; set; }

        public int? DirectionId { get; set; }

    }
}
