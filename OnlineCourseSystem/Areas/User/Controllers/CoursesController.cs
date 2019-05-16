using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Domain;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Controllers
{
    [Area("User")]
    public class CoursesController : Controller
    {

        private readonly ICourseData _courseData;
        public CoursesController(ICourseData courseData)
        {
            _courseData = courseData;
        }


        public IActionResult Index(int? universityId, int? directionId)
        {
            //var courses = _courseData.GetFullCourse(new CourseFilter()
            //{
            //    UniversityId = universityId,
            //    DirectionId = directionId
            //});
            var categories = _courseData.GetCategories();
            var model = new CourseViewModel()
            {
                Categories = categories.Select(c=>c.Name)
            };
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            return null;
        }


        //TODO: Пофиксить 2 вызов
        public IActionResult Details(int id)
        {


            var course = _courseData.GetFullCourse(id);

            if (course == null)
            {
                return NotFound();
            }
            
            return View(course);
            
        }
    }
}