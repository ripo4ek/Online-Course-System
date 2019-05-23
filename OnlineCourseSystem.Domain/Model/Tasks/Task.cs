using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model.Tasks
{
    public class Task : IOrderedEntity, INamedEntity
    {
        public int TopicId { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
    }
}