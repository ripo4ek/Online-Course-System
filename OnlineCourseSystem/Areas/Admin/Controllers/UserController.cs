using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class UserController : Controller
    {
        private readonly IUserData _userData;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IUserData userData, UserManager<ApplicationUser> userManager)
        {
            _userData = userData;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var users = _userData.GetUsers();
            return View(users);
        }
        public IActionResult Details(string id)
        {
            var user = _userData.GetUser(id);
            return View(user);
        }
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var user = _userData.GetUser(id);
            await _userManager.DeleteAsync(user);            
            return RedirectToAction("Index");
        }
    }
}