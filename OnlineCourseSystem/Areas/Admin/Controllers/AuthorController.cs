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
        private readonly ICourseData _courseData;

        public AuthorController(ICourseData courseData)
        {
            _courseData = courseData;
        }
        public IActionResult Index()
        {

            var courses = _courseData.GetUsersByRole(Roles.CourseCreator);
            return View(courses);
        }
        public IActionResult Details(string id)
        {
            var author = _courseData.GetAuthorAsUser(id);
            return View(author);
        }
        public IActionResult Delete(string id)
        {
            _courseData.DeleteUser(id); ;
            return RedirectToAction("Index");
        }
    }
}