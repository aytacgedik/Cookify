using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models;

namespace Back_end.Data
{
    public interface IUserFriendRepo
    {
        IEnumerable<UserFriend> AddUserFriendById(int _userFollowerId, int _userFollowedId);
        IEnumerable<UserFriend> RemoveUserFriendById(int _userFollowerId, int _userFollowedId);
        IEnumerable<UserFriend> GetUserFriends();
    }
}
