using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model.Tasks
{
    public class CourseStatistic: NamedEntity
    {
        public bool IsCompleted { get; set; } 
        public int CourseId { get; set; }


        public int TasksCount => QuestionTaskCount + QuizTaskCount + VideoTaskTaskCount + TextTaskCount;
        public int TasksCompetedCount => QuestionTaskCompleteCount + QuizTaskCompleteCount + VideoTaskCompleteTaskCount + TextTaskCompleteCount;
        public int QuestionTaskCount => QuestionTaskStatistics.Count();
        public int QuizTaskCount => QuizTaskStatistics.Count();
        public int VideoTaskTaskCount => VideoTaskStatistics.Count();
        public int TextTaskCount => TextTaskStatistics.Count();
        public int QuestionTaskCompleteCount => QuestionTaskStatistics.Count(t => t.IsComplete);
        public int QuizTaskCompleteCount => QuizTaskStatistics.Count(t => t.IsComplete);
        public int VideoTaskCompleteTaskCount => VideoTaskStatistics.Count(t => t.IsComplete);
        public int TextTaskCompleteCount => TextTaskStatistics.Count(t => t.IsComplete);
        public IEnumerable<QuestionTaskStatistic> QuestionTaskStatistics { get; set; }
        public IEnumerable<QuizTaskStatistic> QuizTaskStatistics { get; set; }
        public IEnumerable<VideoTaskStatistic> VideoTaskStatistics { get; set; }
        public IEnumerable<TextTaskStatistics> TextTaskStatistics { get; set; }

    }
}
