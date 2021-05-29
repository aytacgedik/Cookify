using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Data;
using Back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Back_end.Dtos;
using Back_end.Services;

namespace Back_end.Controllers
{
    [Route("api/user_friends")]
    [ApiController]
    public class UserFriendController : ControllerBase
    {
        private readonly IUserFriendService _userFriendService;
        public UserFriendController(IUserFriendService userFriendService)
        {
            _userFriendService = userFriendService;
        }

        //createUserFriend()
        //Done
        [HttpPost]
        public ActionResult<IEnumerable<UserFriendDto>> createUserFriend([FromBody] UserFriend _userfriend)
        {
            var userFriends = _userFriendService.AddUserFriendById(_userfriend.userFollowerId,
                                                                   _userfriend.userFollowedId);

            return Ok(userFriends);
        }

        //removeUserFriend()
        //Done
        [HttpDelete]
        public ActionResult<IEnumerable<UserFriendDto>> removeUserFriend(int userFollowerId, int userFollowedId)
        {
            var userFriends = _userFriendService.RemoveUserFriendById(userFollowerId, userFollowedId);
            return Ok(userFriends);
        }
    }
}
