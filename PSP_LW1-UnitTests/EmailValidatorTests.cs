using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PSP_LW1_UnitTests
{
    [TestClass]
    public class EmailValidatorTests
    {
        [TestMethod]
        public void IsFirstSpecialCharacter_HasSpecialCharacter_Correct()
        {
            var str = "%" + _simpleStr;

            var result = _myRegex.IsFirstSpecialCharacter(str, _specialChars);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFirstpecialCharacter_NoSpecialCharacter_Incorrect()
        {
            var result = _myRegex.IsFirstSpecialCharacter(_simpleStr, _specialChars);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsLastSpecialCharacter_HasSpecialCharacter_Correct()
        {
            var str = _simpleStr + "%";

            var result = _myRegex.IsLastSpecialCharacter(str, _specialChars);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsLastSpecialCharacter_NoSpecialCharacter_Incorrect()
        {
            var result = _myRegex.IsLastSpecialCharacter(_simpleStr, _specialChars);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsHaveTwoOrMoreConsecutiveSpecialChars_HasTwo_Incorrect()
        {
            var str = _simpleStr + "%*";

            var result = _myRegex.IsHaveTwoOrMoreConsecutiveSpecialChars(str, _specialChars);

            Assert.IsTrue(result);
        }
    }
}
