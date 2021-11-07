using System.Collections.Generic;
using UserCreationApi.Dto;

namespace UserCreationApi.BusinessLogic
{
    public interface IUserService
    {
        public bool IsValid(UserDto user);
        public UserDto GetUser(int id);
        public IEnumerable<UserDto> GetAllUsers();
        public UserDto PostUser(UserDto user);
        public UserDto PutUser(UserDto userChanges, int id);
        public UserDto DeleteUser(int id);

    }
}
