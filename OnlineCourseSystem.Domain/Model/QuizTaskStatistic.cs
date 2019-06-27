using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseSystem.Domain.Model
{
    public class QuizTaskStatistic : TaskStatistic
    {
        public string UserVariant { get; set; }

        public string CorrectAnswer { get; set; }
    }
}
