using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Areas.User.ViewComponents;
using OnlineCourseSystem.Domain.Model;
using OnlineCourseSystem.Domain.Model.Base;
using OnlineCourseSystem.Domain.Model.Tasks;

namespace OnlineCourseSystem.Areas.User.Controllers
{
    public class StudyController : Controller
    {
        private readonly ICourseData _data;

        public StudyController(ICourseData data)
        {
            _data = data;
        }
        public IActionResult Course(int id)
        {
            var course = _data.GetFullCourse(id);
            return View(course);
        }

        public IActionResult Task(int courseId, int topicId)
        {
            return ViewComponent(typeof(CourseInformationShower), new {courseId = courseId, topicId = topicId});
        }

    }
}