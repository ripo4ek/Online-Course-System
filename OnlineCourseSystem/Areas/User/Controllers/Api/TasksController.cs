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
    [Route("api/Tasks")]
    public class TasksController : Controller
    {
        private readonly ICourseData _data;
        private readonly IMapper _mapper;
        private int _pageSize = 2;

        public TasksController(ICourseData data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetTasks()
        {
            return BadRequest();
        }
        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            return BadRequest();
        }

        [HttpPost]
        public IActionResult CreateTask(CourseDto courseDto)
        {
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateTask(int id, CourseDto course)
        {
            return BadRequest();
        }
        //[HttpGet("/task/test/")]
        //public IActionResult GetTasksForStudy(int courseId, int topicId)
        //{
        //    if(courseId == 0 || topicId ==0)
        //        return BadRequest();

        //    var tasks = _data.GetTasksOfCourse(new TaskFilter()
        //    {
        //        CourseId = courseId,
        //        TopicId = topicId
        //    });


        //}
        [HttpDelete]
        public IActionResult DeleteCourse(int id)
        {
            _data.DeleteCourse(id);
            return Ok();
        }
    }
}