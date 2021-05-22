using System.Collections.Generic;
using Back_end.Data;
using Back_end.Dtos;

namespace Back_end.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepo _userRepository;

        public UserServices(IUserRepo userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<UserDto> CreateUser(int id, string name, string surname, string email, bool verified, bool admin)
        {
            throw new System.NotImplementedException();
        }

        public UserDto GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserDto> GetUsers()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<UserDto> RemoveUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public UserDto UpdateUserById(int id, string name, string surname, string email, bool verified, bool admin)
        {
            throw new System.NotImplementedException();
        }
    }
}