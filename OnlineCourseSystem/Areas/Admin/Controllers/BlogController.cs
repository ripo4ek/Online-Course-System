using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;

namespace OnlineCourseSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly ICourseData _courseData;

        public BlogController(ICourseData courseData)
        {
            _courseData = courseData;
        }
        public IActionResult Index()
        {
            var blogs = _courseData.GetBlogs();
            return View(blogs);
        }
        public IActionResult Delete(int id)
        {
            var blog = _courseData.GetBlog(id);
            _courseData.DeleteBlog(blog);
            return RedirectToAction("Index", "Blog");
        }
        public IActionResult Details(int id)
        {
            var blog = _courseData.GetBlog(id);
            return View(blog);
        }
    }
}