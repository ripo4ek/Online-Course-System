using System;
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

        public virtual ApplicationUser Author { get; set; }

        public string DurationInHours { get; set; }

        public int TextTaskCount => GetCountOfTextTasks();

        public int VideoTaskCount => GetCountOfVideoasks();

        public int QuizTaskCount => GetCountOfQuizTasks();

        public int QuestionTaskCount => GetCountOfQuestionTasks();

        public string Target { get; set; }
        public string CurriculumDesctiption { get; set; }
        /// <summary>
        /// Описание курса
        /// </summary>
        public string Description { get; set; }

        public IEnumerable<CoursesToCategories> Categories { get; set; }

        public IEnumerable<CoursesToUsers> Users { get; set; }
        public  ICollection<Section> Sections { get; set; }

        public IEnumerable<Requierment> Requirements { get; set; }
        public int Order { get; set; }

        public  int? DirectionId { get; set; }

        [ForeignKey("DirectionId")]
        public  Direction Direction { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }


        private int GetCountOfTextTasks()
        {
            int count = 0;
            foreach (var section in Sections)
            {
                foreach (var sectionTopic in section.Topics)
                {
                    count += sectionTopic.TextTasks.Count;
                }
            }

            return count;
        }
        private int GetCountOfQuizTasks()
        {
            int count = 0;
            foreach (var section in Sections)
            {
                foreach (var sectionTopic in section.Topics)
                {
                    count += sectionTopic.QuizTasks.Count;
                }
            }

            return count;
        }
        private int GetCountOfQuestionTasks()
        {
            int count = 0;
            foreach (var section in Sections)
            {
                foreach (var sectionTopic in section.Topics)
                {
                    count += sectionTopic.QuestionTasks.Count;
                }
            }

            return count;
        }
        private int GetCountOfVideoasks()
        {
            int count = 0;
            foreach (var section in Sections)
            {
                foreach (var sectionTopic in section.Topics)
                {
                    count += sectionTopic.VideoTasks.Count;
                }
            }

            return count;
        }
    }
}
