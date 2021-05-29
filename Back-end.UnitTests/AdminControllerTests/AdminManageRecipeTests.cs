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
using Back_end.Services;

namespace Back_end.UnitTests
{   
    public class AdminManageRecipeTests
    {
        [Fact]
        public void GetRecipeByIdTest()
        {    
            // Arrange
            var repoMock = new Mock<IRecipeRepo>();
            var recipe = new Recipe()
            {
                id = 1,
                creatorId = 1,
                name = "test",
                description = "test",
                rating = 6.7F,
                tag = "test"
            };
            repoMock.Setup(p => p.GetRecipeById(1)).Returns(recipe);
            var service = new AdminManageRecipeServices(repoMock.Object);
            var ctl = new AdminManageRecipeController(service);
            // Act
            var result = ctl.getRecipe(1).Result as OkObjectResult;
            // Assert
            result.Value.Should().BeEquivalentTo(recipe, options => options.ComparingByMembers<Recipe>());
        }
        
        
        [Fact]
        public void GetAllRecipesTest()
        {
             var repoMock = new Mock<IRecipeRepo>();
             var recipeList = new List<Recipe>{
                new Recipe{id=1,
                            creatorId=1,
                            name="Pilav",
                            description="Boiled rice fried with butter",
                            rating=9.8F,
                            tag="Turkish Cuisine"},
                new Recipe{id=2,
                            creatorId=2,
                            name="Karni Yarik",
                            description="Eggplants stuffed with minced meat",
                            rating=10.0F,
                            tag="Turkish Cuisine"},
             };
             repoMock.Setup(p => p.GetRecipes()).Returns(recipeList);
             var service = new AdminManageRecipeServices(repoMock.Object);
             var ctl = new AdminManageRecipeController(service);
             // Act
             var result = ctl.GetAllRecipes().Result as OkObjectResult;
             // Assert
             result.Value.Should().BeEquivalentTo(recipeList, options => options.ComparingByMembers<Recipe>());
        }

        [Fact]
        public void DeleteRecipeTest()
        {
             // Arrange
             var repoMock = new Mock<IRecipeRepo>();
             var after = new List<Recipe>{
                new Recipe{id=2,
                            creatorId=2,
                            name="Karni Yarik",
                            description="Eggplants stuffed with minced meat",
                            rating=10.0F,
                            tag="Turkish Cuisine"}
             };
             repoMock.Setup(p => p.DeleteRecipeById(1)).Returns(after);
             var service = new AdminManageRecipeServices(repoMock.Object);
             var ctl = new AdminManageRecipeController(service);
             // Act
             var result = ctl.removeRecipe(1).Result as OkObjectResult;
             // Assert
             result.Value.Should().BeEquivalentTo(after, options => options.ComparingByMembers<Recipe>());

        }

        [Fact]
        public void UpdateRecipeTest()
        {
            // Arrange
            var repoMock = new Mock<IRecipeRepo>();
            var after = new Recipe()
            {
                id = 1,
                creatorId = 1,
                name = "test",
                description = "test",
                rating = 6.7F,
                tag = "test"
            };
            repoMock.Setup(p => p.UpdateRecipeById(1, 1, "test", "test", 6.7F, "test")).Returns(after);
            var service = new AdminManageRecipeServices(repoMock.Object);
            var ctl = new AdminManageRecipeController(service);
            // Act
            var result = ctl.updateRecipe(after).Result as OkObjectResult;
            // Assert
            result.Value.Should().BeEquivalentTo(after, options => options.ComparingByMembers<Recipe>());

        }
    }
}