namespace UserCreationApi
{
    public interface IPasswordValidator
    {
        public bool IsValid(string password);
    }
}
