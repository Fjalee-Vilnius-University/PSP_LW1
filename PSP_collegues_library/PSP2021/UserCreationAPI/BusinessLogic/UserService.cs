using AutoMapper;
using Database;
using Database.Entities;
using UserCreationApi.Dto;

namespace UserCreationApi.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IEmailValidator _emailValidator;
        private readonly IPasswordValidator _passwordValidator;
        private readonly IPhoneValidator _phoneValidator;
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(IEmailValidator emailValidator, IPasswordValidator passwordValidator, IPhoneValidator phoneValidator
            , AppDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;

            _emailValidator = emailValidator;
            _passwordValidator = passwordValidator;
            _phoneValidator = phoneValidator;
        }

        public User AddUser(UserDto user)
        {
            var addedUser = _dbContext.Users.Add(_mapper.Map<User>(user));
            return addedUser.Entity;
        }

        public User GetUser(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public User DeleteUser(int id)
        {
            var user = new User() { Id = id };
            _dbContext.Users.Attach(user);

            var removedUser = _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return removedUser.Entity;
        }

        public User UpdateUser(int id, UserDto newUser)
        {
            var userToUpdate = _dbContext.Users.Find(id);
            _dbContext.Users.Attach(userToUpdate);


            if (userToUpdate == null)
            {
                return null;
            }

            userToUpdate.Name = newUser.Name;
            userToUpdate.Surname = newUser.Surname;
            userToUpdate.PhoneNumber = newUser.PhoneNumber;
            userToUpdate.Email = newUser.Email;
            userToUpdate.Address = newUser.Address;
            userToUpdate.Password = newUser.Password;

            _dbContext.SaveChanges();

            return userToUpdate;
        }

        public bool IsValid(UserDto user)
        {
            var isValidEmail = _emailValidator.IsValid(user.Email);
            var isValidPassword = _passwordValidator.IsValid(user.Password);
            var isValidPhoneNumber = _phoneValidator.IsValid(user.PhoneNumber);
            return isValidEmail && isValidPassword && isValidPhoneNumber;
        }
    }
}
