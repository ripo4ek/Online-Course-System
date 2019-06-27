using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.DAL.Context;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Infrastucture.Implementations.Sql
{
    public class SqlCourseStatisticData : ICourseStatisticData
    {
        private readonly OnlineCourseSystemContext _context;

        public SqlCourseStatisticData(OnlineCourseSystemContext context)
        {
            _context = context;
        }
        public QuestionTaskStatistic GetQuestionTaskStatisticByTask(int taskId)
        {
            return _context.QuestionTaskStatistics.First(st => st.TaskId == taskId);
        }

        public QuizTaskStatistic GetQuizTaskStatisticByTask(int taskId)
        {
            return _context.QuizTaskStatistics.First(st => st.TaskId == taskId);
        }

        public void UpdateQuestionTaskStatistic(QuestionTaskStatistic statistic)
        {
            _context.QuestionTaskStatistics.Update(statistic);
            _context.SaveChanges();
        }

        public void UpdateQuizTaskStatistic(QuizTaskStatistic statistic)
        {
            _context.QuizTaskStatistics.Update(statistic);
            _context.SaveChanges();
        }

        public void UpdateTextTaskStatistic(TextTaskStatistics statistics)
        {
            _context.TextTaskStatistics.Update(statistics);
            _context.SaveChanges();
        }

        public void UpdateVideoTaskStatistic(VideoTaskStatistic model)
        {
            _context.VideoTaskStatistic.Update(model);
            _context.SaveChanges();
        }
    }
}
