using Database.Entities;
using UserCreationApi.Dto;

namespace UserCreationApi.BusinessLogic
{
    public interface IUserService
    {
        public User AddUser(UserDto user);
        public bool IsValid(UserDto user);
    }
}
