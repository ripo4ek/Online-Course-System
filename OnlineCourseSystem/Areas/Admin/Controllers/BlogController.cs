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
    public class BlogController : Controller
    {
        private readonly IBlogData _blogData;

        public BlogController(IBlogData blogData)
        {
            _blogData = blogData;

        }
        public IActionResult Index()
        {
            var blogs = _blogData.GetBlogs();
            return View(blogs);
        }
        public IActionResult Delete(int id)
        {
            var blog = _blogData.GetBlog(id);
            _blogData.DeleteBlog(blog);
            return RedirectToAction("Index", "Blog");
        }
        public IActionResult Details(int id)
        {
            var blog = _blogData.GetBlog(id);
            return View(blog);
        }
    }
}