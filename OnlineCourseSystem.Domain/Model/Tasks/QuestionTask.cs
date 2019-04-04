using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model.Tasks
{
    [Table("QuestionTasks")]
    public class QuestionTask: NamedEntity
    {
        public int TopicId { get; set; }

        public string Question { get; }

        private string _correctAnswer;

        //public QuestionTask(string question, string correctAnswer)
        //{
        //    Question = question;
        //    _correctAnswer = correctAnswer;
        //}

        public bool CheckAnswer(string answer)
        {
            if (answer == _correctAnswer)
            {
                return true;
            }

            return false;
        }


    }
}
