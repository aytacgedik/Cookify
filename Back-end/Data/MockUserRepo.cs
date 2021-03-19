//Creating this cs as example. Gonna be changed later on
using System.Collections.Generic;
using Models.Users;

namespace Data.Repo
{
    public class MockUserRepo : IUserRepo
    {
        public IEnumerable<User> GetUsers(){
            return new List<User>{
                new User{id=1, name="Bond", surname = "James Bond", email="james@gg.com", verified=true,admin=false},
                new User{id=2, name="It's me", surname = "Mario", email="PP@gg.com", verified=true,admin=true},
                new User{id=3, name="OVER", surname = "9000", email="9001@gg.com", verified=true,admin=false}
            };
        }
        public User GetUserById(int id){
            return new User{id=1, name="Bond", surname = "James Bond", email="james@gg.com", verified=true,admin=false};
        }
    }
}