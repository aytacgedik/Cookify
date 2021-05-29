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

        public IEnumerable<UserDto> ServiceCreateUser(int id,
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

        public IEnumerable<UserDto> ServiceRemoveUserById(int id)
        {
            var users = _userRepository.RemoveUserById(id);
            return users.Select(x => x.AsDto()).ToList();
        }

        public UserDto ServiceUpdateUserById(int id,
                               string name,
                               string surname,
                               string email,
                               bool verified,
                               bool admin)
        {
            var user = _userRepository.UpdateUserById(id, name, surname, email, verified, admin);
            return user.AsDto();
        }

        public UserDto ServiceGetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            return user.AsDto();
        }

        public IEnumerable<UserDto> ServiceGetUsers()
        {
            var users = _userRepository.GetUsers();
            return users.Select(x => x.AsDto()).ToList();
        }
    }
}