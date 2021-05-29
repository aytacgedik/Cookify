using System.Collections.Generic;
using Back_end.Dtos;

namespace Back_end.Services
{
    public interface IAdminManageUserService
    {
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