using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Infrastucture.Interfaces
{
    public interface ICourseStatisticData
    {
        QuizTaskStatistic GetQuizTaskStatisticByTask(int taskId);
        QuestionTaskStatistic GetQuestionTaskStatisticByTask(int taskId);
        void UpdateVideoTaskStatistic(VideoTaskStatistic id);
        void UpdateTextTaskStatistic(TextTaskStatistics statistics);
        void UpdateQuizTaskStatistic(QuizTaskStatistic id);

        void UpdateQuestionTaskStatistic(QuestionTaskStatistic id);
    }
}
