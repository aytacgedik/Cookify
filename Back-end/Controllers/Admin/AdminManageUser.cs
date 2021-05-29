using System.Collections.Generic;
using Back_end.Data;
using Back_end.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Back_end.Dtos;
using Back_end.Services;

namespace Back_end.Controllers
{
    [Route("admin/user")]
    [ApiController]
    public class AdminManageUserController: ControllerBase
    {
        private readonly IAdminManageUserService _userService;
        public AdminManageUserController(IAdminManageUserService userService)
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
            var user = _userService.GetUserById(id);
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
            var user = _userService.UpdateUserById(_user.Id,
                                            _user.Name,
                                            _user.Surname,
                                            _user.Email,
                                            (bool)_user.Verified,
                                            (bool)_user.Admin);
            return Ok(user);
        }
        
    }
}