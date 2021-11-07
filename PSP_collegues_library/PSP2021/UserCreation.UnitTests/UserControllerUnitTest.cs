using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using UnitTests;
using UserCreationApi.BusinessLogic;
using UserCreationApi.Dto;
using UserCreationAPI.Controllers;
using Xunit;

namespace UserCreation.UnitTests
{
    public class UserControllerUnitTest
    {
        [Theory]
        [AutoDomainData]
        public void GetAllUser_Ok(IEnumerable<UserDto> users, [Frozen] Mock<IUserService> userService, [Greedy] UserController sut)
        {
            userService
                .Setup(e => e.GetAllUsers())
                .Returns(users);

            var result = sut.GetUser();
            var resultStatusCode = result as OkObjectResult;
            var content = resultStatusCode.Value;

            Assert.NotNull(resultStatusCode);
            Assert.Equal(200, resultStatusCode.StatusCode);
            Assert.Equal(content, users);
        }

        [Theory]
        [AutoDomainData]
        public void GetAllUser_IntertalError([Frozen] Mock<IUserService> userService, [Greedy] UserController sut)
        {
            userService
                .Setup(e => e.GetAllUsers())
                .Throws(new Exception());

            var result = sut.GetUser();
            var resultStatusCode = result as StatusCodeResult;

            Assert.NotNull(resultStatusCode);
            Assert.Equal(500, resultStatusCode.StatusCode);
        }

        [Theory]
        [AutoDomainData]
        public void GetUser_Ok(UserDto user, [Frozen] Mock<IUserService> userService, [Greedy] UserController sut)
        {
            userService
                .Setup(e => e.GetUser(It.IsAny<int>()))
                .Returns(user);

            var result = sut.GetUser(It.IsAny<int>());
            var resultStatusCode = result as OkObjectResult;
            var content = resultStatusCode.Value;

            Assert.NotNull(resultStatusCode);
            Assert.Equal(200, resultStatusCode.StatusCode);
            Assert.Equal(content, user);
        }

        [Theory]
        [AutoDomainData]
        public void GetUser_BadRequest([Frozen] Mock<IUserService> userService, [Greedy] UserController sut)
        {
            userService
                .Setup(e => e.GetUser(It.IsAny<int>()))
                .Returns((UserDto)null);

            var result = sut.GetUser(It.IsAny<int>());
            var resultStatusCode = result as BadRequestResult;

            Assert.NotNull(resultStatusCode);
            Assert.Equal(400, resultStatusCode.StatusCode);
        }

        [Theory]
        [AutoDomainData]
        public void GetUser_IntertalError([Frozen] Mock<IUserService> userService, [Greedy] UserController sut)
        {
            userService
                .Setup(e => e.GetUser(It.IsAny<int>()))
                .Throws(new Exception());

            var result = sut.GetUser(It.IsAny<int>());
            var resultStatusCode = result as StatusCodeResult;

            Assert.NotNull(resultStatusCode);
            Assert.Equal(500, resultStatusCode.StatusCode);
        }

        [Theory]
        [AutoDomainData]
        public void PostUser_Ok(UserDto user, [Frozen] Mock<IUserService> userService, [Greedy] UserController sut)
        {
            userService
                .Setup(e => e.PostUser(It.IsAny<UserDto>()))
                .Returns(user);

            userService
                .Setup(e => e.IsValid(It.IsAny<UserDto>()))
                .Returns(true);

            var result = sut.PostUser(user);
            var resultStatusCode = result as OkObjectResult;
            var content = resultStatusCode.Value;

            Assert.NotNull(resultStatusCode);
            Assert.Equal(200, resultStatusCode.StatusCode);
            Assert.Equal(content, user);
        }

        [Theory]
        [AutoDomainData]
        public void PostUser_BadRequest(UserDto user, [Frozen] Mock<IUserService> userService, [Greedy] UserController sut)
        {
            userService
                .Setup(e => e.PostUser(It.IsAny<UserDto>()))
                .Returns((UserDto)null);

            userService
                .Setup(e => e.IsValid(It.IsAny<UserDto>()))
                .Returns(false);

            var result = sut.PostUser(user);
            var resultStatusCode = result as BadRequestResult;

            Assert.NotNull(resultStatusCode);
            Assert.Equal(400, resultStatusCode.StatusCode);
        }

        [Theory]
        [AutoDomainData]
        public void PostUser_IntertalError(UserDto user, [Frozen] Mock<IUserService> userService, [Greedy] UserController sut)
        {
            userService
                .Setup(e => e.PostUser(It.IsAny<UserDto>()))
                .Throws(new Exception());

            userService
                .Setup(e => e.IsValid(It.IsAny<UserDto>()))
                .Returns(true);

            var result = sut.PostUser(user);
            var resultStatusCode = result as StatusCodeResult;

            Assert.NotNull(resultStatusCode);
            Assert.Equal(500, resultStatusCode.StatusCode);
        }


        [Theory]
        [AutoDomainData]
        public void DeleteUser_Ok(UserDto user, [Frozen] Mock<IUserService> userService, [Greedy] UserController sut)
        {
            userService
                .Setup(e => e.DeleteUser(It.IsAny<int>()))
                .Returns(user);

            var result = sut.DeleteUser(It.IsAny<int>());
            var resultStatusCode = result as OkObjectResult;
            var content = resultStatusCode.Value;

            Assert.NotNull(resultStatusCode);
            Assert.Equal(200, resultStatusCode.StatusCode);
            Assert.Equal(content, user);
        }

        [Theory]
        [AutoDomainData]
        public void DeleteUser_BadRequest([Frozen] Mock<IUserService> userService, [Greedy] UserController sut)
        {
            userService
                .Setup(e => e.DeleteUser(It.IsAny<int>()))
                .Returns((UserDto)null);

            var result = sut.DeleteUser(It.IsAny<int>());
            var resultStatusCode = result as BadRequestResult;

            Assert.NotNull(resultStatusCode);
            Assert.Equal(400, resultStatusCode.StatusCode);
        }

        [Theory]
        [AutoDomainData]
        public void DeleteUser_IntertalError([Frozen] Mock<IUserService> userService, [Greedy] UserController sut)
        {
            userService
                .Setup(e => e.DeleteUser(It.IsAny<int>()))
                .Throws(new Exception());

            var result = sut.DeleteUser(It.IsAny<int>());
            var resultStatusCode = result as StatusCodeResult;

            Assert.NotNull(resultStatusCode);
            Assert.Equal(500, resultStatusCode.StatusCode);
        }
    }
}