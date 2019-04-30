using System;
using System.Collections.Generic;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;
using OnlineCourseSystem.Domain.Model.Tasks;

namespace OnlineCourseSystem.Domain.Model
{
    public class Theme : NamedEntity
    {

        public string Description { get; set; }
        public int SectionId { get; set; }
    }
}
