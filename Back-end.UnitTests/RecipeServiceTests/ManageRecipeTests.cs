using System;
using Xunit;
using Moq;
using Back_end.Controllers;
using Back_end.Data;
using Back_end.Dtos;
using Back_end.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace Back_end.UnitTests
{

    public class ManageRecipeTest
    {
        private readonly IRecipeService _sut;

        Mock<IRecipeRepo> _recipeRepository = new Mock<IRecipeRepo>();
        Mock<IUserRepo> _userRepository = new Mock<IUserRepo>();

        Mock<IIngredientRepo> _ingredientRepository = new Mock<IIngredientRepo>();
        public ManageRecipeTest()
        {
            _sut = new RecipeService(_recipeRepository.Object,_userRepository.Object,new IngredientServices(_ingredientRepository.Object));
        }

        [Fact]
        public void GetRecipeByID_Test()
        {
            // Arrange
            var listitem = new RecipeDto{
                    id=1,
                    creatorId=1,
                    name="Bulgur",
                    description="Boiled Bulgur fried with butter",
                    rating=9.8F,
                    tag="Turkish Cuisine"
            };
            var tobereturned = new List<RecipeDto>
            {
                listitem
            };

            _recipeRepository.Setup(x=>x.GetRecipeById(1)).Returns(listitem);


            var tmp = _sut.ServiceGetRecipeById(1);

            tmp.Should().BeEquivalentTo(listitem,
            options=>options.ComparingByMembers<RecipeDto>());
        }

        [Fact]
        public void removeRecipe_Test()
        {
            // Arrange
            var listitem = new RecipeDto{
                    id=1,
                    creatorId=1,
                    name="Bulgur",
                    description="Boiled Bulgur fried with butter",
                    rating=9.8F,
                    tag="Turkish Cuisine"
            };
            var tobereturned = new List<RecipeDto>
            {
                listitem
            };
            _recipeRepository.Setup(x=>x.DeleteRecipeById(1)).Returns(tobereturned);
            _recipeRepository.Setup(x=>x.GetRecipeById(1)).Returns(listitem);
            _recipeRepository.Setup(x=>x.GetRecipes()).Returns(tobereturned);


            var tmp = _sut.ServiceDeleteRecipeById(1);

            tmp.Should().BeEquivalentTo(tobereturned,
            options=>options.ComparingByMembers<RecipeDto>());
        }

        [Fact]
        public void updateRecipe_Test()
        {
            var listitemup = new RecipePatchDto{
                creatorId=1,
                name="Bulgur",
                description="Boiled Bulgur fried with butter",
                rating=9.8F,
                tag="Turkish Cuisine"
            };
            var listitem = new RecipeDto{
                id=1,
                creatorId=1,
                name="Bulgur",
                description="Boiled Bulgur fried with butter",
                rating=9.8F,
                tag="Turkish Cuisine"
            };
            var tobereturned = new List<RecipeDto>
            {
                listitem
            };
            _recipeRepository.Setup(x=>x.UpdateRecipeById(1,listitemup)).Returns(listitem);
            _recipeRepository.Setup(x=>x.GetRecipeById(1)).Returns(listitem);
            _recipeRepository.Setup(x=>x.GetRecipes()).Returns(tobereturned);


            var tmp = _sut.ServiceUpdateRecipeById(1,listitemup);

            tmp.Should().BeEquivalentTo(listitem,
            options=>options.ComparingByMembers<RecipeDto>());;

        }

        [Fact]
        public void createRecipe_Test()
        {
            var listitemup = new RecipeInputDto{
                creatorId=1,
                name="Bulgur",
                description="Boiled Bulgur fried with butter",
                rating=9.8F,
                tag="Turkish Cuisine"
            };
            var listitem = new RecipeDto{
                id=1,
                creatorId=1,
                name="Bulgur",
                description="Boiled Bulgur fried with butter",
                rating=9.8F,
                tag="Turkish Cuisine"
            };
            var tobereturned = new List<RecipeDto>
            {
                listitem
            };
            _recipeRepository.Setup(x=>x.CreateRecipe(listitemup)).Returns(tobereturned);
            _recipeRepository.Setup(x=>x.GetRecipeById(1)).Returns(listitem);
            _recipeRepository.Setup(x=>x.GetRecipes()).Returns(tobereturned);


            var tmp = _sut.ServiceCreateRecipe(listitemup);

            tmp.Should().BeEquivalentTo(tobereturned,
            options=>options.ComparingByMembers<RecipeDto>());;
        }


        [Fact]
        public void GetRecipeAll_Test()
        {
            // Arrange
            var listitem = new RecipeDto{
                    id=1,
                    creatorId=1,
                    name="Bulgur",
                    description="Boiled Bulgur fried with butter",
                    rating=9.8F,
                    tag="Turkish Cuisine"
            };
            var tobereturned = new List<RecipeDto>
            {
                listitem
            };

            _recipeRepository.Setup(x=>x.GetRecipeById(1)).Returns(listitem);
            _recipeRepository.Setup(x=>x.GetRecipes()).Returns(tobereturned);


            var tmp = _sut.ServiceGetRecipes();

            tmp.Should().BeEquivalentTo(tobereturned,
            options=>options.ComparingByMembers<RecipeDto>());;
        }
    }
}