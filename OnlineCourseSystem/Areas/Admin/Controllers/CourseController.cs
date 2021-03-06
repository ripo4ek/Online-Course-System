﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Domain;

namespace OnlineCourseSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class CourseController : Controller
    {
        private readonly ICourseData _courseData;
        public CourseController(ICourseData courseData)
        {
            _courseData = courseData;
        }
        public IActionResult Index()
        {
            var courses = _courseData.GetCoursesWithAuthor(new CourseFilter());
            return View(courses);
        }
        public IActionResult Details(int id)
        {
            var course = _courseData.GetFullCourse(id);
            return View(course);
        }
        public IActionResult Delete(int id)
        {
            var course = _courseData.GetFullCourse(id);
            _courseData.DeleteCourse(course);
            return RedirectToAction("Index");
        }
    }
}