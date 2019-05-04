using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model.Tasks
{
    public class TextTask : Task
    {
        /// <summary>
        /// Ссылка на видео
        /// </summary>
        public string Data { get; set; }

    }
}