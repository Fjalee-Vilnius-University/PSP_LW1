using UserCreationApi.Dto;

namespace UserCreationApi.BusinessLogic
{
    public interface IUserService
    {
        public void AddUser(UserDto user);
        public bool IsValid(UserDto user);
    }
}
