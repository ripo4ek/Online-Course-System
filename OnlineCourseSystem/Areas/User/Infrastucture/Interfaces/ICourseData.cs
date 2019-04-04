using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using OnlineCourseSystem.Domain;
using OnlineCourseSystem.Domain.Model;
using OnlineCourseSystem.Domain.Model.Base;
using OnlineCourseSystem.Domain.Model.Tasks;
using Task = OnlineCourseSystem.Domain.Model.Base;

namespace OnlineCourseSystem.Areas.User.Infrastructure.Interfaces
{
    public interface ICourseData
    {
        IEnumerable<Topic> GetTopic();

        IEnumerable<Section> GetSections();

        IEnumerable<Course> GetCourse(CourseFilter filter);

        IEnumerable<Course> GetThreeRandomCoursees();

        //IEnumerable<Task> GetTasks();

        IEnumerable<University> GetUniversities();

        IEnumerable<Direction> GetDirections();

    }
}
