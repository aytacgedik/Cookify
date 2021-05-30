using System.Collections.Generic;
using System.Linq;
using Back_end.DatabaseModels;
using Back_end.Dtos;

namespace Back_end.Data
{
    public class MockUserFriendRepo : IUserFriendRepo
    {
        private readonly CookifyContext _context;
        public MockUserFriendRepo(CookifyContext context)
        {
            _context = context;
        }
        public IEnumerable<UserFriendDto> AddUserFriendById(int _userFollowerId, int _userFollowedId)
        {
            _context.Add(new UserFriend { UserFollowerId = _userFollowerId, UserFollowedId = _userFollowedId });
            _context.Add(new UserFriend { UserFollowerId = _userFollowedId, UserFollowedId = _userFollowerId });
            _context.SaveChanges();
            return _context.UserFriends.Select(x=>x.AsDto());
        }

        public IEnumerable<UserFriendDto> RemoveUserFriendById(int _userFollowerId, int _userFollowedId)
        {
            _context.UserFriends.Remove(_context.UserFriends.Where(uf => uf.UserFollowerId == _userFollowerId && uf.UserFollowedId == _userFollowedId).FirstOrDefault());
            _context.UserFriends.Remove(_context.UserFriends.Where(uf => uf.UserFollowerId == _userFollowedId && uf.UserFollowedId == _userFollowerId).FirstOrDefault());
            _context.SaveChanges();
            return _context.UserFriends.Select(u=>u.AsDto());
        }

        public IEnumerable<UserFriendDto> GetUserFriends()
        {
            return _context.UserFriends.Select(u=>u.AsDto());
        }
    }
}