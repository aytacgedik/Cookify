using System.Collections.Generic;
using Back_end.Models;

namespace Back_end.Data
{
    public class MockUserRepo : IUserRepo
    {
        public IEnumerable<User> CreateUser(int id, string name, string surname, string email, bool verified, bool admin)
        {
            List<User> userlist = new List<User>{
                new User{id=1, name="Bond", surname = "James Bond", email="james@gg.com", verified=true,admin=false},
                new User{id=2, name="It's me", surname = "Mario", email="PP@gg.com", verified=true,admin=true},
                new User{id=3, name="OVER", surname = "9000", email="9001@gg.com", verified=true,admin=false}
            };
            userlist.Add(new User { id, name, surname, email, verified, admin });
            return userlist;
        }


        public IEnumerable<User> RemoveUserById(int id)
        {
            List<User> userlist = new List<User>{
                new User{id=1, name="Bond", surname = "James Bond", email="james@gg.com", verified=true,admin=false},
                new User{id=2, name="It's me", surname = "Mario", email="PP@gg.com", verified=true,admin=true},
                new User{id=3, name="OVER", surname = "9000", email="9001@gg.com", verified=true,admin=false}
            };
            userlist.RemoveAt(userlist.FindIndex(u => u.id == id));
            return userlist;
        }


        public User UpdateUserById(int id, string name, string surname, string email, bool verified, bool admin)
        {
            List<User> userlist = new List<User>{
                new User{id=1, name="Bond", surname = "James Bond", email="james@gg.com", verified=true,admin=false},
                new User{id=2, name="It's me", surname = "Mario", email="PP@gg.com", verified=true,admin=true},
                new User{id=3, name="OVER", surname = "9000", email="9001@gg.com", verified=true,admin=false}
            };
            userlist[userlist.FindIndex(u => u.id == id)] = new User { id, name, surname, email, verified, admin };
        }


        public IEnumerable<User> GetUsers()
        {
            return new List<User>{
                new User{id=1, name="Bond", surname = "James Bond", email="james@gg.com", verified=true,admin=false},
                new User{id=2, name="It's me", surname = "Mario", email="PP@gg.com", verified=true,admin=true},
                new User{id=3, name="OVER", surname = "9000", email="9001@gg.com", verified=true,admin=false}
            };
        }


        public User GetUserById(int id)
        {
            List<User> userlist = new List<User>{
                new User{id=1, name="Bond", surname = "James Bond", email="james@gg.com", verified=true,admin=false},
                new User{id=2, name="It's me", surname = "Mario", email="PP@gg.com", verified=true,admin=true},
                new User{id=3, name="OVER", surname = "9000", email="9001@gg.com", verified=true,admin=false}
            };
            return userlist[userlist.FindIndex(u => u.id == id)];
        }
    }
}