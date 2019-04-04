using System;
using System.Collections.Generic;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model
{
    public class Direction: NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
