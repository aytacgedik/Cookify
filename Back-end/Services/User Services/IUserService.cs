using System.Collections.Generic;
using Back_end.Dtos;

namespace Back_end.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> ServiceCreateUser(int id,
                                        string name,
                                        string surname,
                                        string email,
                                        bool verified,
                                        bool admin);
        IEnumerable<UserDto> ServiceRemoveUserById(int id);
        UserDto ServiceUpdateUserById(int id,
                               string name,
                               string surname,
                               string email,
                               bool verified,
                               bool admin);
        UserDto ServiceGetUserById(int id);
        IEnumerable<UserDto> ServiceGetUsers();
    }
}