using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;
using OnlineCourseSystem.Domain.Model.Base;
using OnlineCourseSystem.Domain.Model.Tasks;

namespace OnlineCourseSystem.Domain.Model
{
    [Table("Courses")]
    public class Course: INamedEntity
    {
        /// <summary>
        /// Ссылка на картинку
        /// </summary>
        public string ImageUrl { get; set; } = "/images/coursesMainImages/no-image-icon.svg";

        public string LocalImageUrl { get; set; } = $"{Path.DirectorySeparatorChar}images{Path.DirectorySeparatorChar}coursesMainImages{Path.DirectorySeparatorChar}no-image-icon.svg";

        /// <summary>
        /// Бренд товара
        /// </summary>

        public virtual ApplicationUser Author { get; set; }

        public string DurationInHours { get; set; }

        public int TextTaskCount => GetCountOfTextTasks();

        public int VideoTaskCount => GetCountOfVideoasks();

        public int QuizTaskCount => GetCountOfQuizTasks();

        public int QuestionTaskCount => GetCountOfQuestionTasks();

        public string CurriculumDescription { get; set; }
        /// <summary>
        /// Описание курса
        /// </summary>
        public string Description { get; set; }

        public IEnumerable<CoursesToCategories> Categories { get; set; }

        public IEnumerable<CoursesToUsers> Users { get; set; }
        public ICollection<Section> Sections { get; set; }

        public string Name { get; set; }
        public int Id { get; set; }

        public string TargetAuditory { get; set; }

        public string RequirementKnowledge { get; set; }
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
