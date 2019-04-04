using System.ComponentModel.DataAnnotations.Schema;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model
{
    [Table("Authors")]
    public class Author : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        public string Description { get; set; }
    }
}
