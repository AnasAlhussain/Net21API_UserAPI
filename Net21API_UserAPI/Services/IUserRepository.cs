using Net21API_UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net21API_UserAPI.Services
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        User GetUser(int id);

        User AddUser(User newUser);
        void DeleteUser(User user);

        User Uppdate(User user);
    }
}
