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
        public string ImageUrl { get; set; }

        public virtual UniversityDto University { get; set; }

        public  AuthorDto Author { get; set; }

        public string StartTime { get; set; }


        public string Description { get; set; }

        public int Order { get; set; }

        public int? DirectionId { get; set; }

        public  DirectionDto Direction { get; set; }
    }
}
