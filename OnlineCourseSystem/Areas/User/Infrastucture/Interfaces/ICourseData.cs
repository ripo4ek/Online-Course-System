using System.Collections.Generic;
using OnlineCourseSystem.Domain;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Infrastucture.Interfaces
{
    public interface ICourseData
    {
        IEnumerable<Topic> GetTopic();

        IEnumerable<Section> GetSections();

        IEnumerable<Course> GetCourses();

        IEnumerable<Course> GetCourse(CourseFilter filter);

        Course GetCourse(int id);

        IEnumerable<Course> GetThreeRandomCourses();

        //IEnumerable<Task> GetTasks();

        IEnumerable<University> GetUniversities();

        IEnumerable<Direction> GetDirections();

        void AddCourse(Course course);

        void UpdateCourse(int id , Course course);

        void DeleteCourse(int id);

    }
}
