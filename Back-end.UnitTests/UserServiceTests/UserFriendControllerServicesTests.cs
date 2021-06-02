using System;
using Xunit;
using Moq;
using Back_end.Controllers;
using Back_end.Data;
using Back_end.Dtos;
using Back_end.Services;
using Back_end.DatabaseModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FluentAssertions;

namespace Back_end.UnitTests
{
    public class UserFriendControllerTests
    {
        [Fact]
        public void createUserFriend_Test()
        {
            var repoMock = new Mock<IUserFriendRepo>();
            var returnedList = new List<UserFriendDto>{
                new UserFriendDto{
                    userFollowerId = 1,
                    userFollowedId = 2
                },
                new UserFriendDto{
                    userFollowerId = 2,
                    userFollowedId = 1
                }
            };
            var userFriend = new UserFriendDto
            {
                userFollowerId = 1,
                userFollowedId = 2
            };
            repoMock.Setup(p => p.AddUserFriendById(1, 2)).Returns(returnedList);
            var service = new UserFriendServices(repoMock.Object);
            var ctl = new UserFriendController(service);

            // Act
            var result = ctl.createUserFriend(userFriend).Result as OkObjectResult;

            // Assert
            result.Value.Should().BeEquivalentTo(returnedList, options => options.ComparingByMembers<UserFriendDto>());
        }

        [Fact]
        public void removeUserFriend()
        {
            var repoMock = new Mock<IUserFriendRepo>();
            var returnedList = new List<UserFriendDto>
            {
            };
            var userFriend = new UserFriend
            {
                UserFollowerId = 1,
                UserFollowedId = 2
            };
            repoMock.Setup(p => p.RemoveUserFriendById(1, 2)).Returns(returnedList);
            var service = new UserFriendServices(repoMock.Object);
            var ctl = new UserFriendController(service);

            // Act
            var result = ctl.removeUserFriend(1, 2).Result as OkObjectResult;

            // Assert
            result.Value.Should().BeEquivalentTo(returnedList, options => options.ComparingByMembers<UserFriendDto>());
        }
    }
}
