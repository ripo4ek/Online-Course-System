using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Data;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;

namespace OnlineCourseSystem.Areas.User.Controllers
{
    public class CourseStatisticController : Controller
    {
        private readonly ICourseData _data;

        public CourseStatisticController(ICourseData data)
        {
            _data = data;
        }
        public IActionResult Quiz(string answer, string returnUrl, int taskId, int courseId)
        {
            var user = _data.GetUserWithStats(User.GetUserId());
            var courseStatistic = user.CourseStatistics.First(s => s.CourseId == courseId);
            var quizTaskStatistic = courseStatistic.QuizTaskStatistics.First(qs => qs.TaskId == taskId);
            var task = _data.GetQuizTask(taskId);

            quizTaskStatistic.UserVariant = answer;

            foreach (var taskVariantOfAnswer in task.VariantOfAnswers)
            {
                if (string.Equals(taskVariantOfAnswer.Text, answer, StringComparison.CurrentCultureIgnoreCase))
                {
                    quizTaskStatistic.IsComplete = true;
                    
                }
            }
            _data.UpdateQuizTaskStatistic(quizTaskStatistic);

            return Ok(new{rezult = quizTaskStatistic.IsComplete});
        }
        public IActionResult Question(string answer, int taskId, int courseId)
        {
            var user = _data.GetUserWithStats(User.GetUserId());
            var courseStatistic = user.CourseStatistics.First(s=>s.CourseId == courseId);
            var questionTaskStatistic = courseStatistic.QuestionTaskStatistics.First(qs => qs.TaskId == taskId);
            var task = _data.GetQuestionTask(taskId);
            _data.
            questionTaskStatistic.UserAnswer = answer;
            if (string.Equals(task.CorrectAnswer, answer, StringComparison.CurrentCultureIgnoreCase))
            {
                questionTaskStatistic.IsComplete = true;
            }
            _data.UpdateQuestionTaskStatistic(questionTaskStatistic);

            return Ok(new { rezult = questionTaskStatistic.IsComplete });
        }

    }
}