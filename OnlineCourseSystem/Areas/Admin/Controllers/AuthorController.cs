using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.DAL.Context;
using OnlineCourseSystem.Domain;

namespace OnlineCourseSystem.Areas.Admin.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ICourseData _courseData;

        var context = services
            .GetRequiredService<OnlineCourseSystemContext>();
        var roleStore = new RoleStore<IdentityRole>(context);
        private RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(roleStore,
            new IRoleValidator<IdentityRole>[] { },
            new UpperInvariantLookupNormalizer(),
            new IdentityErrorDescriber(), null);
        public AuthorController(ICourseData courseData)
        {
            _courseData = courseData;
        }
        public IActionResult Index()
        {




            var courses = _courseData.GetCourses(new CourseFilter());
            return View(courses);
        }
        public IActionResult Details(int id)
        {
            var course = _courseData.GetFullCourse(id);
            return View(course);
        }
        public IActionResult Delete(int id)
        {
            _courseData.DeleteCourse(id); ;
            return RedirectToAction("Index");
        }
    }
}