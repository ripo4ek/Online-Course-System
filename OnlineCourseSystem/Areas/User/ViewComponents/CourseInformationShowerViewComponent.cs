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
        private readonly ITaskData _taskData;

        public CourseInformationShower(ITaskData taskData)
        {
            _taskData = taskData;
        }
        public async   Task<IViewComponentResult> InvokeAsync(int courseId, int topicId)
        {
            var tasks = _taskData.GetTasksOfCourse(new TaskFilter()
            {
                CourseId = courseId,
                TopicId = topicId
            }).OrderBy(t=>t.Order).ToList();
            return View(tasks);
        }
    }
}
