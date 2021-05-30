using System;
using Xunit;
using Moq;
using Back_end.Controllers;
using Back_end.Data;
using Back_end.DatabaseModels;
using Back_end.Dtos;
using Back_end.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FluentAssertions;

namespace Back_end.UnitTests
{
    public class UserControllerTest
    {

        [Fact]
        public void createUser_Test()
        {
            // Arrange
            var repoMock = new Mock<IUserRepo>();
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
            var user = new User
            {
                Id = 1,
                Name = "test1",
                Surname = "test1",
                Email = "test1",
                Verified = false,
                Admin = false
            };
            repoMock.Setup(p => p.CreateUser(1, "test1", "test1", "test1", false, false)).Returns(returnedList);
            var service = new UserServices(repoMock.Object);
            var ctl = new UserController(service);

            // Act
            var result = ctl.createUser(user).Result as OkObjectResult;

            // Assert
            result.Value.Should().BeEquivalentTo(returnedList, options => options.ComparingByMembers<UserDto>());
        }

        [Fact]
        public void createUser_Test_NULLATTRIBUTES()
        {
            // Arrange
            var repoMock = new Mock<IUserRepo>();
            var returnedList = new List<UserDto>{
                new UserDto
                {
                    id = 1,
                    name = "",
                    surname = "",
                    email = "",
                    verified = false,
                    admin = false
                }
            };
            var user = new User
            {
                Id = 1,
                Name = "",
                Surname = "",
                Email = "",
                Verified = false,
                Admin = false
            };
            repoMock.Setup(p => p.CreateUser(1, "", "", "", false, false)).Returns(returnedList);
            var service = new UserServices(repoMock.Object);
            var ctl = new UserController(service);

            // Act
            var result = ctl.createUser(user).Result as OkObjectResult;

            // Assert
            result.Value.Should().BeEquivalentTo(returnedList, options => options.ComparingByMembers<UserDto>());
        }

        [Fact]
        public void removeUser_Test()
        {
            //Arrange
            var repoMock = new Mock<IUserRepo>();
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
            repoMock.Setup(p => p.RemoveUserById(2)).Returns(returnedList);
            var service = new UserServices(repoMock.Object);
            var ctl = new UserController(service);

            // Act
            var result = ctl.removeUser(2).Result as OkObjectResult;

            // Assert
            result.Value.Should().BeEquivalentTo(returnedList, options => options.ComparingByMembers<UserDto>());
        }


        [Fact]
        public void updateUser_Test()
        {
            // Arrange
            var repoMock = new Mock<IUserRepo>();
            var userDTO = new UserDto
            {
                id = 1,
                name = "test1",
                surname = "test1",
                email = "test1",
                verified = false,
                admin = false
            };
            var user = new User
            {
                Id = 1,
                Name = "test1",
                Surname = "test1",
                Email = "test1",
                Verified = false,
                Admin = false
            };
            repoMock.Setup(p => p.UpdateUserById(1, "test1", "test1", "test1", false, false)).Returns(userDTO);
            var service = new UserServices(repoMock.Object);
            var ctl = new UserController(service);

            // Act
            var result = ctl.updateUser(user).Result as OkObjectResult;

            // Assert
            result.Value.Should().BeEquivalentTo(userDTO, options => options.ComparingByMembers<UserDto>());
        }

        [Fact]
        public void updateUser_Test_NULLATRIBUTES()
        {
            // Arrange
            var repoMock = new Mock<IUserRepo>();
            var userDTO = new UserDto
            {
                id = 1,
                name = "",
                surname = "",
                email = "",
                verified = false,
                admin = false
            };
            var user = new User
            {
                Id = 1,
                Name = "",
                Surname = "",
                Email = "",
                Verified = false,
                Admin = false
            };
            repoMock.Setup(p => p.UpdateUserById(1, "", "", "", false, false)).Returns(userDTO);
            var service = new UserServices(repoMock.Object);
            var ctl = new UserController(service);

            // Act
            var result = ctl.updateUser(user).Result as OkObjectResult;

            // Assert
            result.Value.Should().BeEquivalentTo(userDTO, options => options.ComparingByMembers<UserDto>());
        }

        [Fact]
        public void getUser_Test()
        {
            // Arrange
            var repoMock = new Mock<IUserRepo>();
            var user = new UserDto
            {
                id = 1,
                name = "test1",
                surname = "test1",
                email = "test1",
                verified = false,
                admin = false
            };
            repoMock.Setup(p => p.GetUserById(1)).Returns(user);
            var service = new UserServices(repoMock.Object);
            var ctl = new UserController(service);

            // Act
            var result = ctl.getUser(1).Result as OkObjectResult;

            // Assert
            result.Value.Should().BeEquivalentTo(user, options => options.ComparingByMembers<UserDto>());
        }


        [Fact]
        public void GetAllUsers_Test()
        {
            // Arrange
            var repoMock = new Mock<IUserRepo>();
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
            repoMock.Setup(p => p.GetUsers()).Returns(returnedList);
            var service = new UserServices(repoMock.Object);
            var ctl = new UserController(service);

            // Act
            var result = ctl.GetAllUsers().Result as OkObjectResult;

            // Assert
            result.Value.Should().BeEquivalentTo(returnedList, options => options.ComparingByMembers<UserDto>());
        }
    }
}