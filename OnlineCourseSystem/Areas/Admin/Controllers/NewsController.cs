using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.Admin.Models;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {


        private readonly ICourseData _courseData;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;

        public NewsController(ICourseData courseData, IMapper mapper, IHostingEnvironment env, UserManager<ApplicationUser> userManager)
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
        public async Task<IActionResult> Create(NewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newsForSave = _mapper.Map<NewsViewModel, Post>(model);

                var newsFromDb = _courseData.AddNews(newsForSave);

                var fileExt = model.Wallpaper.FileName.Split('.').Last();

                string path = $"{Path.DirectorySeparatorChar}images{Path.DirectorySeparatorChar}" +
                              $"newsWallpapers{Path.DirectorySeparatorChar}"
                              + newsFromDb.Id + $".{fileExt}";


                using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
                {
                    await model.Wallpaper.CopyToAsync(fileStream);
                }

                newsFromDb.ImageUrl = "/images/newsWallpapers/" + newsFromDb.Id + $".{fileExt}";
                newsFromDb.ReleaseTime = DateTime.Now;

                newsFromDb.ImageLocalUrl = _env.WebRootPath + path;

                newsFromDb.Author = await _userManager.GetUserAsync(User);
                _courseData.UpdateNews(newsFromDb);
                return RedirectToAction("Index", "News");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var news = _courseData.GetNews(id);
            _courseData.DeleteNews(news);
            return RedirectToAction("Index", "Event");
        }
        public IActionResult Details(int id)
        {
            var modelEvent = _courseData.GetNews(id);
            return View(modelEvent);
        }
    }
}