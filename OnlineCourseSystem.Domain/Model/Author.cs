using System.ComponentModel.DataAnnotations.Schema;
using OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Domain.Model
{
    [Table("Authors")]
    public class Author : NamedEntity, IOrderedEntity
    {
        public string PhotoUrl { get; set; }
        public int Order { get; set; }

        public string Position { get; set; }
        public string Description { get; set; }
    }
}
