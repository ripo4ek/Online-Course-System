using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class EventPostViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime Time { get; set; }

        [Required]
        public IFormFile Wallpaper { get; set; }

        [Required]
        public string Text { get; set; }

        public int Id { get; set; }
    }
}
