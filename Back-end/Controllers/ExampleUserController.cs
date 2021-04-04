using System.Collections.Generic;
using Back_end.Data;
using Back_end.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Back_end.Dtos;
//Keeping this as example. This gonna be deleted later.
namespace Back_end.Controllers
{
    [Route("api/ExampleUser")]
    [ApiController]
    public class ExampleUserController:ControllerBase
    {
        private readonly IUserRepo _repository;
        public ExampleUserController(IUserRepo repository)
        {
            _repository=repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {
            var users=_repository.GetUsers();
            if(users==null)
                return NotFound();
            var usersDto=users.Select(x=>x.AsDto()).ToList();
            return Ok(usersDto);

        }
        [HttpGet("{id}")]
        public ActionResult<User> GetAllUsers(int id)
        {
            var user=_repository.GetUserById(id);
            if(user==null)
                return NotFound();
            return Ok(user.AsDto());
        }
        
    }
}