using System.Collections.Generic;
using Back_end.Dtos;

namespace Back_end.Services
{
    public interface IAdminManageUserService
    {
        IEnumerable<UserDto> RemoveUserById(int id);
        UserDto UpdateUserById(int id,UserInputDto us);
        UserDto GetUserById(int id);
        IEnumerable<UserDto> GetUsers();
    }
}