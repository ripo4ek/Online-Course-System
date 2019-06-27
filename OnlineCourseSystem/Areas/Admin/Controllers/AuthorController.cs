using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.DAL.Context;
using OnlineCourseSystem.Domain;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class AuthorController : Controller
    {
        private readonly IUserData _userData;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthorController(IUserData userData, UserManager<ApplicationUser> userManager)
        {
            _userData = userData;
            _userManager = userManager;
        }
        public IActionResult Index()
        {

            var authors = _userData.GetUsersByRole(Roles.CourseCreator);
            return View(authors);
        }
        public IActionResult Details(string id)
        {
            var author = _userData.GetAuthorAsUser(id);
            return View(author);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var user = _userData.GetUser(id);
            var rez = await _userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
    }
}