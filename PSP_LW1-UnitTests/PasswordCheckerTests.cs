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

        [TestMethod]
        public void IsValid_OneCharTooShort_Incorrect()
        {
            var password = "Pass.";

            var result = _passwordChecker.IsValid(password, 6);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid_ExactRightLength_Correct()
        {
            var password = "Passw.";

            var result = _passwordChecker.IsValid(password, 6);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValid_NoUpperCase_Incorrect()
        {
            var password = "passw.";

            var result = _passwordChecker.IsValid(password, 6);

            Assert.IsTrue(result);
        }
    }
}
