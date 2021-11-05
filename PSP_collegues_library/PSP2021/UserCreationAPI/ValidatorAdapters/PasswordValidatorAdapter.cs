using PSP;

namespace UserCreationApi.ValidatorAdapters
{
    public class PasswordValidatorAdapter : IPasswordValidator
    {
        public bool IsValid(string password)
        {
            return PasswordChecker.Check(password);
        }

    }
}
