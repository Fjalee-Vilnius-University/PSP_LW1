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
        [InlineAutoMoqData(true, true, true, true)]
        [InlineAutoMoqData(false, true, true, false)]
        [InlineAutoMoqData(true, false, true, false)]
        [InlineAutoMoqData(true, true, false, false)]
        public void IsValid_Valid(bool isValidEmail, bool isValidPassword, bool isValidPhoneNumber, bool expected, UserDto user,
            [Frozen] Mock<IEmailValidator> emailValidatorMock, [Frozen] Mock<IPasswordValidator> passwordValidatorMock,
            [Frozen] Mock<IPhoneValidator> phoneNumberValidatorMock, UserService sut)
        {
            emailValidatorMock
                .Setup(e => e.IsValid(It.IsAny<string>()))
                .Returns(isValidEmail);
            passwordValidatorMock
                .Setup(p => p.IsValid(It.IsAny<string>()))
                .Returns(isValidPassword);
            phoneNumberValidatorMock
                .Setup(t => t.IsValid(It.IsAny<string>()))
                .Returns(isValidPhoneNumber);

            var result = sut.IsValid(user);

            Assert.Equal(result, expected);
        }
    }
}