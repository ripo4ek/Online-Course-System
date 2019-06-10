using System.Collections.Generic;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Domain;
using OnlineCourseSystem.Domain.Model;
using OnlineCourseSystem.Domain.Model.Tasks;

namespace OnlineCourseSystem.Areas.User.Infrastucture.Interfaces
{
    public interface ICourseData
    {   
        int GetCoursesCountOfCategory(int categoryId);  
        int GetCourseCount();      
        IEnumerable<Section> GetSections();    
        IEnumerable<Course> GetFullCourse();
        IEnumerable<Category> GetCategories();
        Course GetCourseByName(string name);
        IEnumerable<Course> GetCourses(CourseFilter filter);
        IEnumerable<Course> GetCoursesOfUser(ApplicationUser user);
        IEnumerable<Course> GetCoursesByAuthor(ApplicationUser author);
        IEnumerable<Course> GetCoursesWithAuthor(CourseFilter filter);
        IEnumerable<Topic> GetThemes();
        void AddCategory(Category category);
        void AddCategoryToCourse(Category category, Course course);
        Course GetFullCourse(int id);
        IEnumerable<Course> GetThreeRandomCourses();
        void AddCourse(Course course);  
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);
     
    }
}
