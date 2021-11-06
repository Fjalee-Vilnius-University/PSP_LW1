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
        [InlineAutoMoqData(true, true, true)]
        [InlineAutoMoqData(false, true, true)]
        [InlineAutoMoqData(true, false, true)]
        [InlineAutoMoqData(true, true, false)]
        public void IsValid_Valid_Correct(bool isValidEmail, bool isValidPassword, bool isValidPhoneNumber, UserDto user, [Frozen] Mock<IEmailValidator> emailValidatorMock,
            [Frozen] Mock<IPasswordValidator> passwordValidatorMock, [Frozen] Mock<IPhoneValidator> phoneNumberValidatorMock, UserService sut)
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

            var expectedResult = isValidEmail && isValidPassword && isValidPhoneNumber;

            Assert.Equal(result, expectedResult);
        }
    }
}