using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;
using OnlineCourseSystem.Domain.Model.Tasks;

namespace OnlineCourseSystem.Domain.Model
{
    [Table("Courses")]
    public class Course: NamedEntity, IOrderedEntity
    {
        /// <summary>
        /// Ссылка на картинку
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Бренд товара
        /// </summary>
        public int? UniversityId { get; set; }

        [ForeignKey("UniversityId")]
        public virtual University University { get; set; }

        public int? AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }


        /// <summary>
        /// Стартовое время
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// Описание курса
        /// </summary>
        public string Description { get; set; }

        public IEnumerable<CoursesToCategories> Categories { get; set; }

        public  ICollection<Section> Sections { get; set; }

        public int Order { get; set; }

        public  int? DirectionId { get; set; }

        [ForeignKey("DirectionId")]
        public  Direction Direction { get; set; }

    }
}
