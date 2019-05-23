using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model.Tasks
{
#warning Удостовериться что модель на стрингах достаточна 

    [Table("QuizTasks")]
    public class QuizTask : Task
    {
        public string Question { get; set; }
        public List<QuizVariant> VariantOfAnswers { get; set; }
        public QuizVariant CorrectAnswer { get; set; }
    }
}
