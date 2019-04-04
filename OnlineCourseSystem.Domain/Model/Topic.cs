using System;
using System.Collections.Generic;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;
using OnlineCourseSystem.Domain.Model.Tasks;

namespace OnlineCourseSystem.Domain.Model
{
    public class Topic : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        public virtual ICollection<QuizTask> QuizTasks { get; set; }

        public virtual ICollection<QuestionTask> QuestionTasks { get; set; }

        public virtual ICollection<VideoTask> VideoTasks { get; set; }

        public int SectionId { get; set; }
    }
}
