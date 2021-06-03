using System.Collections.Generic;
using Back_end.Dtos;

namespace Back_end.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> ServiceCreateUser(UserInputDto u);
        IEnumerable<UserDto> ServiceRemoveUserById(int id);
        UserDto ServiceUpdateUserById(int id,UserInputDto u);
        UserDto ServiceGetUserById(int id);
        IEnumerable<UserDto> ServiceGetUsers();
    }
}