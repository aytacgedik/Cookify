using System;
using Xunit;
using Moq;
using Back_end.Controllers;
using Back_end.Data;
using Back_end.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Back_end.UnitTests
{
    public class RecipeComparer : IEqualityComparer<Recipe>
    {
        public bool Equals(Recipe x, Recipe y)
        {
            if (x == null || y == null) return false;

            bool equals = x.id==y.id && x.creatorId == y.creatorId && x.name == y.name 
                && x.description == y.description && x.rating == y.rating && x.tag == y.tag;
            return equals;
        }

        public int GetHashCode(Recipe obj)
        {
            if (obj == null) return int.MinValue;

            int hash = 1;
            hash = hash + obj.id.GetHashCode();
            hash = hash + obj.creatorId.GetHashCode();
            hash = hash + obj.name.GetHashCode();
            hash = hash + obj.description.GetHashCode();
            hash = hash + obj.rating.GetHashCode();
            hash = hash + obj.tag.GetHashCode();
            return hash;
        }
    }
    
    public class AdminManageRecipeTests
    {
        [Fact]
        public void GetAllRecipesTest()
        {
            // Arrange
            var repositoryStub = new Mock<IRecipeRepo>();
            var recipeRepo = new MockRecipeRepo();
            repositoryStub.Setup(repo => repo.GetRecipes()).Returns(recipeRepo.repo);
            var controller = new AdminManageRecipeController(recipeRepo);
            // Act
            var result = controller.GetAllRecipes().Result as OkObjectResult;
            bool areEqual = Enumerable.SequenceEqual(repositoryStub.Object.GetRecipes(), (IEnumerable<Recipe>)result.Value, new RecipeComparer());
            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void DeleteRecipeTest()
        {
            // Arrange
            var repositoryStub = new Mock<IRecipeRepo>();
            var recipeRepo = new MockRecipeRepo();
            var recipes = new List<Recipe>(recipeRepo.repo);
            recipes.RemoveAt(recipes.FindIndex(u => u.id == 1));
            repositoryStub.Setup(repo => repo.GetRecipes()).Returns(recipes);
            var controller = new AdminManageRecipeController(recipeRepo);
            // Act
            var result = controller.RemoveRecipe(1).Result as OkObjectResult;
            var areEqual = Enumerable.SequenceEqual(repositoryStub.Object.GetRecipes(), (IEnumerable<Recipe>)result.Value, new RecipeComparer());
            // Assert
            Assert.True(areEqual);
        }
    }
}