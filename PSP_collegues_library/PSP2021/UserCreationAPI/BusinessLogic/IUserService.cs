using UserCreationApi.Dto;

namespace UserCreationApi.BusinessLogic
{
    public interface IUserService
    {
        public bool IsValid(UserDto user);
    }
}
