using System.Collections.Generic;
using System.Linq;
using Back_end.DatabaseModels;

namespace Back_end.Data
{
    public class MockUserRepo : IUserRepo
    {
        private readonly CookifyContext _context;
        public MockUserRepo(CookifyContext context)
        {
            _context = context;

        }

        public IEnumerable<User> CreateUser(int id, string name, string surname, string email, bool verified, bool admin)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> RemoveUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public User UpdateUserById(int id, string name, string surname, string email, bool verified, bool admin)
        {
            throw new System.NotImplementedException();
        }
    }
}