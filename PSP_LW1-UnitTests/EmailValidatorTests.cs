using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSP_LW1;
using System.Collections.Generic;

namespace PSP_LW1_UnitTests
{
    [TestClass]
    public class EmailValidatorTests
    {
        readonly List<char> _specialChars = new List<char>(){
                '&', '!', '#', '$', '%', '\'', '*', '+', '-', '/', '=', '?', '^', '_', '`', '{', '|', '}', '~', '.'
            };
        readonly List<char> _invalidChars = new List<char>(){
                '£', '¢', '¡'
            };
        readonly string _simpleStr = "str";

        readonly EmailValidator _emailValidator;

        public EmailValidatorTests()
        {
            _emailValidator = new EmailValidator(_specialChars, _invalidChars);
        }

        [TestMethod]
        public void IsFirstSpecialCharacter_HasSpecialCharacter_Correct()
        {
            var str = "%" + _simpleStr;

            var result = _emailValidator.IsFirstSpecialCharacter(str);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFirstpecialCharacter_NoSpecialCharacter_Incorrect()
        {
            var result = _emailValidator.IsFirstSpecialCharacter(_simpleStr);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsLastSpecialCharacter_HasSpecialCharacter_Correct()
        {
            var str = _simpleStr + "%";

            var result = _emailValidator.IsLastSpecialCharacter(str);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsLastSpecialCharacter_NoSpecialCharacter_Incorrect()
        {
            var result = _emailValidator.IsLastSpecialCharacter(_simpleStr);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsHaveTwoOrMoreConsecutiveSpecialChars_HasTwo_Incorrect()
        {
            var str = _simpleStr + "%*";

            var result = _emailValidator.IsHaveTwoOrMoreConsecutiveSpecialChars(str);

            Assert.IsTrue(result);
        }
    }
}
