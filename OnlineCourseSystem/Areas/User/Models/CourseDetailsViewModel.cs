using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Models
{
    public class CourseDetailsViewModel
    {
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseAuthor { get; set; }

        public string CurriculumDesctiption { get; set; }
        public string Target { get; set; }
        public IEnumerable<string> Requirements { get; set; }
        public string CourseAuthorDesripiton { get; set; }
        public int QuestionsTasksCount { get; set; }

        public int LecturesCount { get; set; }
        public string AuthorPosition { get; set; }
        public int DurationInDays { get; set; }
        public IEnumerable<Section> Sections { get; set; }
        public IEnumerable<Topic> Themes { get; set; }
        public int  VideosCount { get; set; }
        public string AuthorImage { get; set; }
        public string CourseImage { get; set; }


    }
}
