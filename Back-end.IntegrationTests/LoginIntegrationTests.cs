using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Net;
using Back_end.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using Back_end.Dtos;
using Back_end.IntegrationTests.GroupHModels;

namespace Back_end.IntegrationTests
{
    public class LoginIntegrationTests : IntegrationTest
    {
        // [Fact]
        // public async Task RegisterUserAsync_RegistersUser()
        // {
        //     //I could delete the user I created on previous run but they are not allowing an endpoint to delete users
        //     var response = await TestClient.PostAsJsonAsync("api/signup", new GroupHModels.User{
        //         Admin = false,
        //         Email = "groupf@gamil.com",
        //         Name = "wearegroupf",
        //         Password = "123123",
        //         Surname = "Wearegroupf",
        //         Verified = false,
        //         Login = "GROUPF"
        //     });
        //     response.StatusCode.Should().Be(HttpStatusCode.Created);
        // }

        // [Fact]
        // public async Task LoginWithValidCred_ReturnAuthorized()
        // {
        //         var response =await TestClient.PostAsJsonAsync("api/login", new LoginForm{
        //         Username = "GROUPF",
        //         Password = "123123"
        //     });

        //         response.StatusCode.Should().Be(HttpStatusCode.OK);
        // }
        
    }
}