﻿using AutoFixture.Xunit2;
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
    }
}