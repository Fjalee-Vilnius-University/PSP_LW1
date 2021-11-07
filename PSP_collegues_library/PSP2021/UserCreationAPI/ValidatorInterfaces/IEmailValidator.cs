namespace UserCreationApi
{
    public interface IEmailValidator
    {
        public bool IsValid(string email);
    }
}
