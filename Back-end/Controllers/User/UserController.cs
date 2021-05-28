using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Data;
using Back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Back_end.Dtos;
using Back_end.Services;

namespace Back_end.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        //createUser()
        //Done
        [HttpPost]
        public ActionResult<IEnumerable<UserDto>> createUser([FromBody] User _user)
        {
            var users = _userService.CreateUser(_user.id,
                                               _user.name,
                                               _user.surname,
                                               _user.email,
                                               _user.verified,
                                               _user.admin);
            if (users == null)
            {
                return NotFound();
            }
            
            return Ok(users);
        }


        //removeUser()
        //Done
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<UserDto>> removeUser(int id)
        {
            //var users ;//= //_repository.RemoveUserById(id);
            // if (users == null)
            // {
            //     return NotFound();
            // }
            // var usersDto = users.Select(x => x.AsDto()).ToList();
            return Ok();
        }


        //updateUser()
        //Done
        [HttpPatch("{id}")]
        public ActionResult<UserDto> updateUser([FromBody] User _user)
        {
            // var user = _repository.UpdateUserById(_user.id,
            //                                       _user.name,
            //                                       _user.surname,
            //                                       _user.email,
            //                                       _user.verified,
            //                                       _user.admin);
            // if (user == null)
            // {
            //     return NotFound();
            // }
             return Ok();
        }


        //getUser()
        //Done
        [HttpGet("{id}")]
        public ActionResult<UserDto> getUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        //Done
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {
            // var users = _repository.GetUsers();
            // if (users == null)
            // {
            //     return NotFound();
            // }
            //var usersDto = users.Select(x => x.AsDto()).ToList();
             return Ok();
        }
    }
}
