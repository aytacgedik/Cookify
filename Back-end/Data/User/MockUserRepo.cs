using System.Collections.Generic;
using Back_end.Models;

namespace Back_end.Data
{
    public class MockUserRepo : IUserRepo
    {
        public List<User> UserRepo;

        public MockUserRepo()
        {
            UserRepo = new List<User>{
                new User{id=1,
                         name="Bond",
                         surname = "James Bond",
                         email="james@gg.com",
                         verified=true,
                         admin=false},
                new User{id=2,
                         name="It's me",
                         surname = "Mario",
                         email="PP@gg.com",
                         verified=true,
                         admin=true},
                new User{id=3,
                         name="OVER",
                         surname = "9000",
                         email="9001@gg.com",
                         verified=true,
                         admin=false}
            };
        }

        public IEnumerable<User> CreateUser(int id,
                                            string name,
                                            string surname,
                                            string email,
                                            bool verified,
                                            bool admin)
        {
            UserRepo.Add(new User
            {
                id = id,
                name = name,
                surname = surname,
                email = email,
                verified = verified,
                admin = admin
            });
            return UserRepo;
        }


        public IEnumerable<User> RemoveUserById(int id)
        {
            UserRepo.RemoveAt(UserRepo.FindIndex(u => u.id == id));
            return UserRepo;
        }


        public User UpdateUserById(int id,
                                   string name,
                                   string surname,
                                   string email,
                                   bool verified,
                                   bool admin)
        {
            int index = UserRepo.FindIndex(u => u.id == id);
            UserRepo[index].id = id;
            UserRepo[index].name = name;
            UserRepo[index].surname = surname;
            UserRepo[index].email = email;
            UserRepo[index].verified = verified;
            UserRepo[index].admin = admin;
            return UserRepo[index];
        }


        public IEnumerable<User> GetUsers()
        {
            return UserRepo;
        }


        public User GetUserById(int id)
        {
            return UserRepo[UserRepo.FindIndex(u => u.id == id)];
        }
    }
}