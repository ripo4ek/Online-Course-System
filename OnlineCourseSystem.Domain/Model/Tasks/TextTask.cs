using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model.Tasks
{
    public class TextTask : NamedEntity
    {
        /// <summary>
        /// Ссылка на видео
        /// </summary>
        public string VideoUrl { get; set; }

        public int TopicId { get; set; }
    }
}