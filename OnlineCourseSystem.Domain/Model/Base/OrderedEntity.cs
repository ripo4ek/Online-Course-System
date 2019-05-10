using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseSystem.Domain.Model.Base
{
    public  class OrderedEntity :NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
