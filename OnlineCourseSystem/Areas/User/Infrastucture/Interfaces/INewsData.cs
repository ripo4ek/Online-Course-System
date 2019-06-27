using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Infrastucture.Interfaces
{
    public interface INewsData
    {
        IEnumerable<News> GetNews();
        IEnumerable<News> GetFiveRandomNews();
        News AddNews(News news);
        IEnumerable<News> GetNewsWithAuthor();
        void UpdateNews(News news);
        IEnumerable<News> GetNewsOfUser(string userId);
        News GetNews(string userId);
        News GetNews(int id);
        void DeleteNews(News news);

        int NewsCount();

    }
}
