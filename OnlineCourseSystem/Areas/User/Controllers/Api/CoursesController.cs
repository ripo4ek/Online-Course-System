using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Areas.User.Models.Dtos;
using OnlineCourseSystem.Domain;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Courses")]

    
    public class CoursesController : Controller
    {
        private readonly ICourseData _data;
        private readonly IMapper _mapper;
        private int _pageSize = 2;

        public CoursesController(ICourseData data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCourses()
        {
            return Ok(_data.GetFullCourse().Select(c=>_mapper.Map<Course,CourseDto>(c)));
        }
        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            var course = _data.GetFullCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Course,CourseDto>(course));
        }

        [HttpPost]
        public IActionResult CreateCourse(CourseDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var course = _mapper.Map<CourseDto, Course>(courseDto);
            _data.AddCourse(course);
            return Created(new Uri(Request.GetDisplayUrl()+"/"+course.Id), courseDto);
        }
        [HttpPut]
        public IActionResult UpdateCourse(int id, CourseDto course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var courseFromDb = _data.GetFullCourse(id);
            var courseForSave = _mapper.Map(course, courseFromDb);
            _data.UpdateCourse(courseForSave);
            return Ok();

        }
        [HttpGet("/get/{page}")]
        public IActionResult GetCoursesForInfiniteScroll(int page)
        {
            var itemsToSkip = page * _pageSize;
            var courses = _data.GetFullCourse().OrderBy(t => t.Id).Skip(itemsToSkip).Take(_pageSize);
            return Ok(courses.Select(c => _mapper.Map<Course, CourseDto>(c)));

        }
        [HttpGet("/test/")]
        public IActionResult GetCoursesForPagination(PaginationData data)
        {
            int page = data.RequestPage ?? 0;
            _pageSize = data.PageLimit ?? 4;
            var itemsToSkip = 
                page == 0 ? 0 : (page - 1) * _pageSize;

            var container = new ApiContainer();


            var filter = new CourseFilter()
            {
                Category = data.Category,
                UserSearchInput = data.UserSearchInput
            };
            var courses = _data.GetCourses(filter).OrderBy(t => t.Id).Skip(itemsToSkip).Take(_pageSize);
            if (!courses.Any())
                return NotFound();

            var dataRez = new List<CourseDto>();
            var model = courses.Select(c => _mapper.Map<Course, CourseDto>(c));
            foreach (var course in courses)
            {
                var dtoModel = _mapper.Map<Course, CourseDto>(course);
                dtoModel.StudentCount = course.Users.Count();
                dtoModel.UserRaiting = 5;
                dtoModel.Author =
                    string.IsNullOrEmpty(course.Author.Name) || string.IsNullOrEmpty(course.Author.Surname)
                        ? course.Author.UserName
                        : $"{course.Author.Name} {course.Author.Surname}";
                dataRez.Add(dtoModel);
            }
            container.Data = dataRez;
            container.CurrentPage = page;
            container.TotalRecord = _data.GetCourses(filter).Count();
            container.PageLimit = _pageSize;
            container.Fetched = courses.Count();
            return Ok(container);

        }
        [HttpDelete]
        public IActionResult DeleteCourse(int id)
        {
            _data.DeleteCourse(id);
            return Ok();
        }
    }
}