using AutoMapper;
using Database.Entities;
using Database.Repository;
using System.Collections.Generic;
using UserCreationApi.Dto;

namespace UserCreationApi.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IEmailValidator _emailValidator;
        private readonly IPasswordValidator _passwordValidator;
        private readonly IPhoneValidator _phoneValidator;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IEmailValidator emailValidator, IPasswordValidator passwordValidator, IPhoneValidator phoneValidator,
            IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;

            _emailValidator = emailValidator;
            _passwordValidator = passwordValidator;
            _phoneValidator = phoneValidator;
        }

        public bool IsValid(UserDto user)
        {
            var isValidEmail = _emailValidator.IsValid(user.Email);
            var isValidPassword = _passwordValidator.IsValid(user.Password);
            var isValidPhoneNumber = _phoneValidator.IsValid(user.PhoneNumber);
            return isValidEmail && isValidPassword && isValidPhoneNumber;
        }

        public UserDto DeleteUser(int id)
        {
            var deletedUser = _userRepository.DeleteUser(id);
            return _mapper.Map<UserDto>(deletedUser);
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var allUsers = _userRepository.ReadAllUsers();
            return _mapper.Map<IEnumerable<UserDto>>(allUsers);
        }

        public UserDto GetUser(int id)
        {
            var user = _userRepository.ReadUser(id);
            return _mapper.Map<UserDto>(user);
        }

        public UserDto PostUser(UserDto user)
        {
            var userToCreate = _mapper.Map<User>(user);
            var createdUser = _userRepository.CraeteUser(userToCreate);
            return _mapper.Map<UserDto>(createdUser);
        }

        public UserDto PutUser(UserDto userChanges, int id)
        {
            var mappedUserChanges = _mapper.Map<User>(userChanges);
            var updatedUser = _userRepository.UpdateUser(mappedUserChanges, id);
            return _mapper.Map<UserDto>(updatedUser);
        }
    }
}
