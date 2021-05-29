using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<UserDto> CreateUser(int id,
                                               string name,
                                               string surname,
                                               string email,
                                               bool verified,
                                               bool admin)
        {
            var users = _userRepository.CreateUser(id,
                                                   name,
                                                   surname,
                                                   email,
                                                   verified,
                                                   admin);
            return users.Select(x => x.AsDto()).ToList();
        }

        public IEnumerable<UserDto> RemoveUserById(int id)
        {
            var users = _userRepository.RemoveUserById(id);
            return users.Select(x => x.AsDto()).ToList();
        }

        public UserDto UpdateUserById(int id,
                               string name,
                               string surname,
                               string email,
                               bool verified,
                               bool admin)
        {
            var user = _userRepository.UpdateUserById(id, name, surname, email, verified, admin);
            return user.AsDto();
        }

        public UserDto GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            return user.AsDto();
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var users = _userRepository.GetUsers();
            return users.Select(x => x.AsDto()).ToList();
        }
    }
}