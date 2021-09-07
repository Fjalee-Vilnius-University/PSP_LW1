using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSP_LW1;

namespace PSP_LW1_UnitTests
{
    [TestClass]
    public class MyRegexTests
    {
        readonly MyRegex _myRegex = new MyRegex();

        [TestMethod]
        public void IsHaveAtSign_NoAtSign_Incorrect()
        {
            var str = "str@";

            var result = _myRegex.IsHaveAtSymbol(str);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsHaveAtSign_WithSymbol_Correct()
        {
            var str = "str";

            var result = _myRegex.IsHaveAtSymbol(str);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFirstpecialCharacter_NoSpecialCharacter_Incorrect()
        {
            var str = "str";

            var result = _myRegex.IsFirstSpecialCharacter(str);

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
        public void IsLastSpecialCharacter_NoSpecialCharacter_Incorrect()
        {
            var str = "str";

            var result = _myRegex.IsLastSpecialCharacter(str);

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
        public void IsHaveUppercase_WithUppercase_Correct()
        {
            var str = "Ustr";

            var result = _myRegex.IsHaveUppercase(str);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsHaveUppercase_NoUppercase_Correct()
        {
            var str = "str";

            var result = _myRegex.IsHaveUppercase(str);

            Assert.IsFalse(result);
        }
    }
}
