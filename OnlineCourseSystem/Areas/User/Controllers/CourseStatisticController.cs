using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Data;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Controllers
{

    [Area("User")]
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


            quizTaskStatistic.IsComplete = true;
            quizTaskStatistic.UserVariant = answer;
            
            foreach (var taskVariantOfAnswer in task.VariantOfAnswers)
            {
                if (string.Equals(taskVariantOfAnswer.Text, answer, StringComparison.CurrentCultureIgnoreCase))
                {

                    quizTaskStatistic.IsCorrect = true;
                }
            }
            _data.UpdateQuizTaskStatistic(quizTaskStatistic);

            return Ok(new{rezult = quizTaskStatistic.IsComplete});
        }
        public IActionResult Question(string answer, int taskId)
        {
            var user = _data.GetUserWithStats(User.GetUserId());

            QuestionTaskStatistic currentStat = null;

            foreach (var stat in user.CourseStatistics)
            {
                foreach (var statQuestionTaskStatistic in stat.QuestionTaskStatistics)
                {
                    if (statQuestionTaskStatistic.TaskId == taskId)
                    {
                        currentStat = statQuestionTaskStatistic;
                        break;
                    }
                }
            }

            if (currentStat != null)
            {
                currentStat.IsComplete = true;
                currentStat.UserAnswer = answer;
                if (string.Equals(currentStat.UserAnswer, answer, StringComparison.CurrentCultureIgnoreCase))
                {
                    currentStat.IsCorrect = true;
                }
                _data.UpdateQuestionTaskStatistic(currentStat);
                return Ok(new { rezult = currentStat.IsCorrect });
            }

            return NotFound();


        }

    }
}