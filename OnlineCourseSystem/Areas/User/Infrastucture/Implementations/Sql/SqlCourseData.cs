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
        public IEnumerable<Theme> GetTopic()
        {
            return _context.Topics.ToList();
        }
        public IEnumerable<Domain.Model.User> GetUsers()
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
                Include(c => c.QuestionTasks).
                Include(c => c.QuizTasks).
                Include(c => c.Categories).
                ThenInclude(c => c.Category).
                Include(c => c.Requirements).
                Include(c => c.Sections).
                Include(c => c.TextTasks).
                Include(c => c.Topics).
                Include(c => c.VideoTasks).
                FirstOrDefault(c=>c.Id == id);
        }

        public void AddCourse(Course course)
        {
            _context.Add(course);
            _context.SaveChanges();
        }


        
        public void UpdateCourse(int id , Course course)
        {
            DeleteCourse(id);
            _context.Courses.Add(course);
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

        public IEnumerable<Theme> GetThemes()
        {
            return _context.Topics;
        }
        public IEnumerable<Task> GetTasksOfCourse(TaskFilter filter)
        {
            var course = GetFullCourse(filter.CourseId);

            List<Task> tasks = new List<Task>();
            tasks.AddRange(course.QuestionTasks.Where(t=>t.TopicId == filter.TopicId));
            tasks.AddRange(course.QuizTasks.Where(t => t.TopicId == filter.TopicId));
            tasks.AddRange(course.TextTasks.Where(t => t.TopicId == filter.TopicId));
            tasks.AddRange(course.VideoTasks.Where(t => t.TopicId == filter.TopicId));
            return tasks;
        }

        public Domain.Model.User GetUser(string id)
        {
            return _context.Users.First(c=>c.Id == "4a88adfb-7e1e-4820-bf97-1e31a6e7f8f9");
        }

        public void DeleteUser(string id)
        {
            var user = _context.Users.First(c => c.Id == id);
            _context.Users.Remove(user);
        }

        public  Domain.Model.User GetUserByRole(string role, string id)
        {
           var users = _context.Users.Include(c => c.Courses)
               .Include(r => r.UserRoles);

           return users.First(u => u.Id == id && u.UserRoles.First(r => r.Role.Name == role)!=null);
        }

        public IEnumerable<Domain.Model.User> GetUsersByRole(string role)
        {
            var roleFromDb = _context.Roles.First(r => r.Name == role);

            return _context.UserRoles.Where(u => u.Role == roleFromDb).Select(u => u.User);
        }

        public Domain.Model.User GetAuthorAsUser(string id)
        {
            var users = _context.Users.Include(c => c.Courses).ThenInclude(c=>c.Course)
                .Include(r => r.UserRoles);

            return users.First(u => u.Id == id);
        }

        public IEnumerable<Course> GetCoursesWithAuthor(CourseFilter filter)
        {
            return _context.Courses.Include(c => c.Author);
        }
    }
}
