using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;

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
            var course = _data.GetFullCourse(courseId).QuestionTasks;
        }
    }
}