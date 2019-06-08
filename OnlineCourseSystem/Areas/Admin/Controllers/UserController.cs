using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICourseData _courseData;

        public UserController(ICourseData courseData, UserManager<ApplicationUser> userManager)
        {
            _courseData = courseData;
            _userManager = userManager;
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
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var user = _courseData.GetUser(id);
            await _userManager.DeleteAsync(user);            
            return RedirectToAction("Index");
        }
    }
}