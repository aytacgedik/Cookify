using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using Back_end.Data;
using Back_end.Dtos;

namespace Back_end.IntegrationTests
{
    public class UserControllerTests : IntegrationTest
    {
        // [Fact]
        // public async Task createUser_ReturnsOK()
        // {
        //     await AuthenticateAsync();
        //     var response = await TestClient.PostAsJsonAsync("api/users/", new User
        //     {
        //         id = 9,
        //         name = "Atik",
        //         surname = "Ali",
        //         email = "atikali@gmail.com",
        //         verified = true,
        //         admin = false
        //     });
        //     response.StatusCode.Should().Be(HttpStatusCode.OK);
        // }

        // [Fact]
        // public async Task updateUser_ReturnOK()
        // {
        //     await AuthenticateAsync();
        //     var response = await TestClient.PatchAsync("api/users/1",
        //                                                JsonContent.Create<User>(new User
        //                                                {
        //                                                    id = 1,
        //                                                    name = "CHANGEDATTRIBUTE_NAME",
        //                                                    surname = "CHANGEDATTRIBUTE_SURNAME",
        //                                                    email = "james@gg.com",
        //                                                    verified = true,
        //                                                    admin = false
        //                                                }));

        //     response.StatusCode.Should().Be(HttpStatusCode.OK);
        // }

        // [Fact]
        // public async Task removeUser_ReturnOK()
        // {
        //     await AuthenticateAsync();
        //     var response = await TestClient.DeleteAsync("api/users/1");
        //     response.StatusCode.Should().Be(HttpStatusCode.OK);
        // }

        // [Fact]
        // public async Task GetUsers_WithoutId_ReturnsOK()
        // {
        //     //Arrange
        //     var mockRecipeRepo = new MockRecipeRepo();
        //     await AuthenticateAsync();

        //     //Act
        //     var response = await TestClient.GetAsync("api/users");

        //     //Assert
        //     response.StatusCode.Should().Be(HttpStatusCode.OK);
        // }

        // [Fact]
        // public async Task GetUser_WithId_ReturnsOK()
        // {
        //     await AuthenticateAsync();
        //     var response = await TestClient.GetAsync("api/users/1");
        //     response.StatusCode.Should().Be(HttpStatusCode.OK);
        // }
    }
}