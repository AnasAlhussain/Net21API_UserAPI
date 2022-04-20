using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net21API_UserAPI.Models;
using Net21API_UserAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net21API_UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IUserRepository _userRepo;
        public UsersController(IUserRepository URepo)
        {
            _userRepo = URepo;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userRepo.GetAllUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetSingelUser(int id)
        {
            var result = _userRepo.GetUser(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"User With ID {id} Not Founded.......");
        }

        [HttpPost]
        public IActionResult AddNewUSer(User newUser)
        {
            _userRepo.AddUser(newUser);

            return Created(HttpContext.Request.Scheme + "://"
                + HttpContext.Request.Host
                + HttpContext.Request.Path + "/" + newUser.UserId, newUser);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
           var UserToDelete = _userRepo.GetUser(id);
            if (UserToDelete != null)
            {
                _userRepo.DeleteUser(UserToDelete);
                return Ok();
            }

            return NotFound($" The User With ID {id} is not founded to delete....");
        }


        [HttpPut("{id}")]
        public IActionResult EditUSer(int id , User UserToUpdate)
        {
           var existuser =  _userRepo.GetUser(id);

            if (existuser != null)
            {
                UserToUpdate.UserId = existuser.UserId;
                _userRepo.Uppdate(UserToUpdate);
            }
            return Ok();
        }
    }
}
