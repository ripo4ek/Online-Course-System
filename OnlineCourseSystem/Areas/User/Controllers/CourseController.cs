using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Domain;
using OnlineCourseSystem.Domain.Model;
using OnlineCourseSystem.Domain.Model.Tasks;

namespace OnlineCourseSystem.Areas.User.Controllers
{
    [Area("User")]
    public class CourseController : Controller
    {

        private readonly ICourseData _courseData;
        private readonly IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;

        public CourseController(ICourseData courseData, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _courseData = courseData;
            _mapper = mapper;
            _userManager = userManager;
        }


        public IActionResult Index(int? universityId, int? directionId)
        {
            //var courses = _courseData.GetFullCourse(new CourseFilter()
            //{
            //    UniversityId = universityId,
            //    DirectionId = directionId
            //});
            var categories = _courseData.GetCategories();
            var model = new CourseViewModel()
            {
                Categories = categories.Select(c=>c.Name)
            };
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CoursePostViewModel course)
        {

            var courseForSave = _mapper.Map<CoursePostViewModel,Course>(course);


            courseForSave.Author = await _userManager.GetUserAsync(User);
            
            _courseData.AddCourse(courseForSave);

            var courseFromDb = _courseData.GetCourseByName(course.Name);

            var category = _courseData.GetCategories().FirstOrDefault(c=>c.Name==course.Category.ToLower());

            if (category == null)
            {
                category =  new Category
                {
                    Name = course.Category
                };
                _courseData.AddCategory(category);
                
            }
            _courseData.AddCategoryToCourse(category, courseFromDb);
            _courseData.UpdateCourse(courseFromDb);

            return RedirectToAction("UploadContent", courseFromDb.Id);
        }

        private void _addCategoryToCourse(CoursePostViewModel coursePostViewModel, Course newCourse)
        {
            var category = _courseData.GetCategories()
                .FirstOrDefault(n => n.Name == coursePostViewModel.Category.ToLower());

            if (category == null)
            {
                _courseData.AddCategory(new Category() {Name = coursePostViewModel.Name});
                category = _courseData.GetCategories()
                    .FirstOrDefault(n => n.Name == coursePostViewModel.Category.ToLower());
            }

            _courseData.AddCategoryToCourse(category, newCourse);
        }

        public IActionResult UploadContent(int id)
        {
            var course = _courseData.GetFullCourse(id);
            var courseTaskViewModel = new List<CourseTaskViewModel>();
            foreach (var section in course.Sections)
            {
                foreach (var sectionTopic in section.Topics)
                {
                    foreach (var sectionTopicVideoTask in sectionTopic.VideoTasks)
                    {
                        courseTaskViewModel.Add(new CourseTaskViewModel
                        {
                            VideoExist = !string.IsNullOrEmpty(sectionTopicVideoTask.VideoUrl),
                            SectionName = section.Name,
                            TopicName = sectionTopic.Name,
                            VideoTaskId = sectionTopicVideoTask.Id
                        });
                    }
                }               
            }
            return View(courseTaskViewModel);
        }
        //TODO: Пофиксить 2 вызов
        public IActionResult Details(int id)
        {


            var course = _courseData.GetFullCourse(id);

            if (course == null)
            {
                return NotFound();
            }
            
            return View(course);
            
        }
    }
}