using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.DAL.Context;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Infrastucture.Implementations.Sql
{
    public class SqlUserData : IUserData
    {
        private readonly OnlineCourseSystemContext _context;

        public SqlUserData(OnlineCourseSystemContext context)
        {
            _context = context;
        }
        public void AddCourseToUser(Course course, ApplicationUser user)
        {
            _context.CoursesToUsers.Add(new CoursesToUsers()
            {
                ApplicationUser = user,
                Course = course
            });
            _context.SaveChanges();
        }

        public void DeleteUser(string id)
        {
            var user = _context.Users.First(c => c.Id == id);
            _context.Users.Remove(user);
        }

        public Domain.Model.ApplicationUser GetAuthorAsUser(string id)
        {
            var users = _context.Users.Include(c => c.Courses).ThenInclude(c => c.Course)
                .Include(r => r.UserRoles).ToList();

            return users.First(u => u.Id == id);
        }

        public int GetAuthorsCount()
        {

            return _context.UserRoles.Count(ur => ur.Role.Name == Roles.CourseCreator);
        }

        public Role GetRoleByName(string nameOfRole)
        {
            return _context.Roles.First(r => r.Name == nameOfRole);
        }

        public IEnumerable<ApplicationUser> GetThreeRandomUsers()
        {
            return _context.Users.Take(3).ToList();
        }

        public Domain.Model.ApplicationUser GetUser(string id)
        {
            return _context.Users.Include(u=>u.UserRoles).First(c => c.Id == id);
        }

        public IEnumerable<Domain.Model.ApplicationUser> GetUsersByRole(string role)
        {
            var roleFromDb = _context.Roles.First(r => r.Name == role);

            return _context.UserRoles.Where(u => u.Role == roleFromDb).Select(u => u.ApplicationUser);
        }

        public ApplicationUser GetUserWithStats(string userId)
        {
            return _context.Users.
                Include(c => c.CourseStatistics).ThenInclude(q => q.QuestionTaskStatistics).
                Include(c => c.CourseStatistics).ThenInclude(q => q.QuizTaskStatistics).
                Include(c => c.CourseStatistics).ThenInclude(q => q.VideoTaskStatistics).
                Include(c => c.CourseStatistics).ThenInclude(q => q.TextTaskStatistics).
                Include(c => c.Blogs).
                Include(c => c.Events).
                First(u => u.Id == userId);
        }

        public void UpdateUser(ApplicationUser user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public IEnumerable<ApplicationUser> GetThreeRandomAuthors()
        {
            var roleFromDb = _context.Roles.First(r => r.Name == Roles.CourseCreator);

            return _context.UserRoles.Where(u => u.Role == roleFromDb).Select(u => u.ApplicationUser).Take(3);

        }
        public int GetUserCount()
        {
            return _context.Users.Count();
        }
        public IEnumerable<Domain.Model.ApplicationUser> GetUsers()
        {
            return _context.Users;
        }
    }
}
