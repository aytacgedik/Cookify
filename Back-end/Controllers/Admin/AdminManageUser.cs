using System.Collections.Generic;
using Back_end.Data;
using Back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Back_end.Dtos;
using Back_end.Services;

namespace Back_end.Controllers
{
    [Route("admin/user")]
    [ApiController]
    public class AdminManageUserController: ControllerBase
    {
        private readonly IUserService _userService;
        public AdminManageUserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);

        }
        [HttpGet("{id}")]
         public ActionResult<UserDto> getUser(int id)
        {
            var user=_userService.GetUserById(id);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<UserDto>> removeUser(int id)
        {
            var users = _userService.RemoveUserById(id);
            return Ok(users);
        }

        [HttpPatch("{id}")]
        public ActionResult<UserDto> updateUser([FromBody] User _user)
        {
            var user = _userService.UpdateUserById(_user.id,
                                            _user.name,
                                            _user.surname,
                                            _user.email,
                                            _user.verified,
                                            _user.admin);
            return Ok(user);
        }
        
    }
}