using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Back_end.Data;
using FluentAssertions;
using Xunit;

namespace Back_end.IntegrationTests
{
    //KEPT COMMENTED SINCE GROUP H DOESN'T HAVE ENDPOINTS FOR ADMIN CONTROLLERS

    public class AdminIntegrationTests : IntegrationTest
    {
        // [Fact]
        // public async Task Get_WithoutId_ReturnsOK()
        // {
        //     //Arrange
        //     //var mockRecipeRepo = new  MockRecipeRepo();
        //     await AuthenticateAsync();
        //     //Act
        //     var response = await TestClient.GetAsync("admin/recipe");
        //     //Assert
        //     response.StatusCode.Should().Be(HttpStatusCode.OK);
        //     //response.Content.ReadFromJsonAsync<Recipe>().Should().BeNull();
        // }

        // [Fact]
        // public async Task Get_WithId_ReturnsOK()
        // {
        //     await AuthenticateAsync();
        //     var response = await TestClient.GetAsync("admin/recipe/1");
        //     response.StatusCode.Should().Be(HttpStatusCode.OK);
        // }


        // [Fact]
        // public async Task updateRecipe_ReturnsOK()
        // {
        //     await AuthenticateAsync();
        //     var response = await TestClient.PatchAsync("admin/recipe/2",JsonContent.Create<Recipe>(new Recipe{id=2,
        //                 creatorId=2,
        //                 name="Imam bayildi",
        //                 description="Eggplants stuffed with minced meat",
        //                 rating=10.0F,
        //                 tag="Turkish Cuisine"
        //                 }));

        //     //var responseResult = await response.Content.ReadAsStringAsync();
        //     response.StatusCode.Should().Be(HttpStatusCode.OK);
        // }

        // [Fact]
        // public async Task removeRecipe_ReturnOK()
        // {
        //     await AuthenticateAsync();
        //     var response = await TestClient.DeleteAsync("admin/recipe/1");
        //     response.StatusCode.Should().Be(HttpStatusCode.OK);

        // }


        // [Fact]
        // public async Task removeRecipe_ReturnNotFound()
        // {
        //     await AuthenticateAsync();
        //     //non-existing id
        //     var response = await TestClient.DeleteAsync("admin/recipe/10");
        //     response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        // }



        // [Fact]
        // public async Task updateUser_ReturnOK()
        // {
        //     await AuthenticateAsync();
        //     var response = await TestClient.PatchAsync("admin/user/1",
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
        //     var response = await TestClient.DeleteAsync("admin/user/1");
        //     response.StatusCode.Should().Be(HttpStatusCode.OK);
        // }

        // [Fact]
        // public async Task GetUsers_WithoutId_ReturnsOK()
        // {
        //     //Arrange
        //     var mockRecipeRepo = new MockRecipeRepo();
        //     await AuthenticateAsync();

        //     //Act
        //     var response = await TestClient.GetAsync("admin/user");

        //     //Assert
        //     response.StatusCode.Should().Be(HttpStatusCode.OK);
        // }

        // [Fact]
        // public async Task GetUser_WithId_ReturnsOK()
        // {
        //     await AuthenticateAsync();
        //     var response = await TestClient.GetAsync("admin/user/1");
        //     response.StatusCode.Should().Be(HttpStatusCode.OK);
        // }
        
    }
}