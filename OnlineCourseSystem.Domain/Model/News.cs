using System;
using System.Collections.Generic;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model
{
    public class News: NamedEntity
    {

        public ApplicationUser Author { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public string ImageLocalUrl { get; set; }

        public DateTime  ReleaseTime { get; set; }
    }
}
