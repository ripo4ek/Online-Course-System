using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Domain;

namespace OnlineCourseSystem.Areas.User.Controllers
{
    public class CoursesController : Controller
    {

        private readonly ICourseData _courseData;
        public CoursesController(ICourseData courseData)
        {
            _courseData = courseData;
        }


        public IActionResult Index(int? universityId, int? directionId)
        {
            //var courses = _courseData.GetCourse(new CourseFilter()
            //{
            //    UniversityId = universityId,
            //    DirectionId = directionId
            //});
                 
            return View();
        }
    }
}