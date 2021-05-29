using System;
using Xunit;
using Moq;
using Back_end.Controllers;
using Back_end.Data;
using Back_end.Dtos;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FluentAssertions;
using System.Diagnostics.CodeAnalysis;

namespace Back_end.UnitTests
{
    // public class RecipeDtoComparer : IEqualityComparer<RecipeDto>
    // {
    //     public bool Equals(RecipeDto x, RecipeDto y)
    //     {
    //         if (x == null || y == null)
    //         {
    //             return false;
    //         }
    //         bool equals = (x.id == y.id &&
    //                        x.name == y.name &&
    //                        x.description == y.description &&
    //                        x.creatorId == y.creatorId &&
    //                        x.tag == y.tag &&
    //                        x.rating == y.rating);

    //         return equals;
    //     }

    //     public int GetHashCode(RecipeDto obj)
    //     {
    //         if (obj == null)
    //         {
    //             return int.MinValue;
    //         }
    //         int hash = 1;
    //         hash = hash + obj.id.GetHashCode();
    //         hash = hash + obj.name.GetHashCode();
    //         hash = hash + obj.creatorId.GetHashCode();
    //         hash = hash + obj.description.GetHashCode();
    //         hash = hash + obj.rating.GetHashCode();
    //         hash = hash + obj.tag.GetHashCode();
    //         return hash;
    //     }
    // }

    public class ManageRecipeTest
    {

        // [Fact]
        // public void GetRecipeByID_Test()
        // {
        //     // Arrange
        //     var repositoryStub = new Mock<IRecipeRepo>();
        //     var mockRecipeRepo = new MockRecipeRepo();
        //     repositoryStub.Setup(repo => repo.GetRecipes()).Returns(mockRecipeRepo.GetRecipes());

        //     var repositoryStub2 = new Mock<IUserRepo>();
        //     var mockUserRepo = new MockUserRepo();
        //     repositoryStub2.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());

        //     var controller = new ManageRecipe(mockRecipeRepo,mockUserRepo);

        //     // Act
        //     var result = controller.getRecipe(1).Result as OkObjectResult;
        //     var tmp = mockRecipeRepo.GetRecipeById(1).AsDto();

        //     result.Value.Should().BeEquivalentTo(tmp,
        //     options=>options.ComparingByMembers<RecipeDto>());
        // }

        // [Fact]
        // public void removeRecipe_Test()
        // {
        //     // Arrange
        //     var repositoryStub = new Mock<IRecipeRepo>();
        //     var mockRecipeRepo = new MockRecipeRepo();
        //     repositoryStub.Setup(repo => repo.GetRecipes()).Returns(mockRecipeRepo.GetRecipes());

        //     var repositoryStub2 = new Mock<IUserRepo>();
        //     var mockUserRepo = new MockUserRepo();
        //     repositoryStub2.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());

        //     var controller = new ManageRecipe(mockRecipeRepo,mockUserRepo);

        //     var mockRecipe = new MockRecipeRepo();
        //     var result = controller.removeRecipe(1).Result as ObjectResult;
        //     var tmp = mockRecipe.DeleteRecipeById(1).Select(x => x.AsDto());

        //     result.Value.Should().BeEquivalentTo(tmp,options=>options.ComparingByMembers<RecipeDto>());
            
        // }

        // [Fact]
        // public void updateRecipe_Test()
        // {
        //     var repositoryStub = new Mock<IRecipeRepo>();
        //     var mockRecipeRepo = new MockRecipeRepo();
        //     repositoryStub.Setup(repo => repo.GetRecipes()).Returns(mockRecipeRepo.GetRecipes());

        //     var repositoryStub2 = new Mock<IUserRepo>();
        //     var mockUserRepo = new MockUserRepo();
        //     repositoryStub2.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());

        //     var controller = new ManageRecipe(mockRecipeRepo,mockUserRepo);

        //     var toupdate = new Recipe{id=1,
        //                     creatorId=1,
        //                     name="Bulgur",
        //                     description="Boiled Bulgur fried with butter",
        //                     rating=9.8F,
        //                     tag="Turkish Cuisine"};


        //     var mockRecipe = new MockRecipeRepo();
        //     var result = controller.updateRecipe(toupdate).Result as OkObjectResult;
        //     var tmp = mockRecipe.UpdateRecipeById(toupdate.id,toupdate.creatorId,toupdate.name,toupdate.description,toupdate.rating,toupdate.tag).AsDto();

        //     result.Value.Should().BeEquivalentTo(tmp,options=>options.ComparingByMembers<RecipeDto>());

        // }

        // [Fact]
        // public void createRecipe_Test()
        // {
        //     var repositoryStub = new Mock<IRecipeRepo>();
        //     var mockRecipeRepo = new MockRecipeRepo();
        //     repositoryStub.Setup(repo => repo.GetRecipes()).Returns(mockRecipeRepo.GetRecipes());

        //     var repositoryStub2 = new Mock<IUserRepo>();
        //     var mockUserRepo = new MockUserRepo();
        //     repositoryStub2.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());

        //     var controller = new ManageRecipe(mockRecipeRepo,mockUserRepo);

        //     var tocreate = new Recipe{id=6,
        //         creatorId=5,
        //         name="Bulgur",
        //         description="Boiled Bulgur fried with butter",
        //         rating=9.8F,
        //         tag="Turkish Cuisine"};

        //     var mockRecipe = new MockRecipeRepo();
        //     var result = controller.createRecipe(tocreate).Result as OkObjectResult;
        //     var tmp = mockRecipe.CreateRecipe(tocreate).Select(x => x.AsDto());

        //     result.Value.Should().BeEquivalentTo(tmp,options=>options.ComparingByMembers<RecipeDto>());
        // }


        // [Fact]
        // public void GetRecipeAll_Test()
        // {
        //     var repositoryStub = new Mock<IRecipeRepo>();
        //     var mockRecipeRepo = new MockRecipeRepo();
        //     repositoryStub.Setup(repo => repo.GetRecipes()).Returns(mockRecipeRepo.GetRecipes());

        //     var repositoryStub2 = new Mock<IUserRepo>();
        //     var mockUserRepo = new MockUserRepo();
        //     repositoryStub2.Setup(repo => repo.GetUsers()).Returns(mockUserRepo.GetUsers());

        //     var controller = new ManageRecipe(mockRecipeRepo,mockUserRepo);


        //     var mockRecipe = new MockRecipeRepo();
        //     var result = controller.getRecipe().Result as OkObjectResult;
        //     var tmp = mockRecipe.GetRecipes().Select(x => x.AsDto());

        //     result.Value.Should().BeEquivalentTo(tmp,options=>options.ComparingByMembers<RecipeDto>());
        // }
    }
}