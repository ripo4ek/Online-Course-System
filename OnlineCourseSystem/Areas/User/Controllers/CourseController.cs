using System;
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
            

            var categories = _courseData.GetCategories().Where(c=>c.Name==course.Category);


            var newCourse = new Course()
            {
                Name = course.Name,
                Description = course.Description,
                //CurriculumDesctiption = courseCurriculumDescription,
                //Duration = new DateTime(0,0,0,Convert.ToInt32(course.Duration),0,0), 
            };
            _courseData.AddCourse(newCourse);

            var courseFromDb = _courseData.GetCourseByName(course.Name);


            var sections = new List<Section>();
            var topics = new List<Topic>();
            var quizTasks = new List<QuizTask>();
            var questionTasks = new List<QuestionTask>();
            var textTasks = new List<TextTask>();
            var videoTasks = new List<VideoTask>();

            foreach (var sectionPostViewModel in course.Sections)
            {
                sections.Add(new Section()
                {
                    Name = sectionPostViewModel.Name,
                    CourseId = courseFromDb.Id,
                    Description = sectionPostViewModel.Description
                });

            }
            foreach (var sectionPostViewModel in course.Sections)
            {
                

            }
            courseFromDb.Sections = sections;
           _courseData.UpdateCourse(courseFromDb);







            
            //_addCategoryToCourse(course, newCourse);

            return null;

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

        public IActionResult UploadContent()
        {
            return View();
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