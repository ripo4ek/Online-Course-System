using System;
using System.Collections.Generic;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model
{
    public class Post: NamedEntity
    {
        public ApplicationUser Author { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime  ReleaaseTime { get; set; }
    }
}
