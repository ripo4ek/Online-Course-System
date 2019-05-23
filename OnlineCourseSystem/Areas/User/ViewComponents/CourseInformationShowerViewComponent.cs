using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;

namespace OnlineCourseSystem.Areas.User.ViewComponents
{
    public class CourseInformationShower : ViewComponent
    {
        private readonly ICourseData _courseData;

        public CourseInformationShower(ICourseData courseData)
        {
            _courseData = courseData;
        }
        public async Task<IViewComponentResult> InvokeAsync(int courseId, int topicId)
        {
            var tasks = _courseData.GetTasksOfCourse(new TaskFilter()
            {
                CourseId = courseId,
                TopicId = topicId
            }).OrderBy(t=>t.Order).ToList();
            return View(tasks);
        }
    }
}
