using System;
using Xunit;
using Moq;
using Back_end.Controllers;
using Back_end.Data;
using Back_end.Models;
using Back_end.Dtos;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FluentAssertions;

namespace Back_end.UnitTests
{   
    public class AdminManageRecipeTests
    {
        // [Fact]
        // public void GetAllRecipesTest()
        // {
        //     // Arrange
        //     var repositoryStub = new Mock<IRecipeRepo>();
        //     var recipeRepo = new MockRecipeRepo();
        //     repositoryStub.Setup(repo => repo.GetRecipes()).Returns(recipeRepo.repo);
        //     var controller = new AdminManageRecipeController(recipeRepo);
        //     // Act
        //     var result = controller.GetAllRecipes().Result as OkObjectResult;
        //     var tmpList = recipeRepo.GetRecipes().Select(x => x.AsDto()).ToList();
        //     bool areEqual = Enumerable.SequenceEqual(tmpList, (IEnumerable<RecipeDto>)result.Value, new RecipeDtoComparer());
        //     // Assert
        //     Assert.True(areEqual);
        // }

        // [Fact]
        // public void DeleteRecipeTest()
        // {
        //     // Arrange
        //     var repositoryStub = new Mock<IRecipeRepo>();
        //     var recipeRepo = new MockRecipeRepo();
        //     var recipes = new List<Recipe>(recipeRepo.repo);
        //     recipes.RemoveAt(recipes.FindIndex(u => u.id == 1));
        //     var tmpList = recipes.Select(x => x.AsDto()).ToList();
        //     repositoryStub.Setup(repo => repo.GetRecipes()).Returns(recipes);
        //     var controller = new AdminManageRecipeController(recipeRepo);
        //     // Act
        //     var result = controller.RemoveRecipe(1).Result as OkObjectResult;
        //     var areEqual = Enumerable.SequenceEqual(tmpList, (IEnumerable<RecipeDto>)result.Value, new RecipeDtoComparer());
        //     // Assert
        //     Assert.True(areEqual);
        // }

        // [Fact]
        // public void UpdateRecipeTest()
        // {
        //     // Arrange
            
        //     Recipe tmpRecipe = new Recipe
        //     {
        //         id = 1,
        //         creatorId = 1,
        //         name = "test",
        //         description = "test",
        //         rating = 2.0F,
        //         tag = "test"
        //     };
        //     var repositoryStub = new Mock<IRecipeRepo>();
        //     var recipeRepo = new MockRecipeRepo();
        //     repositoryStub.Setup(repo => repo.GetRecipes()).Returns(recipeRepo.GetRecipes());
        //     var controller = new AdminManageRecipeController(recipeRepo);
        //     // Act
        //     var result = controller.updateRecipe(tmpRecipe).Result as OkObjectResult;
        //     var tmpR = recipeRepo.UpdateRecipeById(tmpRecipe.id, tmpRecipe.creatorId, tmpRecipe.name, tmpRecipe.description, tmpRecipe.rating, tmpRecipe.tag);
        //     // Assert
        //     result.Value.Should().BeEquivalentTo(tmpR, options => options.ComparingByMembers<User>());

        // }
    }
}