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
            var service = new AdminManageUserServices(repoMock.Object);
            var ctl = new AdminManageUserController(service);

            // Act
            var result = ctl.getUser(1).Result as OkObjectResult;
            
            // Assert
            result.Value.Should().BeEquivalentTo(user, options => options.ComparingByMembers<UserDto>());
        }
        

        [Fact]
        public void DeleteUserTest()
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
            var userDTO = new UserDto
            {
                id = 1,
                name = "test1",
                surname = "test1",
                email = "test1",
                verified = false,
                admin = false
            };
            var inputDTO = new UserInputDto
            {
                name = "test1",
                surname = "test1",
                email = "test1",
                verified = false,
                admin = false
            };
            repoMock.Setup(p => p.UpdateUserById(1, inputDTO)).Returns(userDTO);
            var service = new AdminManageUserServices(repoMock.Object);
            var ctl = new AdminManageUserController(service);

            // Act
            var result = ctl.updateUser(1,inputDTO).Result as OkObjectResult;
            
            // Assert
            result.Value.Should().BeEquivalentTo(userDTO, options => options.ComparingByMembers<UserDto>());

         }
    }
}