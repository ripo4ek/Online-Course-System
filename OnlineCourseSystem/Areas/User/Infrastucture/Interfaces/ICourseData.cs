using System.Collections.Generic;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Domain;
using OnlineCourseSystem.Domain.Model;
using OnlineCourseSystem.Domain.Model.Tasks;

namespace OnlineCourseSystem.Areas.User.Infrastucture.Interfaces
{
    public interface ICourseData
    {
        IEnumerable<Topic> GetTopic();
        int GetAuthorsCount();

        IEnumerable<Post> GetNews();

        Post AddNews(Post news);

        Post GetBlog(int id);

        IEnumerable<Post> GetNewsWithAuthor();

        void UpdateNews(Post post);

        IEnumerable<Post> GetNewsOfUser(string userId);

        Post GetNews(string userId);

        Post GetNews(int id);
        IEnumerable<Post> GetBlogs();

        Post AddBlog(Post post);

        IEnumerable<Post> GetBlogsOfUser(string userId);

        Post GetBlogByUser(string userId);

        void UpdateBlogs(Post post);

        int GetCourseCount();

        int GetUserCount();
        IEnumerable<Event> GetEvents();
        Event AddEvent(Event eventModel);

        IEnumerable<Event> GetEventsWithOrganizer();
        Event GetEvent(int id);
        void UpdateEvent(Event eventModel);
        ApplicationUser GetUserWithStats(string userId);
        void UpdateUser(ApplicationUser user);
        IEnumerable<Section> GetSections();
        void UpdateVideoTask(VideoTask task);
        VideoTask GetVideoTask(int id);
        IEnumerable<Domain.Model.ApplicationUser> GetUsers();
        Domain.Model.ApplicationUser GetUser(string id);
        IEnumerable<Task> GetTasksOfCourse(TaskFilter filter);

        void DeleteEvent(Event eventModel);

        void DeleteBlog(Post blog);

        void DeleteNews(Post blog);

        IEnumerable<Event> GetFiveRandomEvents();
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

        IEnumerable<ApplicationUser> GetThreeRandomUsers();

        //IEnumerable<Task> GetTasksOfCourse();

        IEnumerable<University> GetUniversities();

        IEnumerable<Direction> GetDirections();

        void DeleteUser(string id);

        void AddCourse(Course course);


        void AddCourseToUser(Course course, ApplicationUser user);

        void UpdateCourse(Course course);

        void DeleteCourse(int id);

        IEnumerable<ApplicationUser> GetUsersByRole(string role);

        ApplicationUser GetAuthorAsUser(string id);

    }
}
