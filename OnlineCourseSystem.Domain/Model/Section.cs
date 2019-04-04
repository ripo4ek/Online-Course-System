using System;
using System.Collections.Generic;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model
{
    public class Section: NamedEntity, IOrderedEntity
    {
        public int CourseId { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public int Order { get; set; }
    }
}
