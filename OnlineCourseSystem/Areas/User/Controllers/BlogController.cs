using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Controllers
{
    [Area("User")]
    public class BlogController : Controller
    {

        private readonly ICourseData _courseData;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public BlogController(ICourseData courseData, IMapper mapper, IHostingEnvironment env)
        {
            _courseData = courseData;
            _mapper = mapper;
            _env = env;
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
        public async Task<IActionResult> Create(BlogViewModel blog)
        {
            if (ModelState.IsValid)
            {
                var blogForSave = _mapper.Map<BlogViewModel, Post>(blog);

                var blogFromDb = _courseData.AddBlog(blogForSave);

                var fileExt = blog.Wallpaper.FileName.Split('.').Last();

                string path = $"{Path.DirectorySeparatorChar}images{Path.DirectorySeparatorChar}" +
                              $"eventWallpapers{Path.DirectorySeparatorChar}"
                              + blogFromDb.Id + $".{fileExt}";


                using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
                {
                    await blog.Wallpaper.CopyToAsync(fileStream);
                }

                blogFromDb.ImageUrl = "/images/eventWallpapers/" + blogFromDb.Id + $".{fileExt}";
                blogFromDb.ReleaaseTime = DateTime.Now;
                _courseData.UpdateBlogs(blogFromDb);
                return RedirectToAction("Index", "Blog");
            }
            return View();
        }
        public IActionResult Details(int blogId)
        {
            return View();
        }
    }
}