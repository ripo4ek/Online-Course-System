using System;
using System.Collections.Generic;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model
{
    public class Section: NamedEntity
    {
        public int CourseId { get; set; }

        public string Description { get; set; }
 
        public IEnumerable<Topic> Topics { get; set; }
    }
}
