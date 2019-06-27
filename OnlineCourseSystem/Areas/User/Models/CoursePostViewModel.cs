using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using OnlineCourseSystem.Domain.Model;
using OnlineCourseSystem.Domain.Model.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class CoursePostViewModel
    {

        public string Name { get; set; }

        public string DurationInHours { get; set; }

        public string CurriculumDescription { get; set; }

        public string Description { get; set; }

        public string TargetAuditory { get; set; }

        public string RequirementKnowledge { get; set; }

        public string Category { get; set; }
        public string RepresentForConstructor { get; set; }
        public List<SectionPostViewModel> Sections { get; set; }
       
    }
}
