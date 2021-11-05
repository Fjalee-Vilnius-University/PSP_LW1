namespace UserCreationApi
{
    public interface IPhoneValidator
    {
        public void AddValidationRule(string country, int length, string localStartsWith, string internationalCode);

        public bool IsValid(string number);

        public string LocalToInternationalPrefix(string number);
    }
}
