using Net21API_UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net21API_UserAPI.Services
{
    public class SQLUserRepo : IUserRepository
    {
        private UserDbContext _userContext;
        public SQLUserRepo(UserDbContext userContext)
        {
            _userContext = userContext;
        }

        public User AddUser(User newUser)
        {
            _userContext.Users.Add(newUser);
            _userContext.SaveChanges();
            return newUser;
        }

        public void DeleteUser(User user)
        {
            _userContext.Users.Remove(user);
            _userContext.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _userContext.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _userContext.Users.FirstOrDefault(u => u.UserId == id);
        }

        public User Uppdate(User user)
        {
            var result =_userContext.Users.Find(user.UserId);
            if (result != null)
            {
                result.Name = user.Name;
                _userContext.Users.Update(result);
                _userContext.SaveChanges();
            }
            return user;
        }
    }
}
