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
        private readonly ICourseStatisticData _statisticData;
        private readonly IUserData _userData;
        private readonly ITaskData _taskData;


        public CourseStatisticController(ICourseStatisticData statisticData, IUserData userData, ITaskData taskData)
        {
            _statisticData = statisticData;
            _userData = userData;
            _taskData = taskData;
        }
        public IActionResult Quiz(string answer, int taskId)
        {
            var user = _userData.GetUserWithStats(User.GetUserId());     
            var task = _taskData.GetQuizTask(taskId);
            QuizTaskStatistic currentStat = null;
            foreach (var stat in user.CourseStatistics)
            {
                foreach (var statQuestionTaskStatistic in stat.QuizTaskStatistics)
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
                currentStat.CorrectAnswer = task.CorrectAnswer.Text;
                currentStat.UserVariant = answer;
                if (string.Equals(task.CorrectAnswer.Text, answer, StringComparison.CurrentCultureIgnoreCase))
                {
                    currentStat.IsCorrect = true;
                }
                else
                {
                    currentStat.IsCorrect = false;
                }
                _statisticData.UpdateQuizTaskStatistic(currentStat);
                return Ok(new { rezult = currentStat.IsCorrect });
            }

            return NotFound();
        }
        public IActionResult Question(string answer, int taskId)
        {
            var user = _userData.GetUserWithStats(User.GetUserId());

            var task = _taskData.GetQuestionTask(taskId);

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
                currentStat.CorrectAnswer = task.CorrectAnswer;
                if (string.Equals(task.CorrectAnswer, answer, StringComparison.CurrentCultureIgnoreCase))
                {
                    currentStat.IsCorrect = true;
                }
                _statisticData.UpdateQuestionTaskStatistic(currentStat);
                return Ok(new { rezult = currentStat.IsCorrect });
            }

            return NotFound();


        }

        public IActionResult Text(int taskId)
        {
            var user = _userData.GetUserWithStats(User.GetUserId());

            var task = _taskData.GetTextTask(taskId);

            TextTaskStatistics currentStat = null;

            foreach (var stat in user.CourseStatistics)
            {
                foreach (var textTaskStatistic in stat.TextTaskStatistics)
                {
                    if (textTaskStatistic.TaskId == taskId)
                    {
                        currentStat = textTaskStatistic;
                        break;
                    }
                }
            }

            if (currentStat != null)
            {
                currentStat.IsComplete = true;

                _statisticData.UpdateTextTaskStatistic(currentStat);
                return Ok();
            }

            return NotFound();


        }

        public IActionResult Details(int courseId)
        {
            var user = _userData.GetUserWithStats(User.GetUserId());

            var statistic = user.CourseStatistics.First(s=>s.CourseId == courseId);


            return View(statistic);
        }

        public IActionResult SaveCurrentTime(int taskId, double time)
        {
            var user = _userData.GetUserWithStats(User.GetUserId());

            var task = _taskData.GetVideoTask(taskId);

            VideoTaskStatistic currentStat = null;

            foreach (var stat in user.CourseStatistics)
            {
                foreach (var videoTaskStatistic in stat.VideoTaskStatistics)
                {
                    if (videoTaskStatistic.TaskId == taskId)
                    {
                        currentStat = videoTaskStatistic;
                        break;
                    }
                }
            }

            if (currentStat != null)
            {
                currentStat.InProgress = true;
                currentStat.CurrentTime = time;

                _statisticData.UpdateVideoTaskStatistic(currentStat);
                return Ok();
            }

            return NotFound();


        }
        public IActionResult Video(int taskId)
        {
            var user = _userData.GetUserWithStats(User.GetUserId());

            var task = _taskData.GetVideoTask(taskId);

            VideoTaskStatistic currentStat = null;

            foreach (var stat in user.CourseStatistics)
            {
                foreach (var videoTaskStatistic in stat.VideoTaskStatistics)
                {
                    if (videoTaskStatistic.TaskId == taskId)
                    {
                        currentStat = videoTaskStatistic;
                        break;
                    }
                }
            }

            if (currentStat != null)
            {
                currentStat.IsComplete = true;
                _statisticData.UpdateVideoTaskStatistic(currentStat);
                return Ok();
            }

            return NotFound();


        }
        public IActionResult CheckCompleteQuestion(int taskId)
        {
            var user = _userData.GetUserWithStats(User.GetUserId());
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
                return Ok(new { isCompleted = currentStat.IsComplete});
            }

            return NotFound();


        }
        public IActionResult CheckCompleteVideo(int taskId)
        {
            var user = _userData.GetUserWithStats(User.GetUserId());
            VideoTaskStatistic currentStat = null;

            foreach (var stat in user.CourseStatistics)
            {
                foreach (var videoTaskStatistic in stat.VideoTaskStatistics)
                {
                    if (videoTaskStatistic.TaskId == taskId)
                    {
                        currentStat = videoTaskStatistic;
                        break;
                    }
                }
            }

            if (currentStat != null)
            {
                return Ok(new { isCompleted = currentStat.IsComplete, currentTime = currentStat.CurrentTime});
            }

            return NotFound();


        }
        public IActionResult CheckCompleteQuiz(int taskId)
        {
            var user = _userData.GetUserWithStats(User.GetUserId());
            QuizTaskStatistic currentStat = null;

            foreach (var stat in user.CourseStatistics)
            {
                foreach (var quizTaskStatistic in stat.QuizTaskStatistics)
                {
                    if (quizTaskStatistic.TaskId == taskId)
                    {
                        currentStat = quizTaskStatistic;
                        break;
                    }
                }
            }

            if (currentStat != null)
            {
                return Ok(new { isCompleted = currentStat.IsComplete });
            }

            return NotFound();


        }

    }
}