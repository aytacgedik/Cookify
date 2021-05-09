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
            var tmpList = userRepo.GetUsers().Select(x => x.AsDto()).ToList();
            // Assert
            result.Value.Should().BeEquivalentTo(tmpList, opt => opt.ComparingByMembers<UserDto>());
            //Assert.True(areEqual);
        }

        [Fact]
        public void DeleteUserTest()
        {
            // Arrange
            var repositoryStub = new Mock<IUserRepo>();
            var userRepo = new MockUserRepo();
            repositoryStub.Setup(repo => repo.GetUsers()).Returns(userRepo.GetUsers());
            var controller = new AdminManageUserController(userRepo);
            var users = (List<User>)userRepo.GetUsers();
            users.RemoveAt(users.FindIndex(u => u.id == 1));
            var tmpList = users.Select(x => x.AsDto()).ToList();
            
            // Act
            var result = controller.RemoveUser(1).Result as OkObjectResult;
            var areEqual = Enumerable.SequenceEqual(tmpList, (IEnumerable<UserDto>)result.Value, new UserDtoComparer());
            
            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void UpdateUserTest()
        {
            // Arrange
            var tmpUser = new User
            {
                id = 1,
                name = "test",
                surname = "test",
                email = "test",
                verified = true,
                admin = false
            };
            var repositoryStub = new Mock<IUserRepo>();
            var userRepo = new MockUserRepo();
            repositoryStub.Setup(repo => repo.GetUsers()).Returns(userRepo.GetUsers());
            var controller = new AdminManageUserController(userRepo);
            // Act
            var result = controller.updateUser(tmpUser).Result as OkObjectResult;
            var tmpR = userRepo.UpdateUserById(tmpUser.id, tmpUser.name, tmpUser.surname, tmpUser.email, tmpUser.verified, tmpUser.admin);
            // Assert
            result.Value.Should().BeEquivalentTo(tmpR, options => options.ComparingByMembers<User>());

        }
    }
}