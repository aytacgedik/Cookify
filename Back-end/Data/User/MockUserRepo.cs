using System.Collections.Generic;
using System.Linq;
using Back_end.DatabaseModels;
using Back_end.Dtos;

namespace Back_end.Data
{
    public class MockUserRepo : IUserRepo
    {
        private readonly CookifyContext _context;
        public MockUserRepo(CookifyContext context)
        {
            _context = context;
        }

        public IEnumerable<UserDto> CreateUser(int id,
                                            string name,
                                            string surname,
                                            string email,
                                            bool verified,
                                            bool admin)
        {
            _context.Add(new User
            {
                Id = id,
                Name = name,
                Surname = surname,
                Email = email,
                Verified = verified,
                Admin = admin
            });
            _context.SaveChanges();
            return _context.Users.Select(u=>u.AsDto());
        }

        public UserDto GetUserById(int id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault().AsDto();
        }

        public IEnumerable<UserDto> GetUsers()
        {
            return _context.Users.Select(u=>u.AsDto());
        }

        public IEnumerable<UserDto> RemoveUserById(int id)
        {
            _context.Users.Remove(_context.Users.Where(u => u.Id == id).FirstOrDefault());
            _context.SaveChanges();
            return _context.Users.Select(u=>u.AsDto());
        }

        public UserDto UpdateUserById(int id,
                                   string name,
                                   string surname,
                                   string email,
                                   bool verified,
                                   bool admin)
        {
            var user = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            user.Name = name;
            user.Surname = surname;
            user.Email = email;
            user.Verified = verified;
            user.Admin = admin;
            _context.SaveChanges();
            return user.AsDto();
        }
    }
}