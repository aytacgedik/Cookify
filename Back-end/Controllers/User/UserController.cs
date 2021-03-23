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
        [HttpPost("{id}")]
        public ActionResult<IEnumerable<User>> createUser(int id, string name, string surname, string email, bool verified, bool admin)
        {
            var users = _repository.CreateUser(id, name, surname, email, verified, admin);
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
        public ActionResult updateUser(int id)
        {
            var user = _repository.UpdateUserById(id);
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
