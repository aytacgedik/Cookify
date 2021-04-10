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
            // foreach(var u in userfriendlist){
            //     if((u.userFollowedId==_userFollowedId&&u.userFollowerId==_userFollowerId)||
            //        (u.userFollowedId==_userFollowerId&&u.userFollowerId==_userFollowedId)){
            //         userfriendlist.Remove(u);
            //     }
            // }

            for (int i = 0; i < userfriendlist.Count; i++)
            {
                if ((userfriendlist[i].userFollowedId == _userFollowedId &&
                     userfriendlist[i].userFollowerId == _userFollowerId)
                     ||
                    ((userfriendlist[i].userFollowedId == _userFollowerId &&
                     (userfriendlist[i].userFollowerId == _userFollowedId))))
                {
                    userfriendlist.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < userfriendlist.Count; i++)
            {
                if ((userfriendlist[i].userFollowedId == _userFollowedId &&
                     userfriendlist[i].userFollowerId == _userFollowerId)
                     ||
                    ((userfriendlist[i].userFollowedId == _userFollowerId &&
                     (userfriendlist[i].userFollowerId == _userFollowedId))))
                {
                    userfriendlist.RemoveAt(i);
                    break;
                }
            }
            return userfriendlist;
        }

        public IEnumerable<UserFriend> GetUserFriends()
        {
            List<UserFriend> userfriendlist = new List<UserFriend>
            {
                new UserFriend{ userFollowerId = 1, userFollowedId=3},
                new UserFriend{ userFollowerId = 3, userFollowedId=1},
                new UserFriend{ userFollowerId = 2, userFollowedId=4},
                new UserFriend{ userFollowerId = 4, userFollowedId=2}
            };
            return userfriendlist;
        }
    }
}
