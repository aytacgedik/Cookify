using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Data;
using Back_end.Models;

namespace Controllers.UserFriendController
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
        [HttpPost]
        public ActionResult<IEnumerable<UserFriend>> createUserFriend(int userFollowerId, int userFollowedId)
        {
            var userFriendList = _repository.AddUserFriendById(userFollowerId, userFollowedId);
            return Ok(userFriendList);
        }

        //removeUserFriend()
        [HttpDelete]
        public ActionResult<IEnumerable<UserFriend>> removeUserFriend(int userFollowerId, int userFollowedId)
        {
            var userFriendList = _repository.RemoveUserFriendById(userFollowerId, userFollowedId);
            return Ok(userFriendList);
        }
    }
}
