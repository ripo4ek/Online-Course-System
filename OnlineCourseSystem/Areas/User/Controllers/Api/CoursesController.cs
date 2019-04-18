using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
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
            return Ok(_data.GetCourses().Select(c=>_mapper.Map<Course,CourseDto>(c)));
        }
        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            var course = _data.GetCourse(id);
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
            var courseFromDb = _data.GetCourse(id);
            var courseForSave = _mapper.Map(course, courseFromDb);
            _data.UpdateCourse(id , courseForSave);
            return Ok();

        }
        [HttpGet("/get/{page}")]
        public IActionResult GetCoursesForInfiniteScroll(int page)
        {
            var itemsToSkip = page * _pageSize;
            var courses = _data.GetCourses().OrderBy(t => t.Id).Skip(itemsToSkip).Take(_pageSize);
            return Ok(courses.Select(c => _mapper.Map<Course, CourseDto>(c)));

        }
        [HttpGet("/test/{pageLimit?}/{requestPage?}")]
        public IActionResult GetCoursesForPagination(int? pageLimit, int? requestPage)
        {

            int page = requestPage ?? 0;
            _pageSize = pageLimit ?? 4;


            var container = new ApiContainer();
            var itemsToSkip = page == 0? 0:(page -1) * _pageSize;
            var courses = _data.GetCourses().OrderBy(t => t.Id).Skip(itemsToSkip).Take(_pageSize);
            if (!courses.Any())
                return NotFound();
            container.Data = courses.Select(c => _mapper.Map<Course, CourseDto>(c));
            container.CurrentPage = page;
            container.TotalRecord = _data.GetCourses().Count();
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