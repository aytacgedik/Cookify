using System.Collections.Generic;
using Back_end.Data;
using Back_end.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Back_end.Dtos;
using Back_end.Services;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Policy = "Admin",AuthenticationSchemes="Bearer")]

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);

        }

        [Authorize(Policy = "Admin",AuthenticationSchemes="Bearer")]

        [HttpGet("{id}")]
        public ActionResult<UserDto> getUser(int id)
        {
            var user = _userService.GetUserById(id);
            return Ok(user);
        }

        [Authorize(Policy = "Admin",AuthenticationSchemes="Bearer")]

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<UserDto>> removeUser(int id)
        {
            var users = _userService.RemoveUserById(id);
            return Ok(users);
        }
        [Authorize(Policy = "Admin",AuthenticationSchemes="Bearer")]

        [HttpPatch("{id}")]
        public ActionResult<UserDto> updateUser(int id, UserInputDto _user)
        {
            var user = _userService.UpdateUserById(id,_user);
            return Ok(user);
        }
        
    }
}