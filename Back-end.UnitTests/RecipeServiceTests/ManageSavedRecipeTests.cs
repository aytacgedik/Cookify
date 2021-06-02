using System.Collections.Generic;
using System.Linq;
using Back_end.Controllers;
using Back_end.Data;
using Back_end.Dtos;
using Back_end.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Back_end.UnitTests.RecipeControllerTests
{
    public class ManageSavedRecipeTests
    {
        private readonly ISavedRecipeService _sut;

        private readonly Mock<ISavedRecipeRepo> _savedRecipeRepository = new Mock<ISavedRecipeRepo>();
        public ManageSavedRecipeTests()
        {
            _sut = new SavedRecipeService(_savedRecipeRepository.Object);
        }

        [Fact]
        public void createSavedRecipe_Test()
        {
            //Arrange
            var listitemup = new SavedRecipeInputDto{
                userId = 1,
                recipeId = 1
            };
            var listitem = new SavedRecipeDto{
                id =1,
                userId = 1,
                recipeId = 1
            };
            var savedrecipelist = new List<SavedRecipeDto>()
            {
                listitem
            };
            //Act
            _savedRecipeRepository.Setup(x=>x.CreateSavedRecipe(listitemup)).Returns(savedrecipelist);

            var result = _sut.ServiceCreateSavedRecipe(listitemup);

            //Assert
            result.Should().BeEquivalentTo(savedrecipelist,x=>x.ComparingByMembers<RecipeDto>());
        }
    }
}