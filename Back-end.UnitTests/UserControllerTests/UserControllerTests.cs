using System;
using Xunit;
using Moq;
using Back_end.Controllers;
using Back_end.Data;
using Back_end.Models;
using Back_end.Dtos;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FluentAssertions;

namespace Back_end.UnitTests
{
    public class UserDtoComparer : IEqualityComparer<UserDto>
    {
        public bool Equals(UserDto x, UserDto y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            bool equals = (x.id == y.id &&
                           x.name == y.name &&
                           x.surname == y.surname &&
                           x.email == y.email &&
                           x.verified == y.verified &&
                           x.admin == y.admin);

            return equals;
        }

        public int GetHashCode(UserDto obj)
        {
            if (obj == null)
            {
                return int.MinValue;
            }
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

    public class UserControllerTest
    {

        [Fact]
        public void createUser_Test()
        {
            // Arrange
            var repositoryStub = new Mock<IUserRepo>();
            var mockUserRepo = new MockUserRepo();
            repositoryStub.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());
            var controller = new UserController(mockUserRepo);
            var tmp = new User
            {
                id = 10,
                name = "testName",
                surname = "testSurname",
                email = "testEmail",
                verified = true,
                admin = false
            };

            // Act
            var result = controller.createUser(tmp).Result as OkObjectResult;
            var tmpList = mockUserRepo.CreateUser(tmp.id,
                                                  tmp.name,
                                                  tmp.surname,
                                                  tmp.email,
                                                  tmp.verified,
                                                  tmp.admin).Select(x => x.AsDto()).ToList();
            var areEqual = Enumerable.SequenceEqual(tmpList,
                                                    (IEnumerable<UserDto>)result.Value,
                                                    new UserDtoComparer());

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void removeUser_Test()
        {
            // Arrange
            var repositoryStub = new Mock<IUserRepo>();
            var mockUserRepo = new MockUserRepo();
            repositoryStub.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());
            var controller = new UserController(mockUserRepo);

            // Act
            var result = controller.removeUser(1).Result as OkObjectResult;
            var tmpList = mockUserRepo.RemoveUserById(1).Select(x => x.AsDto()).ToList();
            var areEqual = Enumerable.SequenceEqual(tmpList,
                                                    (IEnumerable<UserDto>)result.Value,
                                                    new UserDtoComparer());

            // Assert
            Assert.True(areEqual);
        }


        [Fact]
        public void updateUser_Test()
        {
            // Arrange
            var repositoryStub = new Mock<IUserRepo>();
            var mockUserRepo = new MockUserRepo();
            repositoryStub.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());
            var controller = new UserController(mockUserRepo);
            var tmp = new User
            {
                id = 1,
                name = "testName",
                surname = "testSurname",
                email = "testEmail",
                verified = true,
                admin = false
            };

            // Act
            var result = controller.updateUser(tmp).Result as OkObjectResult;
            var tmpR = mockUserRepo.UpdateUserById(tmp.id,
                                                   tmp.name,
                                                   tmp.surname,
                                                   tmp.email,
                                                   tmp.verified,
                                                   tmp.admin);

            // Assert
            result.Value.Should().BeEquivalentTo(tmpR, options => options.ComparingByMembers<User>());
        }

        [Fact]
        public void getUser_Test()
        {
            // Arrange
            var repositoryStub = new Mock<IUserRepo>();
            var mockUserRepo = new MockUserRepo();
            repositoryStub.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());
            var controller = new UserController(mockUserRepo);

            // Act
            var result = controller.getUser(1).Result as OkObjectResult;
            var tmpR = mockUserRepo.GetUserById(1);

            // Assert
            result.Value.Should().BeEquivalentTo(tmpR, options => options.ComparingByMembers<User>());
        }


        [Fact]
        public void GetAllUsers_Test()
        {
            // Arrange
            var repositoryStub = new Mock<IUserRepo>();
            var mockUserRepo = new MockUserRepo();
            repositoryStub.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());
            var controller = new UserController(mockUserRepo);

            // Act
            var result = controller.GetAllUsers().Result as OkObjectResult;
            var tmpList = mockUserRepo.GetUsers().Select(x => x.AsDto()).ToList();
            var areEqual = Enumerable.SequenceEqual(tmpList,
                                                    (IEnumerable<UserDto>)result.Value,
                                                    new UserDtoComparer());

            // Assert
            Assert.True(areEqual);
        }
    }
}