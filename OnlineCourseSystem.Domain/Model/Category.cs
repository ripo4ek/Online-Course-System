using System;
using System.Collections.Generic;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model
{
    public class Category : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CoursesToCategories> Courses { get; set; }


    }
}
