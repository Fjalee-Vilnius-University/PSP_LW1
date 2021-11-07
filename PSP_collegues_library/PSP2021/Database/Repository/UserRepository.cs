using Database.Entities;
using System.Collections.Generic;

namespace Database.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User CraeteUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return user;
        }

        public IEnumerable<User> ReadAllUsers()
        {
            return _context.Users;
        }

        public User ReadUser(int id)
        {
            return _context.Users.Find(id);
        }

        public User UpdateUser(User newUser)
        {
            _context.Users.Attach(newUser);

            newUser.Name = newUser.Name;
            newUser.Surname = newUser.Surname;
            newUser.PhoneNumber = newUser.PhoneNumber;
            newUser.Email = newUser.Email;
            newUser.Address = newUser.Address;
            newUser.Password = newUser.Password;

            _context.SaveChanges();

            return newUser;
        }
    }
}
