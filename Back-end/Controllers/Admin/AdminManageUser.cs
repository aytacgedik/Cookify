using System.Collections.Generic;
using Back_end.Data;
using Back_end.Models;
using Microsoft.AspNetCore.Mvc;
//Keeping this as example. This gonna be deleted later.
namespace Controllers.AdminManageUserController
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
        
    }
}