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
    public class RecipeIntegrationTests : IntegrationTest
    {
        [Fact]
        public async Task Get_WithoutId_ReturnsOK()
        {
            //Arrange
            //var mockRecipeRepo = new  MockRecipeRepo();
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
            var response = await TestClient.GetAsync("api/recipes/10");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task createRecipe_ReturnsOK()
        {
            await AuthenticateAsync();
            var response = await TestClient.PostAsJsonAsync("api/recipes/", new Recipe{
                    creatorId=10,
                    name="Kuru Fasulye",
                    description="Beans Boiled with tomato sauce",
                    rating=10.0F,
                    tag="Turkish Cuisine"
                });
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }


        [Fact]
        public async Task createRecipe_ReturnsUnauthorized()
        {
            //await AuthenticateAsync();
            var autswitchresponse = await TestClient.GetAsync("api/auth/on");
            var response = await TestClient.PostAsJsonAsync("api/recipes/", new Recipe{
                    creatorId=10,
                    name="Kuru Fasulye",
                    description="Beans Boiled with tomato sauce",
                    rating=10.0F,
                    tag="Turkish Cuisine"
                });
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }


        [Fact]
        public async Task updateRecipe_ReturnsNotFound()
        {

            await AuthenticateAsync();
            // var response = await TestClient.PatchAsync("api/recipes/",JsonContent.Create<RecipeDto>(new RecipeDto{id=1,
            //             creatorId=1,
            //             name="Imam bayildi",
            //             description="Eggplants stuffed with minced meat",
            //             rating=10.0F,
            //             tag="Turkish Cuisine"
            //             }));
            var response = await TestClient.PutAsJsonAsync("api/recipes/1",new Recipe{            recipeId=2,
                        creatorId=2,
                        name="Imam bayildi",
                        description="Eggplants stuffed with minced meat",
                        rating=10.0F,
                        tag="Turkish Cuisine"
                        });

            //var responseResult = await response.Content.ReadAsStringAsync();
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        }

        [Fact]
        public async Task removeRecipe_ReturnOK()
        {
            await AuthenticateAsync();
            var recipes = await TestClient.GetAsync("api/recipes");
            var responseResult = await recipes.Content.ReadFromJsonAsync<List<Recipe>>();
            var r = responseResult.First();
            var response = await TestClient.DeleteAsync($"api/recipes/{r.recipeId}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }


        // [Fact]
        // public async Task removeRecipe_ReturnNotFound()
        // {
        //     await AuthenticateAsync();
        //     //non-existing id
        //     var response = await TestClient.DeleteAsync("api/recipes/10");
        //     response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        // }

        //No Such endpoint available in Swagger-docs of group h
        // [Fact]
        // public async Task searchRecipes_ValidQuery_ReturnsOK()
        // {
        //     await AuthenticateAsync();
        //     var response = await TestClient.GetAsync("api/recipes/search?query=Kuru");
        //     response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);
        //     //they are not returning list of ingredients

        //     // var returnedResponse = response.Content.ReadFromJsonAsync<List<RecipeDto>>().Result;
        //     // returnedResponse.Should().BeEquivalentTo(simitList);

        // }

        //No Such endpoint available in Swagger-docs of group h
        // [Fact]
        // public async Task searchRecipes_InvalidQuery_ReturnsNotFound()
        // {
        //     await AuthenticateAsync();
        //     var response = await TestClient.GetAsync("api/recipes/search?query=patoto");
        //     response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        //     // var returnedResponse = response.Content.ReadFromJsonAsync<List<RecipeDto>>();
        //     // returnedResponse.Result.Should().BeEquivalentTo(null);
        // }

        [Fact]
        public async Task createSavedRecipe_ReturnsOK()
        {
            await AuthenticateAsync();
            var response = await TestClient.PostAsJsonAsync("api/saved_recipes", new SavedRecipeDto{
                id=5,
                userId=10,
                recipeId=2
            });
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);
        }
        
    }
}