using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Areas.User.Infrastructure.Interfaces;
using OnlineCourseSystem.DAL.Context;
using OnlineCourseSystem.Domain;
using OnlineCourseSystem.Domain.Model;
using OnlineCourseSystem.Domain.Model.Tasks;

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

        public IEnumerable<Topic> GetTopic()
        {
            return _context.Topics.ToList();
        }

        public IEnumerable<Course> GetCourse(CourseFilter filter)
        {
            var query = _context.Courses.AsQueryable();
            if (filter.DirectionId.HasValue)
                query = query.Where(c => c.DirectionId!=0 &&
                                         c.DirectionId.Equals(filter.DirectionId.Value));
            if (filter.UniversityId.HasValue)
                query = query.Where(c => c.UniversityId.Equals(filter.UniversityId.Value));
            return query.ToList();

        }
        //TODO: Доделать к продакшену
        //public IEnumerable<Task> GetTasks()
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

        public IEnumerable<Course> GetThreeRandomCoursees()
        {
            return _context.Courses.Include(c=>c.Author).Take(3).ToList() ;
        }
    }
}
