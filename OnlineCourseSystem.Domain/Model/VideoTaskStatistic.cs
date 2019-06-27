using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCourseSystem.Domain.Model
{
    public class VideoTaskStatistic : TaskStatistic
    {
        public bool InProgress { get; set; }

        public double CurrentTime { get; set; } = 0;
    }
}
