using System;
using System.Collections.Generic;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model
{
    public class Requierment : IBaseEntity, INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set ; }

        public string Text { get; set; }

    }
}
