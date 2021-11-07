using Database.Entities;
using System.Collections.Generic;

namespace Database.Repository
{
    public interface IUserRepository
    {
        User CraeteUser(User user);
        User ReadUser(int id);
        IEnumerable<User> ReadAllUsers();
        User UpdateUser(User user);
        User DeleteUser(int id);
    }
}
