using System.Collections.Generic;
using Back_end.DatabaseModels;

namespace Back_end.Data
{
    public interface IUserFriendRepo
    {
        IEnumerable<UserFriend> AddUserFriendById(int _userFollowerId, int _userFollowedId);
        IEnumerable<UserFriend> RemoveUserFriendById(int _userFollowerId, int _userFollowedId);
        IEnumerable<UserFriend> GetUserFriends();
    }
}
