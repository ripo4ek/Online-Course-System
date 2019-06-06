using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Data;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Domain;

namespace OnlineCourseSystem.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ICourseData _courseData;

        public HomeController(ICourseData courseData)
        {
            _courseData = courseData;
        }
        public IActionResult Index()
        {
            var courses = _courseData.GetThreeRandomCourses();
            var authors = _courseData.GetThreeRandomAuthors();
            var events = _courseData.GetFiveRandomEvents();
            var news = _courseData.GetFiveRandomNews();

            List<HomeCourseViewModel> courseViewModel = new List<HomeCourseViewModel>();
            List<HomeAuthorsViewModel> authorsViewModel = new List<HomeAuthorsViewModel>();
            List<HomeEventViewModel> eventsViewModel = new List<HomeEventViewModel>();
            List<HomeNewsViewModel> newsViewModel = new List<HomeNewsViewModel>();
            foreach (var course in courses)
            {
                courseViewModel.Add(new HomeCourseViewModel()
                {
                    CourseName = course.Name,
                    CourseAuthor = course.Author.UserName,
                    CourseDescription = course.Description,
                    CourseImage = course.ImageUrl,
                    UsersCount = course.Users.Count(), 
                });
            }
            foreach (var author in authors)
            {
                authorsViewModel.Add(new HomeAuthorsViewModel()
                {
                    Name = author.Name,
                    UserName = author.UserName,
                    Position = author.Status,
                    Subname = author.Surname,
                    PhotoUrl = author.PhotoUrl
                });
            }
            foreach (var eventModel in events)
            {
                eventsViewModel.Add(new HomeEventViewModel()
                {
                    Name = eventModel.Name,
                    Address= eventModel.Address,
                    SampleText = StringFormatter.FormatForPreview(eventModel.Text),
                    Time = eventModel.Time,
                    ImageUrl = eventModel.ImageUrl
                });
            }
            foreach (var newsModel in news.Skip(1))
            {
                newsViewModel.Add(new HomeNewsViewModel()
                {
                    Author = string.IsNullOrEmpty(newsModel.Author.Name) || string.IsNullOrEmpty(newsModel.Author.Surname) ?
                        newsModel.Author.UserName : $"{newsModel.Author.Name} {newsModel.Author.Surname}",
                    ImageUrl = newsModel.ImageUrl,
                    ReleaseTime= newsModel.ReleaseTime,
                    TextPreview = StringFormatter.FormatForPreview(newsModel.Text),
                    Title = newsModel.Title,
                });
            }

            HomeNewsViewModel bigNewsModel = null;
            if (news.Any())
            {
                var firstElement = news.First();
                bigNewsModel = new HomeNewsViewModel()
                {
                    Author = string.IsNullOrEmpty(firstElement.Author.Name) || string.IsNullOrEmpty(firstElement.Author.Surname) ?
                        firstElement.Author.UserName : $"{firstElement.Author.Name} {firstElement.Author.Surname}",
                    ImageUrl = firstElement.ImageUrl,
                    ReleaseTime = firstElement.ReleaseTime,
                    TextPreview = StringFormatter.FormatForPreview(firstElement.Text),
                    Title = firstElement.Title,
                };
            }

            HomeViewModel viewModel = new HomeViewModel
            {
                Courses = courseViewModel,
                Authors = authorsViewModel,
                Events = eventsViewModel,
                News = newsViewModel,
                BigNews = bigNewsModel,
                Stats = new PlatformStatsViewModel()
                {
                    AuthorsCount = _courseData.GetAuthorsCount(),
                    CourseCount = _courseData.GetCourseCount(),
                    UserCount = _courseData.GetUserCount(),           
                },             
            };
            return View(viewModel);
        }



        public IActionResult Locker()
        {
            return View();
        }
    }
}