using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Data;
using Back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.UserController
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;
        public UserController(IUserRepo repository)
        {
            _repository = repository;
        }


        //createUser()
        [HttpPost]
        public ActionResult<IEnumerable<User>> createUser([FromBody] User _user)
        {
            var users = _repository.CreateUser(_user.id,_user.name,_user.surname,_user.email,_user.verified,_user.admin);
            return Ok(users);
        }


        //removeUser()
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<User>> removeUser(int id)
        {
            var users = _repository.RemoveUserById(id);
            return Ok(users);
        }


        //updateUser()
        [HttpPatch("{id}")]
        public ActionResult<User> updateUser([FromBody] User _user)
        {
            var user = _repository.UpdateUserById(_user.id,_user.name,_user.surname,_user.email,_user.verified,_user.admin);
            return Ok(user);
        }


        //getUser()
        [HttpGet("{id}")]
        public ActionResult<User> getUser(int id)
        {
            var user = _repository.GetUserById(id);
            return Ok(user);
        }


        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _repository.GetUsers();
            return Ok(users);
        }
    }
}
