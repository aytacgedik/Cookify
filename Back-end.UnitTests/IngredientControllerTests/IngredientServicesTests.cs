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
using Back_end.Services;

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

    public class IngredientServicesTests
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

        private readonly IngredientServices _sut;
        private readonly Mock<IIngredientRepo> _ingredientRepoMock = new Mock<IIngredientRepo>();

        public IngredientServicesTests()
        {
            _sut = new IngredientServices(_ingredientRepoMock.Object);
        }

        [Fact]
        public void ServiceGetIngredientById_ShouldReturnIngredientWhenExists()
        {
            //Arrange
            var ingredientId = new Random().Next();
            var ingredientDto = new IngredientDto
            {
                id = ingredientId,
                name = "Pirinc"
            };
            _ingredientRepoMock.Setup(x => x.GetIngredientById(ingredientId)).Returns(ingredientDto);

            //Act
            var ingredient =  _sut.ServiceGetIngredientById(ingredientId);

            //Assert
            Assert.Equal(ingredientDto.id, ingredient.id);
            Assert.Equal(ingredientDto.name, ingredient.name);
        }

        [Fact]
        public void ServiceGetIngredientById_ShouldReturnNothingWhenDoesNotExist()
        {
            //Arrange
            _ingredientRepoMock.Setup(x => x.GetIngredientById(It.IsAny<int>())).Returns(() => null);

            //Act
            var ingredient = _sut.ServiceGetIngredientById(0); //database identity starts from 1, hence ingredient id never is 0

            //Assert
            Assert.Null(ingredient);
        }

        [Fact]
        public void ServiceGetIngredients_ShouldReturnIngredientsWhenExist()
        {
            //Arrange
            var ingredientId = new Random();
            var ingredientsList = new List<IngredientDto>() { 
                new IngredientDto { id = ingredientId.Next(), name = "Pirinc"}, 
                new IngredientDto { id = ingredientId.Next(), name = "Patlican" } };
            _ingredientRepoMock.Setup(x => x.GetIngredients()).Returns(ingredientsList);

            //Act
            var ingredientsDtoList = _sut.ServiceGetIngredients();

            //Assert
            Assert.Equal(ingredientsDtoList.ElementAt(0).id, ingredientsList.ElementAt(0).id);
            Assert.Equal(ingredientsDtoList.ElementAt(0).name, ingredientsList.ElementAt(0).name);

            Assert.Equal(ingredientsDtoList.ElementAt(1).id, ingredientsList.ElementAt(1).id);
            Assert.Equal(ingredientsDtoList.ElementAt(1).name, ingredientsList.ElementAt(1).name);
        }

        [Fact]
        public void ServiceGetIngredients_ShouldReturnNothingWhenDoesNotExist()
        {
            //Arrange
            _ingredientRepoMock.Setup(x => x.GetIngredients()).Returns(() => null);

            //Act
            var ingredientsDtoList = _sut.ServiceGetIngredients();

            //Assert
            Assert.Null(ingredientsDtoList);
        }

        [Fact]
        public void ServiceSearchIngredient_ShouldReturnIngredientsWhenExists()
        {
            //Arrange
            var ingredientId = new Random();
            var query = "p";
            var ingredientsList = new List<IngredientDto>() {
                new IngredientDto { id = ingredientId.Next(), name = "Pirinc"},
                new IngredientDto { id = ingredientId.Next(), name = "Patlican" } };
            _ingredientRepoMock.Setup(x => x.ServiceSearchIngredient(query)).Returns(ingredientsList);

            //Act
            var ingredientsDtoList = _sut.ServiceSearchIngredient(query);

            //Assert
            Assert.Equal(ingredientsDtoList.ElementAt(0).id, ingredientsList.ElementAt(0).id);
            Assert.Equal(ingredientsDtoList.ElementAt(0).name, ingredientsList.ElementAt(0).name);

            Assert.Equal(ingredientsDtoList.ElementAt(1).id, ingredientsList.ElementAt(1).id);
            Assert.Equal(ingredientsDtoList.ElementAt(1).name, ingredientsList.ElementAt(1).name);
        }

        [Fact]
        public void ServiceSearchIngredient_ShouldReturnNothingWhenDoesNotExist()
        {
            //Arrange
            _ingredientRepoMock.Setup(x => x.ServiceSearchIngredient("")).Returns(new List<IngredientDto>());

            //Act
            var ingredientsDtoList = _sut.ServiceSearchIngredient("");

            //Assert
            Assert.Empty(ingredientsDtoList);
        }

        [Fact]
        public void ServiceGenerateList_ShouldReturnIngredientsWhenExists()
        {
            //Arrange
            var ingredientId = new Random();
            var ingredientsList = new List<IngredientDto>() {
                new IngredientDto { id = ingredientId.Next(), name = "Pirinc"},
                new IngredientDto { id = ingredientId.Next(), name = "Patlican" } };
            var recipeId = ingredientId.Next();
            _ingredientRepoMock.Setup(x => x.GetRecipeIngredients(recipeId)).Returns(ingredientsList);

            //Act
            var ingredientsDtoList = _sut.ServiceGenerateList(recipeId);

            //Assert
            Assert.Equal(ingredientsDtoList.ElementAt(0).id, ingredientsList.ElementAt(0).id);
            Assert.Equal(ingredientsDtoList.ElementAt(0).name, ingredientsList.ElementAt(0).name);

            Assert.Equal(ingredientsDtoList.ElementAt(1).id, ingredientsList.ElementAt(1).id);
            Assert.Equal(ingredientsDtoList.ElementAt(1).name, ingredientsList.ElementAt(1).name);
        }

        [Fact]
        public void ServiceGenerateList_ShouldReturnNothingWhenDoesNotExist()
        {
            //Arrange
            _ingredientRepoMock.Setup(x => x.GetRecipeIngredients(0)).Returns(() => null);

            //Act
            var ingredientsDtoList = _sut.ServiceGenerateList(0);

            //Assert
            Assert.Null(ingredientsDtoList);
        }
    }
}
