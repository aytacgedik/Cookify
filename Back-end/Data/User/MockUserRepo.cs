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

        public IEnumerable<UserDto> CreateUser(UserInputDto u)
        {
            _context.Add(new User
            {
                //Id = u.id,
                Name = u.name,
                Surname = u.surname,
                Email = u.email,
                Verified = u.verified,
                Admin = u.admin
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

        public UserDto UpdateUserById(int id,UserInputDto u)
        {
            var user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            user.Name = u.name;
            user.Surname = u.surname;
            user.Email =u.email;
            user.Verified = u.verified;
            user.Admin = u.admin;
            _context.SaveChanges();
            return user.AsDto();
        }
    }
}