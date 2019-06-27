using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.DAL.Context;
using OnlineCourseSystem.Domain;
using OnlineCourseSystem.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;

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
                query = query.Where(c => c.Name.ToLower().Contains(t));
            }

            return query.Include(u => u.Users).Include(u => u.Author).ToList();

        }
 
        public IEnumerable<Course> GetThreeRandomCourses()
        {
            return _context.Courses.Include(c => c.Author).Include(u=>u.Users).Take(3).ToList();
        }

        public Course GetFullCourse(int id)
        {


            return _context.Courses.
                Include(c => c.Author).
                Include(c => c.Categories).
                ThenInclude(c => c.Category).
                Include(c => c.Users).ThenInclude(u=>u.ApplicationUser).
                Include(c => c.Sections).
                ThenInclude(t => t.Topics).ThenInclude(t => t.QuestionTasks).
                Include(c => c.Sections).
                ThenInclude(t => t.Topics).ThenInclude(t => t.VideoTasks).
                Include(c => c.Sections).
                ThenInclude(t => t.Topics).ThenInclude(t => t.TextTasks).
                Include(c => c.Sections).
                ThenInclude(t => t.Topics).ThenInclude(t => t.QuizTasks).ThenInclude(v => v.VariantOfAnswers).
                FirstOrDefault(c => c.Id == id);
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

        public void DeleteCourse(Course courseFromDb)
        {
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
            return _context.Courses.First(n => n.Name == name);
        }

  
        public IEnumerable<Course> GetCoursesByAuthor(ApplicationUser author)
        {
            return _context.Courses.Where(c => c.Author == author).Include(u=>u.Users);
        }

        public IEnumerable<Course> GetCoursesOfUser(ApplicationUser user)
        {
           return _context.CoursesToUsers.Where(cu => cu.ApplicationUser == user).Select(c => c.Course).Include(c=>c.Author);
        }

      
        public int GetCourseCount()
        {
            return _context.Courses.Count();
        }

    
        public int GetCoursesCountOfCategory(int categoryId)
        {
            return _context.CoursesToCategories.Count(c => c.CategoryId == categoryId);
        }

        public int GetCategoryCount()
        {
            return _context.Categories.Count();
        }

        public IEnumerable<CoursesToCategories> GetCoursesToCategorieses()
        {
            return _context.CoursesToCategories.Include(c=>c.Course).Include(c=>c.Category);
        }
    }
}
