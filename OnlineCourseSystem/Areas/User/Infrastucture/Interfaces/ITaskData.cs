using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Domain.Model.Tasks;
using Task = OnlineCourseSystem.Domain.Model.Tasks.Task;

namespace OnlineCourseSystem.Areas.User.Infrastucture.Interfaces
{
    public interface ITaskData
    {
        void UpdateVideoTask(VideoTask task);
        IEnumerable<Task> GetTasksOfCourse(TaskFilter filter);
        VideoTask GetVideoTask(int id);

        QuestionTask GetQuestionTask(int id);

        QuizTask GetQuizTask(int id);
        TextTask GetTextTask(int id);
    }
}
