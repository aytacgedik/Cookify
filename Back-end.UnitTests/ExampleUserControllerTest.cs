using System;
using Xunit;
using Moq;
using Back_end.Controllers;
using Back_end.Data;
using Back_end.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.UnitTests
{
    public class ExampleUserControllerTest
    {
        //aytac
        //UnitOfWork_StateUnderTest_ExpectedBehavior() 

        //Start with not existing item unlike example
        [Fact]
        public void GetAllUsers_WithUnexisting_ReturnsNotFound()
        {
            // Arrange
            var repositoryStub=new Mock<IUserRepo>();

            repositoryStub.Setup(repo => repo.GetUsers()).Returns((IEnumerable<User>)null);

            var controller = new ExampleUserController(repositoryStub.Object);

            // Act
            var result = controller.GetAllUsers();

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);

        }
    }
}
