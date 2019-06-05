using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model
{
    public class Event : NamedEntity
    {
        public string Address { get; set; }
        public DateTime Time { get; set; }
        public ApplicationUser Organizer { get; set; }
        public string ImageUrl { get; set; } = "/images/eventWallpapers/no-image-icon.svg";
        public string ImageLocalUrl { get; set; } = $"{Path.DirectorySeparatorChar}images{Path.DirectorySeparatorChar}eventWallpapers{Path.DirectorySeparatorChar}no-image-icon.svg";
        public string Text { get; set; }
    }
}
