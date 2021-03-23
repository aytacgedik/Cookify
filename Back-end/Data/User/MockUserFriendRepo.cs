using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models;

namespace Back_end.Data
{
    public class MockUserFriendRepo : IUserFriendRepo
    {
        public IEnumerable<UserFriend> AddUserFriendById(int _userFollowerId, int _userFollowedId)
        {
            List<UserFriend> userfriendlist = new List<UserFriend>
            {
                new UserFriend{ userFollowerId = 1, userFollowedId=3},
                new UserFriend{ userFollowerId = 3, userFollowedId=1},
                new UserFriend{ userFollowerId = 2, userFollowedId=4},
                new UserFriend{ userFollowerId = 4, userFollowedId=2}
            };
            userfriendlist.Add(new UserFriend { userFollowerId = _userFollowerId, userFollowedId = _userFollowedId });
            userfriendlist.Add(new UserFriend { userFollowerId = _userFollowedId, userFollowedId = _userFollowerId });
            return userfriendlist;
        }

        public IEnumerable<UserFriend> RemoveUserFriendById(int _userFollowerId, int _userFollowedId)
        {
            List<UserFriend> userfriendlist = new List<UserFriend>
            {
                new UserFriend{ userFollowerId = 1, userFollowedId=3},
                new UserFriend{ userFollowerId = 3, userFollowedId=1},
                new UserFriend{ userFollowerId = 2, userFollowedId=4},
                new UserFriend{ userFollowerId = 4, userFollowedId=2}
            };
            userfriendlist.RemoveAt(userfriendlist.FindIndex((u => u.userFollowerId == _userFollowerId) && (u => u.userFollowedId == _userFollowedId)));
            userfriendlist.RemoveAt(userfriendlist.FindIndex((u => u.userFollowerId == _userFollowedId) && (u => u.userFollowedId == _userFollowerId)));
            return userfriendlist;
        }
    }
}
