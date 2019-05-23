using System;
using System.Collections.Generic;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;
using OnlineCourseSystem.Domain.Model.Tasks;

namespace OnlineCourseSystem.Domain.Model
{
    public class Topic : NamedEntity
    {
        public ICollection<QuizTask> QuizTasks { get; set; }

        public ICollection<QuestionTask> QuestionTasks { get; set; }

        public virtual ICollection<TextTask> TextTasks { get; set; }
        public ICollection<VideoTask> VideoTasks { get; set; }

        public string Description { get; set; }
        public int SectionId { get; set; }
    }
}
