using Xunit;
using Back_end.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.UnitTests
{
    public class SessionControllerTest
    {
        [Fact]
        public void CreateSession_Test_EmailIsInDatabase()
        {
            //Arrange
            var key = "this is a string used for encrypt and decrypt token";
            var mockJwtAuthenticationManager = new JwtAuthenticationManager(key);
            var controller = new SessionController(mockJwtAuthenticationManager);
            SessionCredentials scTemp = new SessionCredentials();
            scTemp.Email = "james@gg.com";

            //Act
            var token = controller.CreateSession(scTemp) as OkObjectResult;

            //Assert
            Assert.True(token == null ? false : true);
        }

        [Fact]
        public void CreateSession_Test_EmailIsNotInDatabase()
        {
            //Arrange
            var key = "this is a string used for encrypt and decrypt token";
            var mockJwtAuthenticationManager = new JwtAuthenticationManager(key);
            var controller = new SessionController(mockJwtAuthenticationManager);
            SessionCredentials scTemp = new SessionCredentials();
            scTemp.Email = "";

            //Act
            var token = controller.CreateSession(scTemp) as OkObjectResult;

            //Assert
            Assert.True(token == null ? true : false);
        }
    }
}