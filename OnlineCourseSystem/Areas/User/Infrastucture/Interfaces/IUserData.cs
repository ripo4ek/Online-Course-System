using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Infrastucture.Interfaces
{
    public interface IUserData
    {
        int GetAuthorsCount();
        Role GetRoleByName(string nameOfRole);
        ApplicationUser GetUserWithStats(string userId);
        void UpdateUser(ApplicationUser user);
        Domain.Model.ApplicationUser GetUser(string id);
        void DeleteUser(string id);
        void AddCourseToUser(Course course, ApplicationUser user);
        IEnumerable<ApplicationUser> GetUsersByRole(string role);

        ApplicationUser GetAuthorAsUser(string id);
        IEnumerable<ApplicationUser> GetThreeRandomUsers();
        IEnumerable<ApplicationUser> GetThreeRandomAuthors();
        int GetUserCount();
        IEnumerable<Domain.Model.ApplicationUser> GetUsers();

    }
}
