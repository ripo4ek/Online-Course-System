using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class TopicPostViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<QuizTaskPostViewModel> QuizTasks { get; set; }

        public List<QuestionTaskPostViewModel> QuestionTasks { get; set; }

        public virtual List<TextTaskPostViewModel> TextTasks { get; set; }
        public List<VideoTaskPostViewModel> VideoTasks { get; set; }

    }
}
