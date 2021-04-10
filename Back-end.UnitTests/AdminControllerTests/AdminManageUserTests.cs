using System;
using Xunit;
using Moq;
using Back_end.Controllers;
using Back_end.Data;
using Back_end.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Back_end.UnitTests
{
    public class UserComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            if (x == null || y == null) return false;

            bool equals = x.id==y.id && x.name == y.name && x.surname == y.surname 
                && x.email == y.email && x.verified == y.verified && x.admin == y.admin;
            return equals;
        }

        public int GetHashCode(User obj)
        {
            if (obj == null) return int.MinValue;

            int hash = 1;
            hash = hash + obj.id.GetHashCode();
            hash = hash + obj.name.GetHashCode();
            hash = hash + obj.surname.GetHashCode();
            hash = hash + obj.email.GetHashCode();
            hash = hash + obj.verified.GetHashCode();
            hash = hash + obj.admin.GetHashCode();
            return hash;
        }
    }
    
    public class AdminManageUserTests
    {
        [Fact]
        public void GetAllUsersTest()
        {
            // Arrange
            var repositoryStub = new Mock<IUserRepo>();
            var userRepo = new MockUserRepo();
            repositoryStub.Setup(repo => repo.GetUsers()).Returns(userRepo.GetUsers());
            var controller = new AdminManageUserController(userRepo);
            // Act
            var result = controller.GetAllUsers().Result as OkObjectResult;
            var areEqual = Enumerable.SequenceEqual(repositoryStub.Object.GetUsers(), (IEnumerable<User>)result.Value, new UserComparer());
            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void DeleteUserTest()
        {
            // Arrange
            var repositoryStub = new Mock<IUserRepo>();
            var userRepo = new MockUserRepo();
            var users = (List<User>)userRepo.GetUsers();
            users.RemoveAt(users.FindIndex(u => u.id == 1));
            repositoryStub.Setup(repo => repo.GetUsers()).Returns(users);
            var controller = new AdminManageUserController(userRepo);
            // Act
            var result = controller.RemoveUser(1).Result as OkObjectResult;
            var areEqual = Enumerable.SequenceEqual(repositoryStub.Object.GetUsers(), (IEnumerable<User>)result.Value, new UserComparer());
            // Assert
            Assert.True(areEqual);
        }
    }
}