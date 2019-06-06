using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;

namespace OnlineCourseSystem.Areas.User.Controllers
{
    public class AboutController : Controller
    {
        private readonly ICourseData _data;

        public AboutController(ICourseData data)
        {
            _data = data;
        }
        public IActionResult Index()
        {
            var authors = _data.GetThreeRandomAuthors();
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
                    AuthorsCount = _data.GetAuthorsCount(),
                    CourseCount = _data.GetCourseCount(),
                    UserCount = _data.GetUserCount(),
                }
            };
            return View(model);
        }
    }
}