using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Controllers
{
    [Area("User")]
    public class EventController : Controller
    {
        private readonly ICourseData _courseData;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;

        public EventController(ICourseData courseData, IMapper mapper, IHostingEnvironment env, UserManager<ApplicationUser> userManager)
        {
            _courseData = courseData;
            _mapper = mapper;
            _env = env;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EventViewModel eventModel)
        {
            if (ModelState.IsValid)
            {
                var eventForSave = _mapper.Map<EventViewModel, Event>(eventModel);

                var eventFromDb = _courseData.AddEvent(eventForSave);

                var fileExt = eventModel.Wallpaper.FileName.Split('.').Last();

                string path = $"{Path.DirectorySeparatorChar}images{Path.DirectorySeparatorChar}" +
                              $"eventWallpapers{Path.DirectorySeparatorChar}" 
                              + eventFromDb.Id+$".{fileExt}";


                using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
                {
                    await eventModel.Wallpaper.CopyToAsync(fileStream);
                }

                eventFromDb.ImageUrl = "/images/eventWallpapers/"+ eventFromDb.Id + $".{fileExt}";
                eventFromDb.Organizer = await _userManager.GetUserAsync(User);

                eventFromDb.ImageLocalUrl = _env.WebRootPath + path;
                _courseData.UpdateEvent(eventFromDb);
                return RedirectToAction("Index","Event");
            }
            return View();
        }
    }
}