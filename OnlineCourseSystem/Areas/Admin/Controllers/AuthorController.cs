using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class AuthorController : Controller
    {
        private readonly IUserData _userData;

        public AuthorController(IUserData userData)
        {
            _userData = userData;
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
        public IActionResult Delete(string id)
        {
            _userData.DeleteUser(id); ;
            return RedirectToAction("Index");
        }
    }
}