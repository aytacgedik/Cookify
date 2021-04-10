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
    public class UserFriendDtoComparer : IEqualityComparer<UserFriendDto>
    {
        public bool Equals(UserFriendDto x, UserFriendDto y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            bool equals = (x.userFollowedId == y.userFollowedId && x.userFollowerId == y.userFollowerId);
            return equals;
        }

        public int GetHashCode(UserFriendDto obj)
        {
            if (obj == null)
            {
                return int.MinValue;
            }
            int hash = 1;
            hash = hash + obj.userFollowedId.GetHashCode();
            hash = hash + obj.userFollowerId.GetHashCode();
            return hash;
        }
    }


    public class UserFriendControllerTests
    {
        [Fact]
        public void createUserFriend_Test()
        {
            // Arrange
            var repositoryStub = new Mock<IUserFriendRepo>();
            var mockUserFriendRepo = new MockUserFriendRepo();
            repositoryStub.Setup(repo => repo.GetUserFriends()).Returns(mockUserFriendRepo.GetUserFriends());
            var controller = new UserFriendController(mockUserFriendRepo);
            var tmp = new UserFriend();
            tmp.userFollowerId = 4;
            tmp.userFollowedId = 5;

            // Act
            var result = controller.createUserFriend(tmp).Result as OkObjectResult;
            var tmpList = mockUserFriendRepo.AddUserFriendById(tmp.userFollowerId,
                                                               tmp.userFollowedId).Select(x => x.AsDto()).ToList();
            var areEqual = Enumerable.SequenceEqual(tmpList,
                                                    (IEnumerable<UserFriendDto>)result.Value,
                                                    new UserFriendDtoComparer());

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void removeUserFriend()
        {
            // Arrange
            var repositoryStub = new Mock<IUserFriendRepo>();
            var mockUserFriendRepo = new MockUserFriendRepo();
            repositoryStub.Setup(repo => repo.GetUserFriends()).Returns(mockUserFriendRepo.GetUserFriends());
            var controller = new UserFriendController(mockUserFriendRepo);

            // Act
            var result = controller.removeUserFriend(1, 3).Result as OkObjectResult;
            var tmpList = mockUserFriendRepo.RemoveUserFriendById(1, 3).Select(x => x.AsDto()).ToList();
            var areEqual = Enumerable.SequenceEqual(tmpList,
                                                    (IEnumerable<UserFriendDto>)result.Value,
                                                    new UserFriendDtoComparer());

            // Assert
            Assert.True(areEqual);
        }
    }
}