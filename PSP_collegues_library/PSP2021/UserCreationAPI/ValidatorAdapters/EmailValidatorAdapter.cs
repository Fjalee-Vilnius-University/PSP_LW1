using PSP;

namespace UserCreationApi.ValidatorAdapters
{
    public class EmailValidatorAdapter : IEmailValidator
    {
        public bool IsValid(string email)
        {
            return EmailValidator.Check(email);
        }
    }
}
