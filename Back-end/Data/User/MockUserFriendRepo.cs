using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models;

namespace Back_end.Data
{
    public class MockUserFriendRepo : IUserFriendRepo
    {
        public List<UserFriend> UserFriendRepo;

        public MockUserFriendRepo()
        {
            UserFriendRepo = new List<UserFriend>
            {
                new UserFriend{ userFollowerId = 1, userFollowedId=3},
                new UserFriend{ userFollowerId = 3, userFollowedId=1},
                new UserFriend{ userFollowerId = 2, userFollowedId=4},
                new UserFriend{ userFollowerId = 4, userFollowedId=2}
            };
        }

        public IEnumerable<UserFriend> AddUserFriendById(int _userFollowerId, int _userFollowedId)
        {
            UserFriendRepo.Add(new UserFriend { userFollowerId = _userFollowerId, userFollowedId = _userFollowedId });
            UserFriendRepo.Add(new UserFriend { userFollowerId = _userFollowedId, userFollowedId = _userFollowerId });
            return UserFriendRepo;
        }

        public IEnumerable<UserFriend> RemoveUserFriendById(int _userFollowerId, int _userFollowedId)
        {
            for (int i = 0; i < UserFriendRepo.Count; i++)
            {
                if ((UserFriendRepo[i].userFollowedId == _userFollowedId &&
                     UserFriendRepo[i].userFollowerId == _userFollowerId)
                     ||
                    ((UserFriendRepo[i].userFollowedId == _userFollowerId &&
                     (UserFriendRepo[i].userFollowerId == _userFollowedId))))
                {
                    UserFriendRepo.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < UserFriendRepo.Count; i++)
            {
                if ((UserFriendRepo[i].userFollowedId == _userFollowedId &&
                     UserFriendRepo[i].userFollowerId == _userFollowerId)
                     ||
                    ((UserFriendRepo[i].userFollowedId == _userFollowerId &&
                     (UserFriendRepo[i].userFollowerId == _userFollowedId))))
                {
                    UserFriendRepo.RemoveAt(i);
                    break;
                }
            }
            return UserFriendRepo;
        }

        public IEnumerable<UserFriend> GetUserFriends()
        {
            return UserFriendRepo;
        }
    }
}