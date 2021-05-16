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
    public class IngredientControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetIngredient_WithoutId_ReturnsOK()
        {
            //Arrange
            var mockRecipeRepo = new MockRecipeRepo();
            await AuthenticateAsync();

            //Act
            var response = await TestClient.GetAsync("api/ingredient");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetIngredint_WithId_ReturnsOK()
        {
            await AuthenticateAsync();
            var response = await TestClient.GetAsync("api/ingredient/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task searchIngredient_ValidQuery_ReturnsOK()
        {
            await AuthenticateAsync();
            var hersheyList = new List<Ingredient> { new Ingredient { id = 1, name="Hershey Dark Chocolate" } }.Select(x => x.AsDto());
            var response = await TestClient.GetAsync("api/ingredients/search?query=Hershey Dark Chocolate");
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);
            var returnedResponse = response.Content.ReadFromJsonAsync<List<RecipeDto>>().Result;
            returnedResponse.Should().BeEquivalentTo(hersheyList);
        }

        [Fact]
        public async Task searchIngredients_ValidQuery_ReturnsOK()
        {
            await AuthenticateAsync();
            var chocolateList = new List<Ingredient> { new Ingredient { id = 1, name = "Hershey Dark Chocolate" }, 
                new Ingredient { id = 2, name = "Cadbury Milky Chocolate" }, 
                new Ingredient { id = 3, name = "Lindt White Chocolate" } }.Select(x => x.AsDto());
            var response = await TestClient.GetAsync("api/ingredients/search?query=Chocolate");
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);
            var returnedResponse = response.Content.ReadFromJsonAsync<List<RecipeDto>>().Result;
            returnedResponse.Should().BeEquivalentTo(chocolateList);
        }

        /*[Fact]
        public async Task searchIngredient_InvalidQuery_ReturnsNotFound()
        {
            await AuthenticateAsync();
            var response = await TestClient.GetAsync("api/ingredients/search?query=hebele");
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
            // var returnedResponse = response.Content.ReadFromJsonAsync<List<RecipeDto>>();
            // returnedResponse.Result.Should().BeEquivalentTo(null);
        }*/
    }
}
