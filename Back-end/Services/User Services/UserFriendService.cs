using System.Collections.Generic;
using System.Linq;
using Back_end.Data;
using Back_end.Dtos;

namespace Back_end.Services
{
    public class UserFriendServices : IUserFriendService
    {
        private readonly IUserFriendRepo _userFriendRepository;

        public UserFriendServices(IUserFriendRepo userFriendRepository)
        {
            _userFriendRepository = userFriendRepository;
        }

        public IEnumerable<UserFriendDto> ServiceAddUserFriendById(int _userFollowerId, int _userFollowedId)
        {
            var userFriends = _userFriendRepository.AddUserFriendById(_userFollowerId, _userFollowedId);
<<<<<<< HEAD
            return userFriends.Select(x => x).ToList();
=======
            return userFriends;
>>>>>>> d76d791a87909bd44fcffa36681ae71c89bd4d25
        }

        public IEnumerable<UserFriendDto> ServiceRemoveUserFriendById(int _userFollowerId, int _userFollowedId)
        {
            var userFriends = _userFriendRepository.RemoveUserFriendById(_userFollowerId, _userFollowedId);
<<<<<<< HEAD
            return userFriends.Select(x => x).ToList();
=======
            return userFriends;
>>>>>>> d76d791a87909bd44fcffa36681ae71c89bd4d25
        }

        public IEnumerable<UserFriendDto> ServiceGetUserFriends()
        {
            var userFriends = _userFriendRepository.GetUserFriends();
<<<<<<< HEAD
            return userFriends.Select(x => x).ToList();
=======
            return userFriends;
>>>>>>> d76d791a87909bd44fcffa36681ae71c89bd4d25
        }
    }
}