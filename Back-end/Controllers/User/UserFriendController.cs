using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Data;
using Back_end.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Back_end.Dtos;
using Back_end.Services;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(AuthenticationSchemes="Bearer")]

        [HttpPost]
        public ActionResult<IEnumerable<UserFriendDto>> createUserFriend(UserFriendDto _userfriend)
        {
            var userFriends = _userFriendService.ServiceAddUserFriendById((int)_userfriend.userFollowerId, (int)_userfriend.userFollowedId);

            return Ok(userFriends);
        }

        //removeUserFriend()
        //Done
        [Authorize(AuthenticationSchemes="Bearer")]

        [HttpDelete]
        public ActionResult<IEnumerable<UserFriendDto>> removeUserFriend(int userFollowerId, int userFollowedId)
        {
            var userFriends = _userFriendService.ServiceRemoveUserFriendById(userFollowerId, userFollowedId);
            return Ok(userFriends);
        }
    }
}
