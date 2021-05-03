using System;
using Xunit;
using Moq;
using Back_end.Controllers;
using Back_end.Data;
using Back_end.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FluentAssertions;
using Back_end.Dtos;

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
            //Arrange
            var repositoryStub = new Mock<IUserRepo>();
            var mockUserRepo = new MockUserRepo();
            repositoryStub.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());
            var mockUserRepo2 = new MockUserRepo();
            var controller = new AdminManageUserController(mockUserRepo);

            //Act
            var result = controller.RemoveUser(1).Result as OkObjectResult;
            var tmp = mockUserRepo2.RemoveUserById(1).Select(x => x.AsDto());

            //Assert
            result.Value.Should().BeEquivalentTo(tmp, options => options.ComparingByMembers<UserDto>());
        }

        [Fact]
        public void UpdateUserTest()
        {
            // Arrange
            User user = new User();
            user.id = 1;
            user.name = "test";
            user.surname = "test";
            user.email = "test";
            user.verified = true;
            user.admin = true;
            var repositoryStub = new Mock<IUserRepo>();
            var userRepo = new MockUserRepo();
            repositoryStub.Setup(repo => repo.GetUserById(1)).Returns(user);
            var controller = new AdminManageUserController(userRepo);
            // Act
            var result = controller.updateUser(user).Result as OkObjectResult;
            var comparer = new UserComparer();
            bool areEqual = comparer.Equals(repositoryStub.Object.GetUserById(1), (User)result.Value);
            // Assert
            Assert.True(areEqual);

        }
    }
}