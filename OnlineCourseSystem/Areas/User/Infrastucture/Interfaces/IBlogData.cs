using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Infrastucture.Interfaces
{
    public interface IBlogData
    {
        IEnumerable<Blog> GetBlogs();
        Blog GetBlog(int id);

        Blog AddBlog(Blog blog);

        IEnumerable<Blog> GetBlogsOfUser(string userId);

        Blog GetBlogByUser(string userId);

        void UpdateBlogs(Blog blog);

        void DeleteBlog(Blog blog);

        IEnumerable<Blog> GetBlogsWithAuthor();


    }
}
