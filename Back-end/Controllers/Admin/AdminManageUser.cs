using System.Collections.Generic;
using Back_end.Data;
using Back_end.Models;
using Microsoft.AspNetCore.Mvc;
//Keeping this as example. This gonna be deleted later.
namespace Back_end.Controllers
{
    [Route("admin/user")]
    [ApiController]
    public class AdminManageUserController:ControllerBase
    {
        private readonly IUserRepo _repository;
        public AdminManageUserController(IUserRepo repository)
        {
            _repository=repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users=_repository.GetUsers();

            return Ok(users);

        }
        [HttpGet("{id}")]
         public ActionResult<User> GetAllUsers(int id)
        {
            var user=_repository.GetUserById(id);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<User>> RemoveUser(int id)
        {
            var users = _repository.RemoveUserById(id);
            return Ok(users);
        }

        [HttpPatch("{id}")]
        public ActionResult<User> updateUser([FromBody] User _user)
        {
            var user = _repository.UpdateUserById(_user.id,_user.name,_user.surname,_user.email,_user.verified,_user.admin);
            return Ok(user);
        }
        
    }
}