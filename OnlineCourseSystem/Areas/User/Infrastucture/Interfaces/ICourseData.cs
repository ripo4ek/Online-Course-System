using System.Collections.Generic;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Domain;
using OnlineCourseSystem.Domain.Model;
using OnlineCourseSystem.Domain.Model.Tasks;

namespace OnlineCourseSystem.Areas.User.Infrastucture.Interfaces
{
    public interface ICourseData
    {
        IEnumerable<Theme> GetTopic();

        IEnumerable<Section> GetSections();

        IEnumerable<Domain.Model.User> GetUsers();
        Domain.Model.User GetUser(string id);
        IEnumerable<Task> GetTasksOfCourse(TaskFilter filter);
        IEnumerable<Course> GetFullCourse();
        IEnumerable<Category> GetCategories();

        IEnumerable<Course> GetCourses(CourseFilter filter);

        IEnumerable<Theme> GetThemes();

        Course GetFullCourse(int id);

        IEnumerable<Course> GetThreeRandomCourses();

        //IEnumerable<Task> GetTasksOfCourse();

        IEnumerable<University> GetUniversities();

        IEnumerable<Direction> GetDirections();

        void DeleteUser(string id);

        void AddCourse(Course course);

        void UpdateCourse(int id , Course course);

        void DeleteCourse(int id);

    }
}
