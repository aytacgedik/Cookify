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

        public IEnumerable<DatabaseModels.UserFriend> AddUserFriendById(int _userFollowerId, int _userFollowedId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DatabaseModels.UserFriend> GetUserFriends()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DatabaseModels.UserFriend> RemoveUserFriendById(int _userFollowerId, int _userFollowedId)
        {
            throw new NotImplementedException();
        }
    }
}