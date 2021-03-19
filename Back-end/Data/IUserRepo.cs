//Creating this cs as example. Gonna be changed later on
using System.Collections.Generic;
using Models.Users;

namespace Data.Repo
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
    }
}