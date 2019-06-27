using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class QuizTaskPostViewModel
    {
        public string Question { get; set; }
        public List<QuizVariant> VariantOfAnswers { get; set;}
        public QuizVariant CorrectAnswer { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
    }
}
