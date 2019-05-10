using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;

namespace OnlineCourseSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Courses()
        {
            return View();
        }
        public IActionResult Authors()
        {
            return View();
        }
    }
}