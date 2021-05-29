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

        public IEnumerable<UserFriendDto> AddUserFriendById(int _userFollowerId, int _userFollowedId)
        {
            var userFriends = _userFriendRepository.AddUserFriendById(_userFollowerId, _userFollowedId);
            return userFriends.Select(x => x.AsDto()).ToList();
        }

        public IEnumerable<UserFriendDto> RemoveUserFriendById(int _userFollowerId, int _userFollowedId)
        {
            var userFriends = _userFriendRepository.RemoveUserFriendById(_userFollowerId, _userFollowedId);
            return userFriends.Select(x => x.AsDto()).ToList();
        }

        public IEnumerable<UserFriendDto> GetUserFriends()
        {
            var userFriends = _userFriendRepository.GetUserFriends();
            return userFriends.Select(x => x.AsDto()).ToList();
        }
    }
}