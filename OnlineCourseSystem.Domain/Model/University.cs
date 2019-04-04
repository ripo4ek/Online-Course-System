using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model
{
    public class University : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        
    }
}
