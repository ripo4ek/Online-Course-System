using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.DAL.Context;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Infrastucture.Implementations.Sql
{
    public class SqlBlogData : IBlogData
    {
        private readonly OnlineCourseSystemContext _context;

        public SqlBlogData(OnlineCourseSystemContext context)
        {
            _context = context;
        }
        public Blog AddBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
            return blog;
        }

        public void DeleteBlog(Blog blog)
        {
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
        }

        public Blog GetBlog(int id)
        {
            return _context.Blogs.Include(b => b.Author).First(b => b.Id == id);
        }

        public Blog GetBlogByUser(string userId)
        {
            return _context.Blogs.Include(n => n.Author).First(n => n.Author.Id == userId);
        }

        public IEnumerable<Blog> GetBlogs()
        {
            return _context.Blogs.Include(b => b.Author);
        }

        public IEnumerable<Blog> GetBlogsOfUser(string userId)
        {
            return _context.Blogs.Include(n => n.Author).Where(n => n.Author.Id == userId);
        }

        public IEnumerable<Blog> GetBlogsWithAuthor()
        {
            return _context.Blogs.Include(b => b.Author);
        }

        public void UpdateBlogs(Blog blog)
        {
            _context.Blogs.Update(blog);
            _context.SaveChanges();
        }
    }
}
