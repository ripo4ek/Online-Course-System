using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.DAL.Context;
using OnlineCourseSystem.Domain;
using OnlineCourseSystem.Domain.Model;
using OnlineCourseSystem.Domain.Model.Tasks;
using SQLitePCL;

namespace OnlineCourseSystem.Areas.User.Infrastucture.Implementations.Sql
{
    public class SqlCourseData : ICourseData
    {
        private readonly OnlineCourseSystemContext _context;

        public SqlCourseData(OnlineCourseSystemContext context)
        {
            _context = context;
        }
        public IEnumerable<Section> GetSections()
        {
            return _context.Sections.ToList();
        }

        public IEnumerable<Course> GetFullCourse()
        {
            return _context.Courses.ToList();
        }
        public IEnumerable<Topic> GetTopic()
        {
            return _context.Topics.ToList();
        }
        public IEnumerable<Domain.Model.ApplicationUser> GetUsers()
        {
            return _context.Users;
        }

        public IEnumerable<Course> GetCourses(CourseFilter filter)
        {
            var query = _context.Courses.AsQueryable();
            if (filter.Category != null)
                query = _context.CoursesToCategories
                    .Where(c => c.Category.Name == filter.Category)
                    .Select(c => c.Course);

            if (filter.UserSearchInput != null)
            {
                var t = filter.UserSearchInput.ToLower();
                var test = query.ToList();
                query = query.Where(c => c.Name.ToLower().Contains(t));
                
                var test2 = query.ToList();
            }
                
            return query.ToList();

        } 
        //TODO: Доделать к продакшену
        //public IEnumerable<Task> GetTasksOfCourse()
        //{
        //    return null;
        //}

        public IEnumerable<University> GetUniversities()
        {
            return _context.Universities.ToList();
        }

        public IEnumerable<Direction> GetDirections()
        {
            return _context.Directions.ToList();
        }

        public IEnumerable<Course> GetThreeRandomCourses()
        {
            return _context.Courses.Include(c=>c.Author).Take(3).ToList() ;
        }

        public Course GetFullCourse(int id)
        {

           
            return _context.Courses.
                Include(c => c.Author).
                Include(c => c.Categories).
                ThenInclude(c => c.Category).
                Include(c => c.Sections).
                ThenInclude(t=>t.Topics).ThenInclude(t=>t.QuestionTasks).
                Include(c => c.Sections).
                ThenInclude(t => t.Topics).ThenInclude(t => t.VideoTasks).
                Include(c => c.Sections).
                ThenInclude(t => t.Topics).ThenInclude(t => t.TextTasks).
                Include(c => c.Sections).
                ThenInclude(t => t.Topics).ThenInclude(t => t.QuizTasks).ThenInclude(v=>v.VariantOfAnswers).
                FirstOrDefault(c=>c.Id == id);
        }

        public void AddCourse(Course course)
        {
            _context.Add(course);
            _context.SaveChanges();
        }


        
        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();

        }

        public void DeleteCourse(int id)
        {
            var courseFromDb = _context.Courses.SingleOrDefault(c => c.Id == id);
            _context.Remove(courseFromDb);
            _context.SaveChanges();

        }

        public IEnumerable<Category> GetCategories()
        {
           return _context.Categories;
        }

        public IEnumerable<Topic> GetThemes()
        {
            return _context.Topics;
        }
        public IEnumerable<Task> GetTasksOfCourse(TaskFilter filter)
        {
            var course = GetFullCourse(filter.CourseId);

            List<Task> tasks = new List<Task>();

            foreach (var section in course.Sections)
            {
                foreach (var theme in section.Topics)
                {
                    tasks.AddRange(theme.QuestionTasks.Where(t=>t.TopicId == filter.TopicId));
                    tasks.AddRange(theme.QuizTasks.Where(t => t.TopicId == filter.TopicId));
                    tasks.AddRange(theme.TextTasks.Where(t => t.TopicId == filter.TopicId));
                    tasks.AddRange(theme.VideoTasks.Where(t => t.TopicId == filter.TopicId));
                }
            }
            return tasks;
        }

        public Domain.Model.ApplicationUser GetUser(string id)
        {
            return _context.Users.First(c=>c.Id == "4a88adfb-7e1e-4820-bf97-1e31a6e7f8f9");
        }

        public void DeleteUser(string id)
        {
            var user = _context.Users.First(c => c.Id == id);
            _context.Users.Remove(user);
        }

        public  Domain.Model.ApplicationUser GetUserByRole(string role, string id)
        {
           var users = _context.Users.Include(c => c.Courses)
               .Include(r => r.UserRoles);

           return users.First(u => u.Id == id && u.UserRoles.First(r => r.Role.Name == role)!=null);
        }

        public IEnumerable<Domain.Model.ApplicationUser> GetUsersByRole(string role)
        {
            var roleFromDb = _context.Roles.First(r => r.Name == role);

            return _context.UserRoles.Where(u => u.Role == roleFromDb).Select(u => u.ApplicationUser);
        }

        public Domain.Model.ApplicationUser GetAuthorAsUser(string id)
        {
            var users = _context.Users.Include(c => c.Courses).ThenInclude(c=>c.Course)
                .Include(r => r.UserRoles).ToList();

            return users.First(u => u.Id == "74b60af2-b45f-4323-aab0-8ed9550d01e3");
        }

        public IEnumerable<Course> GetCoursesWithAuthor(CourseFilter filter)
        {
            return _context.Courses.Include(c => c.Author);
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }


        public void AddCategoryToCourse(Category category, Course course)
        {
            _context.CoursesToCategories.Add(new CoursesToCategories()
            {
                Course = course,
                Category = category
            });
        }

        public Course GetCourseByName(string name)
        {
            return _context.Courses.First(n=>n.Name == name);
        }
    }
}
