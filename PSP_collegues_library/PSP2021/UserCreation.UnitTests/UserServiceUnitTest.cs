using AutoFixture.Xunit2;
using Moq;
using UserCreationApi;
using UserCreationApi.BusinessLogic;
using UserCreationApi.Dto;
using Xunit;

namespace UnitTests
{
    public class UserServiceUnitTest
    {
        [Theory]
        [AutoDomainData]
        public void IsValid_Valid_Correct(UserDto user, [Frozen] Mock<IEmailValidator> emailValidatorMock,
            [Frozen] Mock<IPasswordValidator> passwordValidatorMock, [Frozen] Mock<IPhoneValidator> phoneNumberValidatorMock, UserService sut)
        {
            emailValidatorMock
                .Setup(e => e.IsValid(It.IsAny<string>()))
                .Returns(true);
            passwordValidatorMock
                .Setup(p => p.IsValid(It.IsAny<string>()))
                .Returns(true);
            phoneNumberValidatorMock
                .Setup(t => t.IsValid(It.IsAny<string>()))
                .Returns(true);

            var result = sut.IsValid(user);

            Assert.True(result);
        }
    }
}