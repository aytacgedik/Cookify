using System.Collections.Generic;
using Back_end.Data;
using Back_end.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Back_end.Dtos;
using System.Linq;
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
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = _repository.GetUsers();
            if (users == null) {
                return NotFound();
            }
            var usersDto = users.Select(x => x.AsDto()).ToList();
            return Ok(usersDto);

        }
        [HttpGet("{id}")]
         public ActionResult<UserDto> GetAllUsers(int id)
        {
            var user=_repository.GetUserById(id);
            if (user == null) {
                return NotFound();
            }
            return Ok(user.AsDto());
        }
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<UserDto>> RemoveUser(int id)
        {
            var users = _repository.RemoveUserById(id);
            if (users == null) {
                return NotFound();
            }
            var usersDto = users.Select(x => x.AsDto()).ToList();
            return Ok(usersDto);
        }

        [HttpPatch("{id}")]
        public ActionResult<UserDto> updateUser([FromBody] User _user)
        {
            var user = _repository.UpdateUserById(_user.Id,_user.Name,_user.Surname,_user.Email,(bool)_user.Verified,(bool)_user.Admin);
            if (user == null) {
                return NotFound();
            }
            return Ok(user.AsDto());
        }
        
    }
}