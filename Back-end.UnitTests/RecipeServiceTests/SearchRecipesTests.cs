using System;
using System.Collections.Generic;
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
    public class SearchRecipesTests
    {
        private readonly IRecipeService _sut;

        Mock<IRecipeRepo> _recipeRepository = new Mock<IRecipeRepo>();
        Mock<IUserRepo> _userRepository = new Mock<IUserRepo>();

        Mock<IIngredientRepo> _ingredientRepository = new Mock<IIngredientRepo>();
        public SearchRecipesTests()
        {
            _sut = new RecipeService(_recipeRepository.Object,_userRepository.Object,new IngredientServices(_ingredientRepository.Object));
        }
        
        [Fact]
        public void SearchRecipes_Test()
        {

            var listitem = new RecipeDto{
                    id=1,
                    creatorId=1,
                    name="Bulgur",
                    description="Boiled Bulgur fried with butter",
                    rating=9.8F,
                    tag="Turkish Cuisine"
                };
           var returnedList = new List<RecipeDto>{
               listitem
           };

            _recipeRepository.Setup(x=>x.GetRecipeById(1)).Returns(listitem);
            _recipeRepository.Setup(x=>x.GetRecipes()).Returns(returnedList);
        
            var result = _sut.ServiceSearchRecipe("Bulgur");

            result.Should().BeEquivalentTo(returnedList,x=>x.ComparingByMembers<RecipeDto>());


        }
    }
}