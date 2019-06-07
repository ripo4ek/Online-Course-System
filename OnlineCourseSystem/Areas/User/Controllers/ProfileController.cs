using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Data;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.DAL.Migrations;
using OnlineCourseSystem.Domain.Model;
using OnlineCourseSystem.Domain.Model.Tasks;

namespace OnlineCourseSystem.Areas.User.Controllers
{
    [Area("User")]
    public class ProfileController : Controller
    {
        private readonly UserManager<Domain.Model.ApplicationUser> _userManager;
        private readonly ICourseData _data;

        public ProfileController(UserManager<Domain.Model.ApplicationUser> userManager, ICourseData data)
        {
            _userManager = userManager;
            _data = data;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.GetUserId();

            var user = _data.GetUserWithStats(userId);

            var courses = _data.GetCoursesOfUser(user).ToList();

            var coursesForModel = new List<CourseProfileViewModel>();
            foreach (var course in courses)
            {
                string authorName = "";
                if (course.Author.Name == null || course.Author.Surname == null)
                {
                    authorName = course.Author.UserName;
                }
                else
                {
                    authorName = course.Author.Name + course.Author.Surname;
                }
                coursesForModel.Add(new CourseProfileViewModel
                {
                    Name = course.Name,
                    Author = authorName,
                    ImageUrl = course.ImageUrl,
                    DurationInHours = course.DurationInHours,
                });
            }

            var model = new ProfileViewModel
            {
                Name = user.Name,
                Courses = coursesForModel,
                UserName = user.UserName,
                Surname = user.Surname,
                CoursesComplete = user.CourseStatistics.Count(c => c.IsCompleted),
                CoursesInProgress = user.CourseStatistics.Count(c => !c.IsCompleted),
                CoursesInTotal = user.CourseStatistics.Count
            };


            return View(model);
        }
        public async Task<IActionResult> AddCourse(int courseId)
        {
            var course = _data.GetFullCourse(courseId);

            var user = await _userManager.GetUserAsync(ClaimsPrincipal.Current);

            user.CourseStatistics.Add(CreateStatisticsForCourse(course));

            _data.UpdateUser(user);

            _data.AddCourseToUser(course, user);


            return RedirectToAction("Details", "Course");
        }

        private CourseStatistic CreateStatisticsForCourse(Course course)
        {
            var textTaskForStatistics = new List<TextTaskStatistics>();
            var videoTaskForStatistics = new List<VideoTaskStatistic>();
            var quizTaskForStatistics = new List<QuizTaskStatistic>();
            var questionTaskForStatistics = new List<QuestionTaskStatistic>();

            foreach (var section in course.Sections)
            {
                foreach (var topic in section.Topics)
                {
                    foreach (var questionTask in topic.QuestionTasks)
                    {
                        questionTaskForStatistics.Add(new QuestionTaskStatistic
                        {
                            Name = questionTask.Name,
                            TaskId = questionTask.Id
                        });
                    }
                    foreach (var quizTask in topic.QuizTasks)
                    {
                        quizTaskForStatistics.Add(new QuizTaskStatistic
                        {
                            Name = quizTask.Name,
                            TaskId = quizTask.Id
                        });
                    }
                    foreach (var videoTask in topic.VideoTasks)
                    {
                        videoTaskForStatistics.Add(new VideoTaskStatistic
                        {
                            Name = videoTask.Name,
                            TaskId = videoTask.Id
                        });
                    }
                    foreach (var textTask in topic.TextTasks)
                    {
                        textTaskForStatistics.Add(new TextTaskStatistics
                        {
                            Name = textTask.Name,
                            TaskId = textTask.Id
                        });
                    }

                }
            }

            return new CourseStatistic()
            {
                CourseId = course.Id,
                QuestionTaskStatistics = questionTaskForStatistics,
                TextTaskStatistics = textTaskForStatistics,
                QuizTaskStatistics = quizTaskForStatistics,
                VideoTaskStatistics = videoTaskForStatistics,
            };
        }

        public async Task<IActionResult> AddCourseToUser(int id)
        {
            return View();
        }
    }
}