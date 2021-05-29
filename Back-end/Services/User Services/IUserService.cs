using System.Collections.Generic;
using Back_end.Dtos;

namespace Back_end.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> CreateUser(int id,
                                        string name,
                                        string surname,
                                        string email,
                                        bool verified,
                                        bool admin);
        IEnumerable<UserDto> RemoveUserById(int id);
        UserDto UpdateUserById(int id,
                               string name,
                               string surname,
                               string email,
                               bool verified,
                               bool admin);
        UserDto GetUserById(int id);
        IEnumerable<UserDto> GetUsers();
    }
}