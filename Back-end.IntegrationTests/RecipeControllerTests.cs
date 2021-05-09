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
            //response.Content.ReadFromJsonAsync<Recipe>().Should().BeNull();
        }

        [Fact]
        public async Task Get_WithId_ReturnsOK()
        {
            await AuthenticateAsync();
            var response = await TestClient.GetAsync("api/recipes/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task createRecipe_ReturnsOK()
        {
            await AuthenticateAsync();
            var response = await TestClient.PostAsJsonAsync("api/recipes/", new Recipe{id=5,
                    creatorId=2,
                    name="Kuru Fasulye",
                    description="Beans Boiled with tomato sauce",
                    rating=10.0F,
                    tag="Turkish Cuisine"
                });
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        [Fact]
        public async Task createRecipe_ReturnsNotFound()
        {
            await AuthenticateAsync();
            var response = await TestClient.PostAsJsonAsync("api/recipes/", new Recipe{id=1,
                    creatorId=2,
                    name="Kuru Fasulye",
                    description="Beans Boiled with tomato sauce",
                    rating=10.0F,
                    tag="Turkish Cuisine"
                });
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


        [Fact]
        public async Task updateRecipe_ReturnsOK()
        {
            // await AuthenticateAsync();
            // var response = await TestClient.PutAsJsonAsync("api/recipes/",                 
            // new Recipe{id=2,
            //             creatorId=2,
            //             name="Imam bayildi",
            //             description="Eggplants stuffed with minced meat",
            //             rating=10.0F,
            //             tag="Turkish Cuisine"
            //             });
            // response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task removeRecipe_ReturnOK()
        {
            await AuthenticateAsync();
            var response = await TestClient.DeleteAsync("api/recipes/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }


        [Fact]
        public async Task removeRecipe_ReturnNotFound()
        {
            await AuthenticateAsync();
            //non-existing id
            var response = await TestClient.DeleteAsync("api/recipes/10");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        }

        [Fact]
        public async Task searchRecipes_ValidQuery_ReturnsOK()
        {
            await AuthenticateAsync();
            var simitList = new List<Recipe>{ new Recipe{id=3,
                            creatorId=3,
                            name="Simit",
                            description="Turkish bagel with sesame",
                            rating=6.9F,
                            tag="Turkish Cuisine"}}.Select(x=>x.AsDto());
            var response = await TestClient.GetAsync("api/recipes/search?query=Simit");
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);
            var returnedResponse = response.Content.ReadFromJsonAsync<List<RecipeDto>>().Result;
            returnedResponse.Should().BeEquivalentTo(simitList);

        }


        [Fact]
        public async Task searchRecipes_InvalidQuery_ReturnsNotFound()
        {
            await AuthenticateAsync();
            var response = await TestClient.GetAsync("api/recipes/search?query=patoto");
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
            // var returnedResponse = response.Content.ReadFromJsonAsync<List<RecipeDto>>();
            // returnedResponse.Result.Should().BeEquivalentTo(null);
        }

        [Fact]
        public async Task createSavedRecipe_ReturnsOK()
        {
            await AuthenticateAsync();
            var response = await TestClient.PostAsJsonAsync("api/saved_recipes", new SavedRecipe{
                id=5,
                userId=1,
                recipeId=2
            });
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);
        }
        
    }
}