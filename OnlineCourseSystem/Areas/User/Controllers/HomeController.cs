using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Domain;

namespace OnlineCourseSystem.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ICourseData _courseData;

        public HomeController(ICourseData courseData)
        {
            _courseData = courseData;
        }
        public IActionResult Index()
        {
            var courses = _courseData.GetThreeRandomCourses();
            var users = _courseData.GetThreeRandomUsers();
            var events = _courseData.GetFiveRandomEvents();

            List<HomeCourseViewModel> courseViewModel = new List<HomeCourseViewModel>();
            List<HomeAuthorsViewModel> authorsViewModel = new List<HomeAuthorsViewModel>();
            List<HomeEventViewModel> eventsViewModel = new List<HomeEventViewModel>();
            foreach (var course in courses)
            {
                courseViewModel.Add(new HomeCourseViewModel()
                {
                    CourseName = course.Name,
                    CourseAuthor = course.Author.UserName,
                    CourseDescription = course.Description,
                    CourseImage = course.ImageUrl
                });
            }
            foreach (var user in users)
            {
                authorsViewModel.Add(new HomeAuthorsViewModel()
                {
                    Name = user.Name,
                    UserName = user.UserName,
                    Position = user.Status,
                    Subname = user.Surname,
                    PhotoUrl = user.PhotoUrl
                });
            }
            foreach (var eventModel in events)
            {
                eventsViewModel.Add(new HomeEventViewModel()
                {
                    Name = eventModel.Name,
                    Address= eventModel.Address,
                    SampleText = CutterString(eventModel.Text),
                    Time = eventModel.Time,
                    ImageUrl = eventModel.ImageUrl
                });
            }
            HomeViewModel viewModel = new HomeViewModel
            {
                Courses = courseViewModel,
                Authors = authorsViewModel,
                Events = eventsViewModel,
                Stats = new PlatformStatsViewModel()
                {
                    AuthorsCount = _courseData.GetAuthorsCount(),
                    CourseCount = _courseData.GetCourseCount(),
                    UserCount = _courseData.GetUserCount(),
                },             
            };
            return View(viewModel);
        }


        private string CutterString(string str)
        {
            if (str.Length >= 100)
            {
                return str.Substring(0, 100) + "...";
            }

            return str + "...";
        }
        public IActionResult Locker()
        {
            return View();
        }
    }
}