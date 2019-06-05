using System;
using System.Collections.Generic;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model
{
    public class Event : NamedEntity
    {
        public string Address { get; set; }
        public DateTime Time { get; set; }
        public ApplicationUser Organizer { get; set; }
        public string ImageUrl { get; set; }
        public string ImageLocalUrl { get; set; }
        public string Text { get; set; }
    }
}
