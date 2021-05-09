using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using Back_end.Models;
using Back_end.Data;
using Back_end.Dtos;

namespace Back_end.IntegrationTests
{
    public class UserFriendControllerTests : IntegrationTest
    {
        [Fact]
        public async Task createUserFriend_ReturnsOK()
        {
            await AuthenticateAsync();
            var response = await TestClient.PostAsJsonAsync("api/user_friends/", new UserFriend
            {
                userFollowedId = 3,
                userFollowerId = 5
            });
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task removeUser_ReturnOK()
        {
            await AuthenticateAsync();
            var response = await TestClient.DeleteAsync("api/user_friends/?userFollowerId=1&userFollowedId=3");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}