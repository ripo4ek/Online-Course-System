using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.DAL.Context;
using OnlineCourseSystem.Domain.Model.Tasks;
using Task = OnlineCourseSystem.Domain.Model.Tasks.Task;

namespace OnlineCourseSystem.Areas.User.Infrastucture.Implementations.Sql
{
    public class SqlTaskData : ITaskData
    {
        private readonly OnlineCourseSystemContext _context;

        public SqlTaskData(OnlineCourseSystemContext context)
        {
            _context = context;
        }
        public QuestionTask GetQuestionTask(int id)
        {
            return _context.QuestionTasks.First(q => q.Id == id);
        }

        public QuizTask GetQuizTask(int id)
        {
            return _context.QuizTasks.Include(qt => qt.VariantOfAnswers).Include(qt => qt.CorrectAnswer).First(q => q.Id == id);
        }

        public IEnumerable<Task> GetTasksOfCourse(TaskFilter filter)
        {
            var course = _context.Courses.
                Include(c => c.Sections).
                ThenInclude(t => t.Topics).ThenInclude(t => t.QuestionTasks).
                Include(c => c.Sections).
                ThenInclude(t => t.Topics).ThenInclude(t => t.VideoTasks).
                Include(c => c.Sections).
                ThenInclude(t => t.Topics).ThenInclude(t => t.TextTasks).
                Include(c => c.Sections).
                ThenInclude(t => t.Topics).ThenInclude(t => t.QuizTasks).ThenInclude(v => v.VariantOfAnswers).
                FirstOrDefault(c => c.Id == filter.CourseId);


            List<Task> tasks = new List<Task>();

            foreach (var section in course.Sections)
            {
                foreach (var theme in section.Topics)
                {
                    tasks.AddRange(theme.QuestionTasks.Where(t => t.TopicId == filter.TopicId));
                    tasks.AddRange(theme.QuizTasks.Where(t => t.TopicId == filter.TopicId));
                    tasks.AddRange(theme.TextTasks.Where(t => t.TopicId == filter.TopicId));
                    tasks.AddRange(theme.VideoTasks.Where(t => t.TopicId == filter.TopicId));
                }
            }
            return tasks;
        }

        public VideoTask GetVideoTask(int id)
        {
            return _context.VideoTasks.First(t => t.Id == id);
        }

        public void UpdateVideoTask(VideoTask task)
        {
            _context.VideoTasks.Update(task);
            _context.SaveChanges();
        }
        public TextTask GetTextTask(int id)
        {
            return _context.TextTasks.First(tt => tt.Id == id);
        }
    }
}
