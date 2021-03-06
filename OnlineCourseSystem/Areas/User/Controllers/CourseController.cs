﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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

        [AllowAnonymous]
        public IActionResult Index(string category, string inputString)
        {
            //var courses = _courseData.GetFullCourse(new CourseFilter()
            //{
            //    UniversityId = universityId,
            //    DirectionId = directionId
            //});
            var categories = _courseData.GetCategories();
            var model = new CourseViewModel()
            {
                Categories = categories.Select(c=>c.Name),
                CategoryName = category,
                UserInput = inputString,
                
            };
            return View(model);
        }
        [Authorize(Roles = "CourseCreator")]
        public IActionResult Create()
        {
            var categories = _courseData.GetCategories();
            return View(categories);
        }


        [HttpPost]
        [Authorize(Roles = "CourseCreator")]
        public async Task<IActionResult> Create([FromBody] CoursePostViewModel course)
        {

            var courseForSave = _mapper.Map<CoursePostViewModel,Course>(course);


            courseForSave.Author = await _userManager.GetUserAsync(HttpContext.User);
            
            _courseData.AddCourse(courseForSave);

            var courseFromDb = _courseData.GetCourseByName(course.Name);

            var category = _courseData.GetCategories().FirstOrDefault(c=>c.Name.ToLower()==course.Category.ToLower());

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
            return Json(new { result = "Redirect", url = Url.Action("UploadContent", "Course", new { id = courseFromDb.Id }) });
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
                            TopicName = sectionTopic.Name,
                            TaskName = sectionTopicVideoTask.Name,                      
                            VideoTaskId = sectionTopicVideoTask.Id,
                            CourseId = course.Id
                        });
                    }
                }               
            }
            var model = new UploadContentViewModel
            {
                CourseId = course.Id,
                Models =  courseTaskViewModel,
                CourseImage = course.ImageUrl
            };
            return View(model);
        }
        //TODO: Пофиксить 2 вызов
        public async Task<IActionResult> Details(int id)
        {


            var course = _courseData.GetFullCourse(id);
            var currUser = await _userManager.GetUserAsync(User);

            var model = new CourseDetailsViewModel
            {
                Course = course,
                CurrentUser =currUser 
            };
            if (course == null)
            {
                return NotFound();
            }
            
            return View(model);
            
        }
        public async Task<IActionResult> Delete(int id)
        {


            var course = _courseData.GetFullCourse(id);
            _courseData.DeleteCourse(course);

            return RedirectToAction("Index", "Profile");
        }
    }
}