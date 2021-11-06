using Database.Entities;
using UserCreationApi.Dto;

namespace UserCreationApi.BusinessLogic
{
    public interface IUserService
    {
        public User AddUser(UserDto user);
        public User GetUser(int id);
        public User DeleteUser(int id);
        public User UpdateUser(int id, UserDto user);

        public bool IsValid(UserDto user);
    }
}
