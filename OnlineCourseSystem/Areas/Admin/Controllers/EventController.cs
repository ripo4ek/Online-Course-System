using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;

namespace OnlineCourseSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {
        private readonly ICourseData _courseData;
        public EventController(ICourseData courseData)
        {
            _courseData = courseData;
        }
        public IActionResult Index()
        {
            var events = _courseData.GetEvents();
            return View(events);
        }
        public IActionResult Delete(int id)
        {
            var eventModel = _courseData.GetEvent(id);
            _courseData.DeleteEvent(eventModel);
            return RedirectToAction("Index", "Event");
        }
        public IActionResult Details(int id)
        {
            var eventModel = _courseData.GetEvent(id);
            return View(eventModel);
        }
    }
}