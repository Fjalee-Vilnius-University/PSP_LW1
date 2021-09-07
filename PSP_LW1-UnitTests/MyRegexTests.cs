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
    }
}
