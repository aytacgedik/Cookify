using System.Linq;
using Back_end.Controllers;
using Back_end.Data;
using Back_end.Models;
using Back_end.Dtos;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Back_end.UnitTests.RecipeControllerTests
{
    public class ManageSavedRecipeTests
    {
        // [Fact]
        // public void createSavedRecipe_Test()
        // {
        //     var repositoryStub = new Mock<ISavedRecipeRepo>();
        //     var mockSavedRecipeRepo = new MockSavedRecipeRepo();
        //     repositoryStub.Setup(repo => repo.GetSavedRecipes()).Returns(mockSavedRecipeRepo.GetSavedRecipes());

        //     var repositoryStub2 = new Mock<IUserRepo>();
        //     var mockUserRepo = new MockUserRepo();
        //     repositoryStub2.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());

        //     var repositoryStub3 = new Mock<IRecipeRepo>();
        //     var mockRecipeRepo = new MockRecipeRepo();
        //     repositoryStub3.Setup(repo => repo.GetRecipes()).Returns(mockRecipeRepo.GetRecipes());


        //     var controller = new ManageSavedRecipe(mockRecipeRepo,mockUserRepo,mockSavedRecipeRepo);

        //     var tocreate = new SavedRecipe{id=3,
        //                                     userId=3,
        //                                     recipeId=3};

        //     var mockRecipe = new MockSavedRecipeRepo();
        //     var result = controller.createSavedRecipe(tocreate).Result as OkObjectResult;
        //     var tmp = mockRecipe.CreateSavedRecipe(tocreate).Select(x => x.AsDto());

        //     result.Value.Should().BeEquivalentTo(tmp,options=>options.ComparingByMembers<SavedRecipeDto>());
        // }
    }
}