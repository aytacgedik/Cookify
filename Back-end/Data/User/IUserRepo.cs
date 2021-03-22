//Creating this cs as example. Gonna be changed later on
using System.Collections.Generic;
using Back_end.Models;

namespace Back_end.Data
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
    }
}