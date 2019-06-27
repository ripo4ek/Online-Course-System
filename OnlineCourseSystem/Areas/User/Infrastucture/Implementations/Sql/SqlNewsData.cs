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
    public class SqlNewsData : INewsData
    {
        private readonly OnlineCourseSystemContext _context;

        public SqlNewsData(OnlineCourseSystemContext context)
        {
            _context = context;
        }
        public News AddNews(News news)
        {
            _context.News.Add(news);
            _context.SaveChanges();
            return news;
        }

        public void DeleteNews(News news)
        {
            _context.News.Remove(news);
            _context.SaveChanges();
        }

        public IEnumerable<News> GetFiveRandomNews()
        {
            ;
            return _context.News.Include(a => a.Author).Take(5);
        }

        public IEnumerable<News> GetNews()
        {
            return _context.News.Include(t => t.Author);
        }

        public News GetNews(string userId)
        {
            return _context.News.First(n => n.Author.Id == userId);
        }

        public News GetNews(int id)
        {
            return _context.News.Include(t => t.Author).First(b => b.Id == id);
        }

        public IEnumerable<News> GetNewsOfUser(string userId)
        {
            return _context.News.Include(n => n.Author).Where(n => n.Author.Id == userId);
        }

        public IEnumerable<News> GetNewsWithAuthor()
        {
            return _context.News.Include(n => n.Author);
        }

        public int NewsCount()
        {
            return _context.News.Count();
        }

        public void UpdateNews(News news)
        {
            _context.News.Update(news);
            _context.SaveChanges();
        }
    }
}
