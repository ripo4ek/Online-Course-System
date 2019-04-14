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
            List<HomeViewModel> viewModel = new List<HomeViewModel>();

            foreach (var course in courses)
            {
                viewModel.Add(new HomeViewModel()
                {
                    CourseName = course.Name,
                    CourseAuthor = course.Author.Name,
                    CourseDescription = course.Description,
                    CourseImage = course.ImageUrl
                });
            }
            return View(viewModel);
        }



        public IActionResult Locker()
        {
            return View();
        }
    }
}