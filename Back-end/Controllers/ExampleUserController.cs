using System.Collections.Generic;
using Back_end.Data;
using Back_end.Models;
using Microsoft.AspNetCore.Mvc;
//Keeping this as example. This gonna be deleted later.
namespace Controllers.ExampleUserCtrl
{
    [Route("api/ExampleUser")]
    [ApiController]
    public class ExampleUserController:ControllerBase
    {
        private readonly MockUserRepo _repository =new MockUserRepo();
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
    }
}