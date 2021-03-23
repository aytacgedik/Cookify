using System.Collections.Generic;
using Back_end.Models;

namespace Back_end.Data
{
    public interface IUserRepo
    {
        IEnumerable<User> CreateUser(int id, string name, string surname, string email, bool verified, bool admin);
        IEnumerable<User> RemoveUserById(int id);
        User UpdateUserById(int id, string name, string surname, string email, bool verified, bool admin);
        User GetUserById(int id);
        IEnumerable<User> GetUsers();
    }
}