using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class QuestionTaskPostViewModel
    {

        public string Name { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        public string Question { get; set; }

        public string CorrectAnswer { get; set; }
    }
}
