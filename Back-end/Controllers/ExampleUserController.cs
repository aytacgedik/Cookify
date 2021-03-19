using System.Collections.Generic;
using Data.Repo;
using Microsoft.AspNetCore.Mvc;
using Models.Users;

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