using System.Collections.Generic;
using Back_end.DatabaseModels;

namespace Back_end.Data
{
    public class MockUserRepo : IUserRepo
    {
        public List<User> UserRepo;

        public MockUserRepo()
        {
            // UserRepo = new List<User>{
            //     new User{id=1,
            //              name="Bond",
            //              surname = "James Bond",
            //              email="james@gg.com",
            //              verified=true,
            //              admin=false},
            //     new User{id=2,
            //              name="It's me",
            //              surname = "Mario",
            //              email="PP@gg.com",
            //              verified=true,
            //              admin=true},
            //     new User{id=3,
            //              name="OVER",
            //              surname = "9000",
            //              email="9001@gg.com",
            //              verified=true,
            //              admin=false}
            // };
        }

        public IEnumerable<User> CreateUser(int id, string name, string surname, string email, bool verified, bool admin)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> RemoveUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public User UpdateUserById(int id, string name, string surname, string email, bool verified, bool admin)
        {
            throw new System.NotImplementedException();
        }
    }
}