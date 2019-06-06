using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;

namespace OnlineCourseSystem.Areas.User.ViewComponents
{
    public class LastCoursesViewComponent : ViewComponent
    {
        private readonly ICourseData _courseData;

        public LastCoursesViewComponent(ICourseData courseData)
        {
            _courseData = courseData;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var courses = _courseData.GetThreeRandomCourses();
            var model = new List<LastCoursesViewModel>();

            foreach (var course in courses)
            {
                model.Add(new LastCoursesViewModel
                {
                    Id = course.Id,
                    Title = course.Name,
                    ImageUrl = course.ImageUrl,
                    Description = course.Description
                });
            }
            return View(model);
        }
    }
}
