using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace OnlineCourseSystem.Areas.User.Controllers
{
    public class UploaderController : Controller
    {
        private readonly IHostingEnvironment _hostingEnv;
        public UploaderController(IHostingEnvironment env)
        {
            this._hostingEnv = env;
        }
        [AcceptVerbs("Post")]
        public IActionResult Save(IList<IFormFile> uploadFiles)
        {
            try
            {
                foreach (var file in uploadFiles)
                {
                    if (file != null)
                    {
                        var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim();
                        filename = (_hostingEnv.WebRootPath + $@"\{filename}");
                        if (!System.IO.File.Exists(filename.ToString()))
                        {
                            using (FileStream fs = System.IO.File.Create(filename.ToString()))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                            }
                        }
                        else
                        {
                            Response.Clear();
                            Response.StatusCode = 204;
                            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File already exists.";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.ContentType = "application/json; charset=utf-8";
                Response.StatusCode = 204;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "No Content";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
            return Content("");
        }
        [AcceptVerbs("Post")]
        public IActionResult Remove(IList<IFormFile> uploadFiles)
        {
            try
            {
                foreach (var file in uploadFiles)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim();
                    var filePath = Path.Combine(_hostingEnv.WebRootPath);
                    var fileSavePath = filePath + "\\" + fileName;
                    if (!System.IO.File.Exists(fileSavePath))
                    {
                        System.IO.File.Delete(fileSavePath);
                    }
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 200;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File removed successfully";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
            return Content("");
        }
    }
}