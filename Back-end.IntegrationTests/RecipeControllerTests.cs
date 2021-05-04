using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Net;
using Back_end.Data;
using System.Collections.Generic;
using Back_end.Models;
using System.Linq;
using System.Net.Http.Json;
using Back_end.Dtos;

namespace Back_end.IntegrationTests
{
    public class RecipeControllerTests : IntegrationTest
    {
        [Fact]
        public async Task Get_WithoutId_ReturnsOK()
        {
            //Arrange
            var mockRecipeRepo = new  MockRecipeRepo();
            await AuthenticateAsync();
            //Act
            var response = await TestClient.GetAsync("api/recipes");
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            //response.Content.ReadFromJsonAsync<Recipe>().Should().BeEquivalentTo(mockRecipeRepo.GetRecipes());
        }

        [Fact]
        public async Task Get_WithId_ReturnsOK()
        {
            await AuthenticateAsync();
            var response = await TestClient.GetAsync("api/recipes/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
    }
}