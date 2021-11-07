using PSP;


namespace UserCreationApi.ValidatorAdapters
{
    public class PhoneValidatorAdapter : IPhoneValidator
    {
        public void AddValidationRule(string country, int length, string localStartsWith, string internationalCode)
        {
            PhoneValidator.AddValidationRule(country, length, localStartsWith, internationalCode);
        }

        public bool IsValid(string number)
        {
            return PhoneValidator.Check(number);
        }

        public string LocalToInternationalPrefix(string number)
        {
            return PhoneValidator.ChangePrefix(number);
        }
    }
}
