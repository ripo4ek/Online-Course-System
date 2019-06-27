using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.Admin.Models;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserData _userData;
        private readonly ICourseData _courseData;
        private readonly IEventData _eventData;
        private readonly INewsData _newsData;

        public HomeController(UserManager<ApplicationUser> userManager, IUserData userData, ICourseData courseData, IEventData eventData, INewsData newsData)
        {
            _userManager = userManager;
            _userData = userData;
            _courseData = courseData;
            _eventData = eventData;
            _newsData = newsData;
        }
        public IActionResult Index()
        {
            var model = new AdminHomeViewModel()
            {
                AuthorsCount = _userData.GetAuthorsCount(),
                CategoriesCount = _courseData.GetCategoryCount(),
                CoursesCount = _courseData.GetCourseCount(),
                EventCount = _eventData.EventsCount(),
                NewsCount = _newsData.NewsCount(),
                UserCount = _userData.GetUserCount(),
            };
            return View(model);
        }

    }
}