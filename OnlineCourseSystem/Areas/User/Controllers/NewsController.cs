using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.Admin.Models;
using OnlineCourseSystem.Areas.User.Data;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;

namespace OnlineCourseSystem.Areas.User.Controllers
{
    [Area("User")]
    public class NewsController : Controller
    {
        private readonly INewsData _newsData;

        public NewsController(INewsData newsData)
        {
            _newsData = newsData;

        }
        public IActionResult Index()
        {
            var events = _newsData.GetNewsWithAuthor();
            var model = new List<NewsShortViewModel>();
            foreach (var e in events)
            {
                model.Add(new NewsShortViewModel
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
        public IActionResult Details(int id)
        {
            var modelEvent = _newsData.GetNews(id);
            return View(modelEvent);
        }
    }
}