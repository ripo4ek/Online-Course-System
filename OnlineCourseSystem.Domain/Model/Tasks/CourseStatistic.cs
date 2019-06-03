using System;
using System.Collections.Generic;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model.Tasks
{
    public class CourseStatistic: NamedEntity
    {
        public bool IsCompleted { get; set; }
        public int CourseId { get; set; }
        public IEnumerable<QuestionTaskStatistic> QuestionTaskStatistics { get; set; }
        public IEnumerable<QuizTaskStatistic> QuizTaskStatistics { get; set; }
        public IEnumerable<VideoTaskStatistic> VideoTaskStatistics { get; set; }
        public IEnumerable<TextTaskStatistics> TextTaskStatistics { get; set; }

    }
}
