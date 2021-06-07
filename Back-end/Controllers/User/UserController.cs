using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Data;
using Back_end.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Back_end.Dtos;
using Back_end.Services;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(AuthenticationSchemes="Bearer")]

        [HttpPost]
        public ActionResult<IEnumerable<UserDto>> createUser( UserInputDto _user)
        {
            var users = _userService.ServiceCreateUser(_user);
            return Ok(users);
        }


        //removeUser()
        //Done
        [Authorize(AuthenticationSchemes="Bearer")]

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<UserDto>> removeUser(int id)
        {
            var users = _userService.ServiceRemoveUserById(id);
            return Ok(users);
        }


        //updateUser()
        //Done
        [Authorize(AuthenticationSchemes="Bearer")]

        [HttpPatch("{id}")]
        public ActionResult<UserDto> updateUser(int id, UserInputDto _user)
        {
            var user = _userService.ServiceUpdateUserById(id,_user);
            return Ok(user);
        }


        //getUser()
        //Done
        [Authorize(AuthenticationSchemes="Bearer")]

        [HttpGet("{id}")]
        public ActionResult<UserDto> getUser(int id)
        {
            var user = _userService.ServiceGetUserById(id);
            return Ok(user);
        }


        //Done
        [Authorize(AuthenticationSchemes="Bearer")]

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = _userService.ServiceGetUsers();
            return Ok(users);
        }
    }
}
