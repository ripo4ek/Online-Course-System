using System;

namespace OnlineCourseSystem.Domain
{
    public class CourseFilter
    {
        /// <summary>
        /// Direction к которой принадлежит курс
        /// </summary>
        public int? DirectionId { get; set; }
        /// <summary>
        /// University к которому принадлежит курс
        /// </summary> 
        public int? UniversityId { get; set; }
    }
}
