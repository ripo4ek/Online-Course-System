using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;

namespace OnlineCourseSystem.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ICourseData _courseData;
        public UserController(ICourseData courseData)
        {
            _courseData = courseData;
        }
        public IActionResult Index()
        {
            var users = _courseData.GetUsers();
            return View(users);
        }
        public IActionResult Details(string id)
        {
            var user = _courseData.GetUser(id);
            return View(user);
        }
        public IActionResult Delete(string id)
        {
            _courseData.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}