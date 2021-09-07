using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSP_LW1;
using System.Collections.Generic;

namespace PSP_LW1_UnitTests
{
    [TestClass]
    public class MyRegexTests
    {
        readonly MyRegex _myRegex = new MyRegex();
        readonly string _simpleStr = "str";
        readonly List<char> _specialChars = new List<char>(){
                '&', '!', '#', '$', '%', '\'', '*', '+', '-', '/', '=', '?', '^', '_', '`', '{', '|', '}', '~', '.'
            };

        [TestMethod]
        public void IsOnlyNumbers_NumberStr_Correct()
        {
            var str = "1234567890";

            var result = _myRegex.IsOnlyNumbers(str);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsOnlyNumbers_NotOnlyNumberStr_Incorrect()
        {
            var str = _simpleStr + "1234567890";

            var result = _myRegex.IsOnlyNumbers(str);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsHaveListedCharacters_Has_Correct()
        {
            var str = _simpleStr + "£";
            var listedChars = new List<char>(){
               '£', '¢', '¡'
            };

            var result = _myRegex.IsHaveListedCharacters(str, listedChars);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsHaveListedCharacters_DoesntHave_Incorrect()
        {
            var listedChars = new List<char>(){
               '£', '¢', '¡'
            };
            var result = _myRegex.IsHaveListedCharacters(_simpleStr, listedChars);

            Assert.IsFalse(result);
        }
    }
}
