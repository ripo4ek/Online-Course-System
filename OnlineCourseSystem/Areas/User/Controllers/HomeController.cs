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
        private readonly IUserData _userData;
        private readonly IEventData _eventData;
        private readonly INewsData _newsData;

        public HomeController(ICourseData courseData, IUserData userData, IEventData eventData, INewsData newsData)
        {
            _courseData = courseData;
            _userData = userData;
            _eventData = eventData;
            _newsData = newsData;
        }
        public IActionResult Index()
        {
            var courses = _courseData.GetThreeRandomCourses();
            var authors = _userData.GetThreeRandomAuthors();
            var events = _eventData.GetFiveRandomEvents();
            var news = _newsData.GetFiveRandomNews();
            var categories = _courseData.GetCategories();

            List<HomeCourseViewModel> courseViewModel = new List<HomeCourseViewModel>();
            List<HomeAuthorsViewModel> authorsViewModel = new List<HomeAuthorsViewModel>();
            List<HomeEventViewModel> eventsViewModel = new List<HomeEventViewModel>();
            List<HomeNewsViewModel> newsViewModel = new List<HomeNewsViewModel>();
            List<string> categoriesNames = new List<string>();
            foreach (var course in courses)
            {
                courseViewModel.Add(new HomeCourseViewModel()
                {
                    Id = course.Id,
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
                    Id = eventModel.Id,
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
                    Id = newsModel.Id,
                    Author = string.IsNullOrEmpty(newsModel.Author.Name) || string.IsNullOrEmpty(newsModel.Author.Surname) ?
                        newsModel.Author.UserName : $"{newsModel.Author.Name} {newsModel.Author.Surname}",
                    ImageUrl = newsModel.ImageUrl,
                    ReleaseTime= newsModel.ReleaseTime,
                    TextPreview = StringFormatter.FormatForPreview(newsModel.Text),
                    Title = newsModel.Name,
                });
            }
            foreach (var category in categories)
            {
                categoriesNames.Add(category.Name);
            }
            HomeNewsViewModel bigNewsModel = null;
            if (news.Any())
            {
                var firstElement = news.First();
                bigNewsModel = new HomeNewsViewModel()
                {
                    Id = firstElement.Id,
                    Author = string.IsNullOrEmpty(firstElement.Author.Name) || string.IsNullOrEmpty(firstElement.Author.Surname) ?
                        firstElement.Author.UserName : $"{firstElement.Author.Name} {firstElement.Author.Surname}",
                    ImageUrl = firstElement.ImageUrl,
                    ReleaseTime = firstElement.ReleaseTime,
                    TextPreview = StringFormatter.FormatForBigNews(firstElement.Text),
                    Title = firstElement.Name,
                };
            }

            HomeViewModel viewModel = new HomeViewModel
            {
                Courses = courseViewModel,
                Authors = authorsViewModel,
                Events = eventsViewModel,
                News = newsViewModel,
                BigNews = bigNewsModel,
                CategoriesNames = categoriesNames,
                Stats = new PlatformStatsViewModel()
                {
                    AuthorsCount = _userData.GetAuthorsCount(),
                    CourseCount = _courseData.GetCourseCount(),
                    UserCount = _userData.GetUserCount(),           
                },             
            };
            return View(viewModel);
        }

        public IActionResult Searcher(string selectedCategory, string userInput)
        {
            return RedirectToAction("Index", "Course", new{category = selectedCategory, inputString = userInput });
        }

        public IActionResult Locker()
        {
            return View();
        }
    }
}