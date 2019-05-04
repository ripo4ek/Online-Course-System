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

        public List<string> VariantOfAnswers = new List<string>();
        public string CorrectAnswer;

        //public QuizTask( string question,List<string> variantOfAnswers, string correctAnswer)
        //{
        //    Question = question;
        //    VariantOfAnswers = variantOfAnswers;
        //    CorrectAnswer = correctAnswer;
        //}

        //public QuizTask()
        //{
        //}

        public bool CheckAnswer(string answer)
        {
            if (CorrectAnswer == answer)
            {
                return true;
            }

            return false;
        }
    }
}
