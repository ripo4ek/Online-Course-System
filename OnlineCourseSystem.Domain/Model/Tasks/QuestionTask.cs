using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model.Tasks
{
    [Table("QuestionTasks")]
    public class QuestionTask: Task
    {

        public string Question { get; set; }

        public string CorrectAnswer { get; set; }

        //public QuestionTask(string question, string correctAnswer)
        //{
        //    Question = question;
        //    _correctAnswer = correctAnswer;
        //}



    }
}
