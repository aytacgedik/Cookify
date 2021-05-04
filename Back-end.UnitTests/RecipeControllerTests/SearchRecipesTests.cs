using System;
using System.Collections.Generic;
using Back_end.Controllers;
using Back_end.Data;
using Back_end.Dtos;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Back_end.UnitTests.RecipeControllerTests
{
    public class SearchRecipesTests
    {
        [Fact]
        public void SearchRecipes_Test()
        {
            var repositoryStub = new Mock<IRecipeRepo>();
            var mockRecipeRepo = new MockRecipeRepo();
            repositoryStub.Setup(repo => repo.GetRecipes()).Returns(mockRecipeRepo.GetRecipes());

            var repositoryStub2 = new Mock<IUserRepo>();
            var mockUserRepo = new MockUserRepo();
            repositoryStub2.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());

            var controller = new SearchRecipes(mockRecipeRepo,mockUserRepo);

            var query = "simit";
            var result = controller.searchRecipes(query).Result as OkObjectResult;
            var mockRepo = new MockRecipeRepo();
            

            List<RecipeDto> recipesToReturn = new List<RecipeDto>();
            if(!String.IsNullOrEmpty(query))
                foreach(var recipe in mockRepo.GetRecipes())
                {
                    if(recipe.name.ToLower().Contains(query.ToLower()))
                        recipesToReturn.Add(recipe.AsDto());
                }

            result.Value.Should().BeEquivalentTo(recipesToReturn,options=>options.ComparingByMembers<RecipeDto>());
        }
    }
}