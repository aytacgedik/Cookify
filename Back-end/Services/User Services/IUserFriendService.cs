using System.Collections.Generic;
using Back_end.Dtos;

namespace Back_end.Services
{
    public interface IUserFriendService
    {
        IEnumerable<UserFriendDto> AddUserFriendById(int _userFollowerId, int _userFollowedId);
        IEnumerable<UserFriendDto> RemoveUserFriendById(int _userFollowerId, int _userFollowedId);
        IEnumerable<UserFriendDto> GetUserFriends();
    }
}