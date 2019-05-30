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
            var tempFileName = _hostingEnv.WebRootPath + "/videos/tem.mp4";
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

            var rezultFileName = _hostingEnv.WebRootPath + $"/videos/{viewModel.TaskId}.mp4";
            if (System.IO.File.Exists(rezultFileName))
            {
                System.IO.File.Delete(rezultFileName);
            }
            System.IO.File.Move(tempFileName, rezultFileName);
            var task = _data.GetVideoTask(viewModel.TaskId);
            task.VideoUrl = rezultFileName;
            _data.UpdateVideoTask(task);
            return Ok();
        }
        [AcceptVerbs("Post")]
        public IActionResult Remove(int videoTaskId)
        {
            var task = _data.GetVideoTask(videoTaskId);
            if (task == null)
                return NotFound();

            if (string.IsNullOrEmpty(task.VideoUrl))
            {
                return NotFound();
            }

            System.IO.File.Delete(task.VideoUrl);
            task.VideoUrl = null;
            return Ok();
        }

    }
}