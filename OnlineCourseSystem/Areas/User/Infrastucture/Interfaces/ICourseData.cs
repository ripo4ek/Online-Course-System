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
        int GetCoursesCountOfCategory(int categoryId);
        IEnumerable<News> GetNews();
        IEnumerable<Blog> GetBlogsWithAuthor();
        IEnumerable<ApplicationUser> GetThreeRandomAuthors();

        News AddNews(News news);

        Role GetRoleByName(string nameOfRole);

        Blog GetBlog(int id);

        TextTask GetTextTask(int id);

        void UpdateTextTaskStatistic(TextTaskStatistics statistics);
        void UpdateQuizTaskStatistic(QuizTaskStatistic id);

        void UpdateQuestionTaskStatistic(QuestionTaskStatistic id);
        IEnumerable<News> GetNewsWithAuthor();

        void UpdateVideoTaskStatistic(VideoTaskStatistic id);

        void UpdateNews(News news);

        IEnumerable<News> GetNewsOfUser(string userId);

        News GetNews(string userId);

        News GetNews(int id);
        QuizTaskStatistic GetQuizTaskStatisticByTask(int taskId);
        QuestionTaskStatistic GetQuestionTaskStatisticByTask(int taskId);
        IEnumerable<Blog> GetBlogs();

        Blog AddBlog(Blog news);

        IEnumerable<Blog> GetBlogsOfUser(string userId);

        Blog GetBlogByUser(string userId);

        void UpdateBlogs(Blog blog);

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

        QuestionTask GetQuestionTask(int id);

        QuizTask GetQuizTask(int id);

        IEnumerable<Domain.Model.ApplicationUser> GetUsers();
        Domain.Model.ApplicationUser GetUser(string id);
        IEnumerable<Task> GetTasksOfCourse(TaskFilter filter);

        void DeleteEvent(Event eventModel);

        void DeleteBlog(Blog blog);

        void DeleteNews(News blog);

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

        IEnumerable<News> GetFiveRandomNews();

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
