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
        private readonly IUserService _sut;
        
        private readonly Mock<IUserRepo> _userRepoMock = new Mock<IUserRepo>();
        private readonly Mock<ISavedRecipeRepo> savedRecipeRepo = new Mock<ISavedRecipeRepo>();
        private readonly Mock<IIngredientRepo> ingredientRepo = new Mock<IIngredientRepo>();

        public UserControllerTest()
        {
            _sut = new UserServices(_userRepoMock.Object,new SavedRecipeService(savedRecipeRepo.Object),new IngredientServices(ingredientRepo.Object));
        }


        [Fact]
        public void createUser_Test()
        {
            // Arrange
            var userinthelist  =new UserDto
                {
                    id = 1,
                    name = "test1",
                    surname = "test1",
                    email = "test1",
                    verified = false,
                    admin = false
                };
            var returnedList = new List<UserDto>{
                userinthelist
            };
            var user = new UserInputDto
            {
                name = "test1",
                surname = "test1",
                email = "test1",
                verified = false,
                admin = false
            };
            _userRepoMock.Setup(p => p.CreateUser(user)).Returns(returnedList);
            _userRepoMock.Setup(p => p.GetUserById(1)).Returns(userinthelist);
            _userRepoMock.Setup(p => p.GetUsers()).Returns(returnedList);


            // Act
            var result = _sut.ServiceCreateUser(user);

            // Assert
            result.Should().BeEquivalentTo(returnedList, options => options.ComparingByMembers<UserDto>());
        }

        // [Fact]
        // public void createUser_Test_NULLATTRIBUTES()
        // {
        //     // Arrange
        //     var repoMock = new Mock<IUserRepo>();
        //     var repoMock1 = new Mock<ISavedRecipeService>();
        //     var repoMock2 = new Mock<IIngredientService>();
        //     var returnedList = new List<UserDto>{
        //         new UserDto
        //         {
        //             id = 1,
        //             name = "",
        //             surname = "",
        //             email = "",
        //             verified = false,
        //             admin = false
        //         }
        //     };
        //     var user = new UserInputDto
        //     {
        //         name = "",
        //         surname = "",
        //         email = "",
        //         verified = false,
        //         admin = false
        //     };
        //     repoMock.Setup(p => p.CreateUser(user)).Returns(returnedList);
        //     var service = new UserServices(repoMock.Object,repoMock1.Object,repoMock2.Object);
        //     var ctl = new UserController(service);

        //     // Act
        //     var result = ctl.createUser(user).Result as OkObjectResult;

        //     // Assert
        //     result.Value.Should().BeEquivalentTo(returnedList, options => options.ComparingByMembers<UserDto>());
        // }

        [Fact]
        public void removeUser_Test()
        {
            //Arrange
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
            _userRepoMock.Setup(p => p.RemoveUserById(2)).Returns(returnedList);

            // Act
            var result = _sut.ServiceRemoveUserById(2);

            // Assert
            result.Should().BeEquivalentTo(returnedList, options => options.ComparingByMembers<UserDto>());
        }


        [Fact]
        public void updateUser_Test()
        {
            // Arrange
            var userDTO = new UserDto
            {
                id = 1,
                name = "test1",
                surname = "test1",
                email = "test1",
                verified = false,
                admin = false
            };
            var user = new UserInputDto
            {
                name = "test1",
                surname = "test1",
                email = "test1",
                verified = false,
                admin = false
            };
            _userRepoMock.Setup(p => p.UpdateUserById(1,user)).Returns(userDTO);
            _userRepoMock.Setup(p => p.GetUserById(1)).Returns(userDTO);

            

            // Act
            var result = _sut.ServiceUpdateUserById(1,user);

            // Assert
            result.Should().BeEquivalentTo(userDTO, options => options.ComparingByMembers<UserDto>());
        }

        // [Fact]
        // public void updateUser_Test_NULLATRIBUTES()
        // {
        //     // Arrange
        //     var repoMock = new Mock<IUserRepo>();
        //     var repoMock1 = new Mock<ISavedRecipeService>();
        //     var repoMock2 = new Mock<IIngredientService>();
        //     var userDTO = new UserDto
        //     {
        //         id = 1,
        //         name = "",
        //         surname = "",
        //         email = "",
        //         verified = false,
        //         admin = false
        //     };
        //     var user = new UserInputDto
        //     {
        //         name = "",
        //         surname = "",
        //         email = "",
        //         verified = false,
        //         admin = false
        //     };
        //     repoMock.Setup(p => p.UpdateUserById(1, user)).Returns(userDTO);
        //     var service = new UserServices(repoMock.Object,repoMock1.Object,repoMock2.Object);
        //     var ctl = new UserController(service);

        //     // Act
        //     var result = ctl.updateUser(1,user).Result as OkObjectResult;

        //     // Assert
        //     result.Value.Should().BeEquivalentTo(userDTO, options => options.ComparingByMembers<UserDto>());
        // }

        [Fact]
        public void getUser_Test()
        {
            // Arrange
            var user = new UserDto
            {
                id = 1,
                name = "test1",
                surname = "test1",
                email = "test1",
                verified = false,
                admin = false
            };
            _userRepoMock.Setup(p => p.GetUserById(1)).Returns(user);

            // Act
            var result = _sut.ServiceGetUserById(1);

            // Assert
            result.Should().BeEquivalentTo(user, options => options.ComparingByMembers<UserDto>());
        }


        [Fact]
        public void GetAllUsers_Test()
        {
            // Arrange
            var userinthelist =                 new UserDto
                {
                    id = 1,
                    name = "test1",
                    surname = "test1",
                    email = "test1",
                    verified = false,
                    admin = false
                };
            var returnedList = new List<UserDto>{
                userinthelist
            };
            _userRepoMock.Setup(p => p.GetUsers()).Returns(returnedList);
            _userRepoMock.Setup(p => p.GetUserById(1)).Returns(userinthelist);
           
            // Act
            var result = _sut.ServiceGetUsers();

            // Assert
            result.Should().BeEquivalentTo(returnedList, options => options.ComparingByMembers<UserDto>());
        }
    }
}