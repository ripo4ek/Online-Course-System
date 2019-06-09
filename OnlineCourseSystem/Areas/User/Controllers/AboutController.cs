using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;

namespace OnlineCourseSystem.Areas.User.Controllers
{
    [Area("User")]
    public class AboutController : Controller
    {
        private readonly IUserData _userData;
        private readonly ICourseData _courseData;

        public AboutController(IUserData userData, ICourseData courseData)
        {
            _userData = userData;
            _courseData = courseData;
        }
        public IActionResult Index()
        {
            var authors = _userData.GetThreeRandomAuthors();
            List<HomeAuthorsViewModel> authorsViewModel = new List<HomeAuthorsViewModel>();

            foreach (var author in authors)
            {
                authorsViewModel.Add(new HomeAuthorsViewModel()
                {
                    Name = author.Name,
                    UserName = author.UserName,
                    Position = author.Status,
                    Subname = author.Surname,
                    PhotoUrl = author.PhotoUrl
                });
            }
            var model = new AboutViewModel()
            {
                Authors = authorsViewModel,
                Stats =  new PlatformStatsViewModel
                {
                    AuthorsCount = _userData.GetAuthorsCount(),
                    CourseCount = _courseData.GetCourseCount(),
                    UserCount = _userData.GetUserCount(),
                }
            };
            return View(model);
        }
    }
}