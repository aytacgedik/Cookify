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
    public class UserFriendControllerTests
    {
        // [Fact]
        // public void createUserFriend_Test()
        // {
        //     // Arrange
        //     var repositoryStub = new Mock<IUserFriendRepo>();
        //     var mockUserFriendRepo = new MockUserFriendRepo();
        //     repositoryStub.Setup(repo => repo.GetUserFriends()).Returns(mockUserFriendRepo.GetUserFriends());
        //     var mockUserFriendRepo2 = new MockUserFriendRepo();
        //     var controller = new UserFriendController(mockUserFriendRepo);
        //     var tmp = new UserFriend();
        //     tmp.userFollowerId = 4;
        //     tmp.userFollowedId = 5;

        //     // Act
        //     var result = controller.createUserFriend(tmp).Result as OkObjectResult;
        //     var tmpList = mockUserFriendRepo2.AddUserFriendById(tmp.userFollowerId,
        //                                                         tmp.userFollowedId).Select(x => x.AsDto());

        //     // Assert
        //     result.Value.Should().BeEquivalentTo(tmpList,
        //                                          options => options.ComparingByMembers<UserFriendDto>());
        // }

        // [Fact]
        // public void removeUserFriend()
        // {
        //     // Arrange
        //     var repositoryStub = new Mock<IUserFriendRepo>();
        //     var mockUserFriendRepo = new MockUserFriendRepo();
        //     repositoryStub.Setup(repo => repo.GetUserFriends()).Returns(mockUserFriendRepo.GetUserFriends());
        //     var mockUserFriendRepo2 = new MockUserFriendRepo();
        //     var controller = new UserFriendController(mockUserFriendRepo);

        //     // Act
        //     var result = controller.removeUserFriend(1, 3).Result as OkObjectResult;
        //     var tmpList = mockUserFriendRepo2.RemoveUserFriendById(1, 3).Select(x => x.AsDto());

        //     // Assert
        //     result.Value.Should().BeEquivalentTo(tmpList,
        //                                          options => options.ComparingByMembers<UserFriendDto>());
        // }
    }
}
