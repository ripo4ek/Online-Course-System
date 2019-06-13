using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;

namespace OnlineCourseSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class EventController : Controller
    {
        private readonly IEventData _eventData;
        public EventController(IEventData eventData)
        {
            _eventData = eventData;
        }
        public IActionResult Index()
        {
            var events = _eventData.GetEvents();
            return View(events);
        }
        public IActionResult Delete(int id)
        {
            var eventModel = _eventData.GetEvent(id);
            _eventData.DeleteEvent(eventModel);
            return RedirectToAction("Index", "Event");
        }
        public IActionResult Details(int id)
        {
            var eventModel = _eventData.GetEvent(id);
            return View(eventModel);
        }
    }
}