using System.Collections.Generic;
using Back_end.DatabaseModels;
using Back_end.Dtos;

namespace Back_end.Data
{
    public interface IUserRepo
    {
        IEnumerable<UserDto> CreateUser(UserInputDto u);
        IEnumerable<UserDto> RemoveUserById(int id);
        UserDto UpdateUserById(int id, UserInputDto u);
        UserDto GetUserById(int id);
        IEnumerable<UserDto> GetUsers();
    }
}