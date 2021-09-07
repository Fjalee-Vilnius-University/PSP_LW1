using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSP_LW1;

namespace PSP_LW1_UnitTests
{
    [TestClass]
    public class MyRegexTests
    {
        readonly MyRegex _myRegex = new MyRegex();
        readonly string _simpleStr = "str";

        [TestMethod]
        public void IsHaveAtSign_WithSymbol_Correct()
        {
            var str = "str@";

            var result = _myRegex.IsHaveAtSymbol(str);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsHaveAtSign_NoAtSign_Incorrect()
        {
            var result = _myRegex.IsHaveAtSymbol(_simpleStr);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsFirstSpecialCharacter_HasSpecialCharacter_Correct()
        {
            var str = ".str";

            var result = _myRegex.IsFirstSpecialCharacter(str);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFirstpecialCharacter_NoSpecialCharacter_Incorrect()
        {
            var result = _myRegex.IsFirstSpecialCharacter(_simpleStr);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsLastSpecialCharacter_HasSpecialCharacter_Correct()
        {
            var str = "str.";

            var result = _myRegex.IsLastSpecialCharacter(str);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsLastSpecialCharacter_NoSpecialCharacter_Incorrect()
        {
            var result = _myRegex.IsLastSpecialCharacter(_simpleStr);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsHaveUppercase_WithUppercase_Correct()
        {
            var str = "Ustr";

            var result = _myRegex.IsHaveUppercase(str);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsHaveUppercase_NoUppercase_Correct()
        {
            var result = _myRegex.IsHaveUppercase(_simpleStr);

            Assert.IsFalse(result);
        }
    }
}
