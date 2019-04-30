﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;
using OnlineCourseSystem.Domain.Model.Tasks;

namespace OnlineCourseSystem.Domain.Model
{
    [Table("Courses")]
    public class Course: INamedEntity, IOrderedEntity
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

        public DateTime Duration { get; set; }

        public string Target { get; set; }
        public string CurriculumDesctiption { get; set; }
        /// <summary>
        /// Описание курса
        /// </summary>
        public string Description { get; set; }

        public IEnumerable<CoursesToCategories> Categories { get; set; }

        public  ICollection<Section> Sections { get; set; }

        public  ICollection<Theme> Topics { get; set; }

        public  ICollection<QuizTask> QuizTasks { get; set; }

        public  ICollection<QuestionTask> QuestionTasks { get; set; }

        public virtual ICollection<TextTask> TextTasks { get; set; }
        public ICollection<VideoTask> VideoTasks { get; set; }

        public IEnumerable<Requierment> Requirements { get; set; }
        public int Order { get; set; }

        public  int? DirectionId { get; set; }

        [ForeignKey("DirectionId")]
        public  Direction Direction { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
