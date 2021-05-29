using System.Collections.Generic;
using Back_end.Dtos;

namespace Back_end.Services
{
    public interface IUserFriendService
    {
        IEnumerable<UserFriendDto> ServiceAddUserFriendById(int _userFollowerId, int _userFollowedId);
        IEnumerable<UserFriendDto> ServiceRemoveUserFriendById(int _userFollowerId, int _userFollowedId);
        IEnumerable<UserFriendDto> ServiceGetUserFriends();
    }
}