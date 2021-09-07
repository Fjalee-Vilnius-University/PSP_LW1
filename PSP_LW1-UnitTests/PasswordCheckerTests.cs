using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSP_LW1;

namespace PSP_LW1_UnitTests
{
    [TestClass]
    public class PasswordValidatorTests
    {
        readonly PasswordChecker _passwordChecker = new PasswordChecker();
        readonly string _correctPass = "Password.";

        [TestMethod]
        public void IsValid_Password_Correct()
        {
            var result = _passwordChecker.IsValid(_correctPass, 6);

            Assert.IsTrue(result);
        }
    }
}
