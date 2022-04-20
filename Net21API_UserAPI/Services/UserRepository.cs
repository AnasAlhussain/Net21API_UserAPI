using Net21API_UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net21API_UserAPI.Services
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>()
        {
            new User(){UserId = 101, Name = "Tobias"},
            new User(){UserId = 102, Name = "Reidar"},
            new User(){UserId = 103, Name = "Anas"},
        };

        public User AddUser(User newUser)
        {
            users.Add(newUser);
            return newUser;
        }

        public void DeleteUser(User user)
        {
            users.Remove(user);
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUser(int id)
        {
            return users.FirstOrDefault(u => u.UserId == id);
        }

        public User Uppdate(User user)
        {
           var exUser = GetUser(user.UserId);
            exUser.Name = user.Name;
            return user;
        }
    }
}
