using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Domain;
using OnlineCourseSystem.Areas.User.Infrastructure.Interfaces;

namespace OnlineCourseSystem.Areas.User.Controllers
{
    public class CoursesController : Controller
    {

        private readonly ICourseData _courseData;
        public CoursesController(ICourseData courseData)
        {
            _courseData = courseData;
        }
        public IActionResult Present(int? universityId, int? directionId)
        {
            var courses = _courseData.GetCourse(new CourseFilter()
            {
                UniversityId = universityId,
                DirectionId = directionId
            });
            List<CourseViewModel> courseViewModel = new List<CourseViewModel>();
            foreach (var course in courses)
            {
                courseViewModel.Add(
                new CourseViewModel()
                {
                    Description = course.Description,
                    Id = course.Id,
                    ImageUrl = course.ImageUrl,
                    Starttime = new DateTime(2018, 12, 12),
                    Name = course.Name
                });
            }            
            return View(courseViewModel);
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}