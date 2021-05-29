using System;
using Xunit;
using Moq;
using Back_end.Controllers;
using Back_end.Data;
using Back_end.DatabaseModels;
using Back_end.Dtos;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FluentAssertions;
using Back_end.Services;

namespace Back_end.UnitTests
{
    
    public class AdminManageUserTests
    {
        [Fact]
        public void GetAllUsersTest()
        {
            // Arrange
            var repoMock = new Mock<IUserRepo>();
            var userList = new List<User>{
                new User
                {
                    Id = 1,
                    Name = "test1",
                    Surname = "test1",
                    Email = "test1",
                    Verified = false,
                    Admin = false
                },
            };
            var returnedList = new List<UserDto>{
                new UserDto
                {
                    id = 1,
                    name = "test1",
                    surname = "test1",
                    email = "test1",
                    verified = false,
                    admin = false
                }
            };
            repoMock.Setup(p => p.GetUsers()).Returns(userList);
            var service = new AdminManageUserServices(repoMock.Object);
            var ctl = new AdminManageUserController(service);

            // Act
            var result = ctl.GetAllUsers().Result as OkObjectResult;
            
            // Assert
            result.Value.Should().BeEquivalentTo(returnedList, options => options.ComparingByMembers<UserDto>());
        }

        [Fact]
        public void GetUserByIdTest()
        {
             // Arrange
            var repoMock = new Mock<IUserRepo>();
            var user = new User
            {
                Id = 1,
                Name = "test1",
                Surname = "test1",
                Email = "test1",
                Verified = false,
                Admin = false
            };
            var after = new UserDto
            {
                id = 1,
                name = "test1",
                surname = "test1",
                email = "test1",
                verified = false,
                admin = false
            };
            repoMock.Setup(p => p.GetUserById(1)).Returns(user);
            var service = new AdminManageUserServices(repoMock.Object);
            var ctl = new AdminManageUserController(service);

            // Act
            var result = ctl.getUser(1).Result as OkObjectResult;
            
            // Assert
            result.Value.Should().BeEquivalentTo(after, options => options.ComparingByMembers<UserDto>());
        }
        

        [Fact]
        public void DeleteUserTest()
        {
             //Arrange
            var repoMock = new Mock<IUserRepo>();
            var userList = new List<User>{
                new User
                {
                    Id = 1,
                    Name = "test1",
                    Surname = "test1",
                    Email = "test1",
                    Verified = false,
                    Admin = false
                },
            };
            var returnedList = new List<UserDto>{
                new UserDto
                {
                    id = 1,
                    name = "test1",
                    surname = "test1",
                    email = "test1",
                    verified = false,
                    admin = false
                }
            };
            repoMock.Setup(p => p.RemoveUserById(2)).Returns(userList);
            var service = new AdminManageUserServices(repoMock.Object);
            var ctl = new AdminManageUserController(service);

            // Act
            var result = ctl.removeUser(2).Result as OkObjectResult;
            
            // Assert
            result.Value.Should().BeEquivalentTo(returnedList, options => options.ComparingByMembers<UserDto>());
        }

        [Fact]
         public void UpdateUserTest()
         {
            // Arrange
            var repoMock = new Mock<IUserRepo>();
            var user = new User
            {
                Id = 1,
                Name = "test1",
                Surname = "test1",
                Email = "test1",
                Verified = false,
                Admin = false
            };
            var after = new Back_end.Models.User
            {
                id = 1,
                name = "test1",
                surname = "test1",
                email = "test1",
                verified = false,
                admin = false
            };
            repoMock.Setup(p => p.UpdateUserById(1, "test1", "test1", "test1", false, false)).Returns(user);
            var service = new AdminManageUserServices(repoMock.Object);
            var ctl = new AdminManageUserController(service);

            // Act
            var result = ctl.updateUser(after).Result as OkObjectResult;
            
            // Assert
            result.Value.Should().BeEquivalentTo(after, options => options.ComparingByMembers<UserDto>());

         }
    }
}