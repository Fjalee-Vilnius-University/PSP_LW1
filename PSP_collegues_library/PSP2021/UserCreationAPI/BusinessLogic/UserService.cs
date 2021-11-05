using AutoMapper;
using Database;
using Database.Entities;
using System.Linq;
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

        public bool AddUser(UserDto user)
        {
            if (_emailValidator.IsValid(user.Email)
                && _passwordValidator.IsValid(user.Password)
                && _phoneValidator.IsValid(user.PhoneNumber))
            {
                _dbContext.Users.Add(_mapper.Map<User>(user));
                _dbContext.Users.Add(_mapper.Map<User>(user));
                _dbContext.Users.Select(x => x).ToList();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
