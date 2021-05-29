using System;
using Xunit;
using Moq;
using Back_end.Controllers;
using Back_end.Data;
using Back_end.Dtos;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FluentAssertions;

namespace Back_end.UnitTests
{
    public class UserControllerTest
    {

        // [Fact]
        // public void createUser_Test()
        // {
        //     //Arrange
        //     var repositoryStub = new Mock<IUserRepo>();
        //     var mockUserRepo = new MockUserRepo();
        //     repositoryStub.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());
        //     var mockUserRepo2 = new MockUserRepo();
        //     var controller = new UserController(mockUserRepo);
        //     var tmpUser = new User
        //     {
        //         id = 10,
        //         name = "testName",
        //         surname = "testSurname",
        //         email = "testEmail",
        //         verified = true,
        //         admin = false
        //     };

        //     //Act
        //     var result = controller.createUser(tmpUser).Result as OkObjectResult;
        //     var tmp = mockUserRepo2.CreateUser(tmpUser.id,
        //                                        tmpUser.name,
        //                                        tmpUser.surname,
        //                                        tmpUser.email,
        //                                        tmpUser.verified,
        //                                        tmpUser.admin).Select(x => x.AsDto());
            
        //     //Assert
        //     result.Value.Should().BeEquivalentTo(tmp, options => options.ComparingByMembers<UserDto>());
        // }

        // [Fact]
        // public void createUser_Test_NULLATTRIBUTES()
        // {
        //     //Arrange
        //     var repositoryStub = new Mock<IUserRepo>();
        //     var mockUserRepo = new MockUserRepo();
        //     repositoryStub.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());
        //     var mockUserRepo2 = new MockUserRepo();
        //     var controller = new UserController(mockUserRepo);
        //     var tmpUser = new User
        //     {
        //         id = 11,
        //         name = "",
        //         surname = "",
        //         email = "",
        //         verified = true,
        //         admin = false
        //     };

        //     //Act
        //     var result = controller.createUser(tmpUser).Result as OkObjectResult;
        //     var tmp = mockUserRepo2.CreateUser(tmpUser.id,
        //                                        tmpUser.name,
        //                                        tmpUser.surname,
        //                                        tmpUser.email,
        //                                        tmpUser.verified,
        //                                        tmpUser.admin).Select(x => x.AsDto());

        //     //Assert
        //     result.Value.Should().BeEquivalentTo(tmp, options => options.ComparingByMembers<UserDto>());
        // }

        // [Fact]
        // public void removeUser_Test()
        // {
        //     //Arrange
        //     var repositoryStub = new Mock<IUserRepo>();
        //     var mockUserRepo = new MockUserRepo();
        //     repositoryStub.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());
        //     var mockUserRepo2 = new MockUserRepo();
        //     var controller = new UserController(mockUserRepo);

        //     //Act
        //     var result = controller.removeUser(1).Result as OkObjectResult;
        //     var tmp = mockUserRepo2.RemoveUserById(1).Select(x => x.AsDto());

        //     //Assert
        //     result.Value.Should().BeEquivalentTo(tmp, options => options.ComparingByMembers<UserDto>());
        // }


        // [Fact]
        // public void updateUser_Test()
        // {
        //     // Arrange
        //     var repositoryStub = new Mock<IUserRepo>();
        //     var mockUserRepo = new MockUserRepo();
        //     repositoryStub.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());
        //     var controller = new UserController(mockUserRepo);
        //     var tmp = new User
        //     {
        //         id = 1,
        //         name = "testName",
        //         surname = "testSurname",
        //         email = "testEmail",
        //         verified = true,
        //         admin = false
        //     };

        //     // Act
        //     var result = controller.updateUser(tmp).Result as OkObjectResult;
        //     var tmpR = mockUserRepo.UpdateUserById(tmp.id,
        //                                            tmp.name,
        //                                            tmp.surname,
        //                                            tmp.email,
        //                                            tmp.verified,
        //                                            tmp.admin);

        //     // Assert
        //     result.Value.Should().BeEquivalentTo(tmpR, options => options.ComparingByMembers<User>());
        // }

        // [Fact]
        // public void updateUser_Test_NULLATRIBUTES()
        // {
        //     // Arrange
        //     var repositoryStub = new Mock<IUserRepo>();
        //     var mockUserRepo = new MockUserRepo();
        //     repositoryStub.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());
        //     var controller = new UserController(mockUserRepo);
        //     var tmp = new User
        //     {
        //         id = 1,
        //         name = "",
        //         surname = "",
        //         email = "",
        //         verified = true,
        //         admin = false
        //     };

        //     // Act
        //     var result = controller.updateUser(tmp).Result as OkObjectResult;
        //     var tmpR = mockUserRepo.UpdateUserById(tmp.id,
        //                                            tmp.name,
        //                                            tmp.surname,
        //                                            tmp.email,
        //                                            tmp.verified,
        //                                            tmp.admin);

        //     // Assert
        //     result.Value.Should().BeEquivalentTo(tmpR, options => options.ComparingByMembers<User>());
        // }

        // [Fact]
        // public void getUser_Test()
        // {
        //     // Arrange
        //     var repositoryStub = new Mock<IUserRepo>();
        //     var mockUserRepo = new MockUserRepo();
        //     repositoryStub.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());
        //     var controller = new UserController(mockUserRepo);

        //     // Act
        //     var result = controller.getUser(1).Result as OkObjectResult;
        //     var tmpR = mockUserRepo.GetUserById(1);

        //     // Assert
        //     result.Value.Should().BeEquivalentTo(tmpR, options => options.ComparingByMembers<User>());
        // }


        // [Fact]
        // public void GetAllUsers_Test()
        // {
        //     //Arrange
        //     var repositoryStub = new Mock<IUserRepo>();
        //     var mockUserRepo = new MockUserRepo();
        //     repositoryStub.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());
        //     var controller = new UserController(mockUserRepo);

        //     //Act
        //     var result = controller.GetAllUsers().Result as OkObjectResult;
        //     var tmp = mockUserRepo.GetUsers().Select(x => x.AsDto());
            
        //     //Assert
        //     result.Value.Should().BeEquivalentTo(tmp, options => options.ComparingByMembers<UserDto>());
        // }
    }
}