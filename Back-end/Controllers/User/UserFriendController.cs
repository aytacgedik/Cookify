using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Data;
using Back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Back_end.Dtos;

namespace Back_end.Controllers
{
    [Route("api/user_friends")]
    [ApiController]
    public class UserFriendController : ControllerBase
    {
        private readonly IUserFriendRepo _repository;
        public UserFriendController(IUserFriendRepo repository)
        {
            _repository = repository;
        }

        //createUserFriend()
        //Done
        [HttpPost]
        public ActionResult<IEnumerable<UserFriendDto>> createUserFriend([FromBody] UserFriend _userfriend)
        {
            var userFriendList = _repository.AddUserFriendById(_userfriend.userFollowerId,
                                                               _userfriend.userFollowedId);
            if (userFriendList == null)
            {
                return NotFound();
            }
            var userFriendListDto = userFriendList.Select(x => x.AsDto()).ToList();
            return Ok(userFriendListDto);
        }

        //removeUserFriend()
        //Done
        [HttpDelete]
        public ActionResult<IEnumerable<UserFriendDto>> removeUserFriend(int userFollowerId, int userFollowedId)
        {
            var userFriendList = _repository.RemoveUserFriendById(userFollowerId, userFollowedId);
            if (userFriendList == null)
            {
                return NotFound();
            }
            var userFriendListDto = userFriendList.Select(x => x.AsDto()).ToList();
            return Ok(userFriendListDto);
        }
    }
}
