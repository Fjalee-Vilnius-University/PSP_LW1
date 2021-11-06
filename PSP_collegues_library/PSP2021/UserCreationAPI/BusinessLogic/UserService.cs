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

        public bool IsValid(UserDto user)
        {
            var isValidEmail = _emailValidator.IsValid(user.Email);
            var isValidPassword = _passwordValidator.IsValid(user.Password);
            var isValidPhoneNumber = _phoneValidator.IsValid(user.PhoneNumber);
            return isValidEmail && isValidPassword && isValidPhoneNumber;
        }
    }
}
