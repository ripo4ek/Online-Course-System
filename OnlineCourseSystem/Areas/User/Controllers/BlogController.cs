﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class BlogController : Controller
    {
        private readonly IBlogData _blogData;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;

        public BlogController(IBlogData blogData, IMapper mapper, IHostingEnvironment env, UserManager<ApplicationUser> userManager)
        {
            _blogData = blogData;
            _mapper = mapper;
            _env = env;
            _userManager = userManager;
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
                var blogForSave = _mapper.Map<BlogViewModel, Blog>(blog);

                var blogFromDb = _blogData.AddBlog(blogForSave);

                var fileExt = blog.Wallpaper.FileName.Split('.').Last();

                string path = $"{Path.DirectorySeparatorChar}images{Path.DirectorySeparatorChar}" +
                              $"blogWallpapers{Path.DirectorySeparatorChar}"
                              + blogFromDb.Id + $".{fileExt}";


                using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
                {
                    await blog.Wallpaper.CopyToAsync(fileStream);
                }

                blogFromDb.ImageUrl = "/images/blogWallpapers/" + blogFromDb.Id + $".{fileExt}";
                blogFromDb.ReleaseTime = DateTime.Now;
                blogFromDb.ImageLocalUrl = _env.WebRootPath + path;
                blogFromDb.Author = await _userManager.GetUserAsync(User);
                _blogData.UpdateBlogs(blogFromDb);
                return RedirectToAction("Index", "Profile");
            }
            return View();
        }
        public IActionResult Index()
        {
            var events = _blogData.GetBlogsWithAuthor();
            var model = new List<BlogShortViewModel>();
            foreach (var e in events)
            {
                model.Add(new BlogShortViewModel
                {
                    Id = e.Id,
                    Author = string.IsNullOrEmpty(e.Author.Name) || string.IsNullOrEmpty(e.Author.Surname) ?
                        e.Author.UserName : $"{e.Author.Name} {e.Author.Surname}",
                    ImageUrl = e.ImageUrl,
                    ReleaseTime = e.ReleaseTime,
                    TextPreview = StringFormatter.FormatForPreview(e.Text),
                    Title = e.Name,
                });
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var blog = _blogData.GetBlog(id);
            _blogData.DeleteBlog(blog);
            return RedirectToAction("Index", "Profile");
        }
        public IActionResult Details(int id)
        {
            var blog = _blogData.GetBlog(id);
            return View(blog);
        }
    }
}