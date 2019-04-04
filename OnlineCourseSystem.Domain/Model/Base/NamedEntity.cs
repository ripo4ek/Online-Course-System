using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseSystem.Domain.Model.Base
{
    public class NamedEntity : BaseEntity, INamedEntity
    {
        public string Name { get; set; }

    }
}
