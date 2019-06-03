using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
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
    public class UploaderController : Controller
    {
        private IHostingEnvironment _hostingEnv;
        private readonly ICourseData _data;

        public UploaderController(IHostingEnvironment env, ICourseData data)
        {
            _hostingEnv = env;
            _data = data;
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
            var task = _data.GetVideoTask(viewModel.TaskId);
            task.LocalVideoUrl = rezultFileName;
            task.VideoUrl = $"/videos/{viewModel.TaskId}.mp4";
            _data.UpdateVideoTask(task);
            return Ok();
        }
        public IActionResult Remove(int taskId)
        {
            var task = _data.GetVideoTask(taskId);
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
            _data.UpdateVideoTask(task);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UploadCourseImage(UploadCourseCover model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var course = _data.GetFullCourse(model.CourseId);
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
            _data.UpdateCourse(course);
            return Ok(new { ImageUrl = urlPath });

        }

    }
}