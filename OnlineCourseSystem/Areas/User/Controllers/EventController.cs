using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Data;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Controllers
{
    [Area("User")]
    public class EventController : Controller
    {
        private readonly IEventData _eventData;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;

        public EventController(IEventData eventData, IMapper mapper, IHostingEnvironment env, UserManager<ApplicationUser> userManager)
        {
            _eventData = eventData;
            _mapper = mapper;
            _env = env;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var events = _eventData.GetEventsWithOrganizer();
            var model = new List<EventViewModel>();
            foreach (var e in events)
            {
                model.Add(new EventViewModel
                {
                    Id = e.Id,
                    Author = string.IsNullOrEmpty(e.Organizer.Name)  || string.IsNullOrEmpty(e.Organizer.Surname)?
                            e.Organizer.UserName:$"{e.Organizer.Name} {e.Organizer.Surname}",
                    ImageUrl = e.ImageUrl,
                    ReleaseTime = e.Time,
                    TextPreview = StringFormatter.FormatForPreview(e.Text),
                    Title = e.Name,
                });
            }
            return View(model);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EventPostViewModel eventPostModel)
        {
            if (ModelState.IsValid)
            {
                var eventForSave = _mapper.Map<EventPostViewModel, Event>(eventPostModel);

                var eventFromDb = _eventData.AddEvent(eventForSave);

                var fileExt = eventPostModel.Wallpaper.FileName.Split('.').Last();

                string path = $"{Path.DirectorySeparatorChar}images{Path.DirectorySeparatorChar}" +
                              $"eventWallpapers{Path.DirectorySeparatorChar}" 
                              + eventFromDb.Id+$".{fileExt}";


                using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
                {
                    await eventPostModel.Wallpaper.CopyToAsync(fileStream);
                }

                eventFromDb.ImageUrl = "/images/eventWallpapers/"+ eventFromDb.Id + $".{fileExt}";
                eventFromDb.Organizer = await _userManager.GetUserAsync(User);

                eventFromDb.ImageLocalUrl = _env.WebRootPath + path;
                _eventData.UpdateEvent(eventFromDb);
                return RedirectToAction("Index","Profile");
            }
            return View();
        }
        [Authorize]
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