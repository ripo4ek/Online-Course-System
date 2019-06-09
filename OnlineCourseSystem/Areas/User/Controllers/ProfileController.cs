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
        private readonly IUserData _userData;
        private readonly ICourseData _data;

        public ProfileController(UserManager<Domain.Model.ApplicationUser> userManager, ICourseData courseData ,IUserData userData)
        {
            _userManager = userManager;
            _userData = userData;
            _data = courseData;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.GetUserId();

            var user = _userData.GetUserWithStats(userId);

            var coursesAuthor = _data.GetCoursesByAuthor(user);

            var courses = _data.GetCoursesOfUser(user).ToList();

            var coursesForModel = new List<CourseProfileViewModel>();
            var ownCourses = new List<OwnCourseProfileViewModel>();
            var ownEvents = new List<PostProfileViewModel>();
            var blogEvents = new List<PostProfileViewModel>();

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
                    Id = course.Id,
                    Name = course.Name,
                    Author = authorName,
                    AuthorImageUrl = course.Author.PhotoUrl,
                    ImageUrl = course.ImageUrl,
                    DurationInHours = course.DurationInHours,
                });
            }
            foreach (var eventModel in user.Events)
            {
                
                ownEvents.Add(new PostProfileViewModel
                {
                    Id = eventModel.Id,
                    Title = eventModel.Name,
                    UrlImage = eventModel.ImageUrl

                });         
            }
            foreach (var course in coursesAuthor)
            {

                ownCourses.Add(new OwnCourseProfileViewModel
                {
                    Id = course.Id,
                    Name = course.Name,
                    Subscribers = course.Users.Count(),

                });
            }
            foreach (var post in user.Blogs)
            {

                blogEvents.Add(new PostProfileViewModel
                {
                    Id = post.Id,
                    Title = post.Name,
                    UrlImage = post.ImageUrl

                });
            }
            var model = new ProfileViewModel
            {
                Name = user.Name,
                AvatarUrl = user.PhotoUrl,  
                Courses = coursesForModel,
                UserName = user.UserName,
                Surname = user.Surname,
                CoursesComplete = user.CourseStatistics.Count(c => c.TasksCount == c.TasksCompetedCount),
                CoursesInProgress = user.CourseStatistics.Count(c => c.TasksCount != c.TasksCompetedCount),
                CoursesInTotal = user.CourseStatistics.Count,
                HaveBlogs = user.Blogs.Count > 0,
                HaveEvents = user.Events.Count > 0,
                IsCourseCreator = User.IsInRole(Roles.CourseCreator),
                Blogs = blogEvents,
                Events = ownEvents,
                MyCourses = ownCourses,
            };


            return View(model);
        }
        public async Task<IActionResult> AddCourse(int courseId)
        {
            var course = _data.GetFullCourse(courseId);

            var userId = User.GetUserId();

            var user = _userData.GetUserWithStats(userId);


            user.CourseStatistics.Add(CreateStatisticsForCourse(course));

            _userData.UpdateUser(user);

            _userData.AddCourseToUser(course, user);


            return RedirectToAction("Details", "Course",new {id = courseId});
        }
        public async Task<IActionResult> BecomeCourseCreator()
        {
            var user =  await _userManager.GetUserAsync(HttpContext.User);
            await _userManager.AddToRoleAsync(user, Roles.CourseCreator);


            return RedirectToAction("Index", "Profile");
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
                Name = course.Name,
                CourseId = course.Id,
                QuestionTaskStatistics = questionTaskForStatistics,
                TextTaskStatistics = textTaskForStatistics,
                QuizTaskStatistics = quizTaskForStatistics,
                VideoTaskStatistics = videoTaskForStatistics,
            };
        }

    }
}