using System;
using Xunit;
using Moq;
using Back_end.Controllers;
using Back_end.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using System.Linq;
using Back_end.Dtos;

namespace Back_end.UnitTests
{
    // public class IngredientComparer : IEqualityComparer<IngredientDto>
    // {
    //     public bool Equals(IngredientDto x, IngredientDto y)
    //     {
    //         if (x == null || y == null) return false;

    //         bool equals = x.id == y.id && x.name == y.name;
    //         return equals;
    //     }

    //     public int GetHashCode(IngredientDto obj)
    //     {
    //         if (obj == null) return int.MinValue;

    //         int hash = 1;
    //         hash = hash + obj.id.GetHashCode();
    //         hash = hash + obj.name.GetHashCode();
    //         return hash;
    //     }
    // }

    public class IngredientControllerTest
    {
        // [Fact]
        // public void getIngredients()
        // {
        //     // Arrange
        //     var repositoryStubRecipe = new Mock<IRecipeRepo>();
        //     var recipeRepo = new MockRecipeRepo();
            
        //     var repositoryStubIngredient = new Mock<IIngredientRepo>();
        //     var ingredientRepo = new MockIngredientRepo();

        //     repositoryStubIngredient.Setup(repo => repo.GetIngredients()).Returns(ingredientRepo.GetIngredients());

        //     var controller = new ManageIngredient(recipeRepo, ingredientRepo);

        //     //Act
        //     var result = controller.getIngredients().Result as OkObjectResult;
        //     var first = repositoryStubIngredient.Object.GetIngredients().Select(x => x.AsDto()).ToList();
        //     var areEqual = Enumerable.SequenceEqual(first, (IEnumerable<IngredientDto>)result.Value, new IngredientComparer());

        //     // Assert
        //     Assert.True(areEqual);
        // }

        // [Fact]
        // public void getIngredient()
        // {
        //     // Arrange
        //     var repositoryStubRecipe = new Mock<IRecipeRepo>();
        //     var recipeRepo = new MockRecipeRepo();

        //     var repositoryStubIngredient = new Mock<IIngredientRepo>();
        //     var ingredientRepo = new MockIngredientRepo();

        //     repositoryStubIngredient.Setup(repo => repo.GetIngredientById(1)).Returns(ingredientRepo.GetIngredientById(1));

        //     var controller = new ManageIngredient(recipeRepo, ingredientRepo);

        //     //Act
        //     var result = controller.getIngredient(1).Result as OkObjectResult;
        //     var first = repositoryStubIngredient.Object.GetIngredientById(1).AsDto();
        //     //var areEqual = Enumerable.SequenceEqual(first, (IEnumerable<IngredientDto>)result.Value, new IngredientComparer());

        //     // Assert
        //     //Assert.True(areEqual);

        //     result.Value.Should().BeEquivalentTo(first, options => options.ComparingByMembers<Ingredient>());
        // }

        // [Fact]
        // public void searchIngredients()
        // {
        //     // Arrange
        //     var repositoryStubRecipe = new Mock<IRecipeRepo>();
        //     var recipeRepo = new MockRecipeRepo();

        //     var repositoryStubIngredient = new Mock<IIngredientRepo>();
        //     var ingredientRepo = new MockIngredientRepo();

        //     repositoryStubIngredient.Setup(repo => repo.GetIngredients()).Returns(ingredientRepo.GetIngredients());

        //     var controller = new SearchIngredients(recipeRepo, ingredientRepo);

        //     //Act
        //     string query = "Hershey";
        //     var result = controller.searchIngredients(query).Result as OkObjectResult;
        //     var first = repositoryStubIngredient.Object.GetIngredients().Select(x => x.AsDto()).ToList();

        //     List<IngredientDto> ingredientsToReturn = new List<IngredientDto>();
        //     if (!String.IsNullOrEmpty(query))
        //     {
        //         foreach (var ingredient in first)
        //         {
        //             if (ingredient.name.Contains(query))
        //                 ingredientsToReturn.Add(ingredient);
        //         }
        //     }

        //     var areEqual = Enumerable.SequenceEqual(ingredientsToReturn, (IEnumerable<IngredientDto>)result.Value, new IngredientComparer());

        //     // Assert
        //     Assert.True(areEqual);
        // }
    }
}
