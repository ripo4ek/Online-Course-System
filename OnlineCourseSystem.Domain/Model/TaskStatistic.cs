using System;
using System.Collections.Generic;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model
{
    public class TaskStatistic: NamedEntity
    {
        public bool IsComplete { get; set; }

        public bool IsCorrect { get; set; }
        public int TaskId { get; set; }
    }
}
