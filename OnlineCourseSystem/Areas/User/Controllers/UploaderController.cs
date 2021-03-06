﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using OnlineCourseSystem.Areas.User.Data;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;
using ContentDispositionHeaderValue = System.Net.Http.Headers.ContentDispositionHeaderValue;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace OnlineCourseSystem.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class UploaderController : Controller
    {
        private readonly IHostingEnvironment _hostingEnv;
        private readonly ITaskData _taskData;
        private readonly ICourseData _courseData;

        public UploaderController(IHostingEnvironment env, ITaskData taskData, ICourseData courseData)
        {
            _hostingEnv = env;
            _taskData = taskData;
            _courseData = courseData;
        }

        [HttpPost]
        [DisableFormValueModelBinding]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            FormValueProvider formModel;
            var tempFileName = _hostingEnv.WebRootPath + $"{Path.DirectorySeparatorChar}videos{Path.DirectorySeparatorChar}tem.mp4";
            using (var stream = System.IO.File.Create(tempFileName))
            {
                formModel = await Request.StreamFile(stream);
            }
            var viewModel = new UploaderViewModel();


            var bindingSuccessful = await TryUpdateModelAsync(viewModel, prefix: "",
                valueProvider: formModel);

            if (!bindingSuccessful)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
            }

            var rezultFileName = _hostingEnv.WebRootPath + $"{Path.DirectorySeparatorChar}videos{Path.DirectorySeparatorChar}{viewModel.TaskId}.mp4";
            if (System.IO.File.Exists(rezultFileName))
            {
                System.IO.File.Delete(rezultFileName);
            }
            System.IO.File.Move(tempFileName, rezultFileName);
            var task = _taskData.GetVideoTask(viewModel.TaskId);
            task.LocalVideoUrl = rezultFileName;
            task.VideoUrl = $"/videos/{viewModel.TaskId}.mp4";
            _taskData.UpdateVideoTask(task);
            return Ok();
        }
        public IActionResult Remove(int taskId)
        {
            var task = _taskData.GetVideoTask(taskId);
            if (task == null)
                return NotFound();

            if (string.IsNullOrEmpty(task.VideoUrl))
            {
                return NotFound();
            }
            if (System.IO.File.Exists(task.LocalVideoUrl))
            {
                System.IO.File.Delete(task.LocalVideoUrl);
            }

            task.VideoUrl = null;
            task.LocalVideoUrl = null;
            _taskData.UpdateVideoTask(task);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UploadCourseImage(UploadCourseCover model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var course = _courseData.GetFullCourse(model.CourseId);
            if (course == null)
            {
                return NotFound();
            }

            string path = _hostingEnv.WebRootPath +
                          $"{Path.DirectorySeparatorChar}images{Path.DirectorySeparatorChar}coursesMainImages{Path.DirectorySeparatorChar}" +
                          model.File.FileName;

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await model.File.CopyToAsync(fileStream);
            }


            var urlPath = $"/images/coursesMainImages/{model.File.FileName}";
            course.ImageUrl = urlPath;
            course.LocalImageUrl = path;
            _courseData.UpdateCourse(course);
            return Ok(new { ImageUrl = urlPath });

        }

    }
}