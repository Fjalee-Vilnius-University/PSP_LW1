using AutoMapper;
using Database;
using Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using UserCreationApi;
using UserCreationApi.Dto;

namespace UserCreationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserCreationController : ControllerBase
    {
        private readonly IEmailValidator _emailValidator;
        private readonly IPasswordValidator _passwordValidator;
        private readonly IPhoneValidator _phoneValidator;
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserCreationController(IEmailValidator emailValidator, IPasswordValidator passwordValidator, IPhoneValidator phoneValidator
            , AppDbContext dbContext, IMapper mapper)
        {
            _emailValidator = emailValidator;
            _passwordValidator = passwordValidator;
            _phoneValidator = phoneValidator;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto user)
        {
            if (_emailValidator.IsValid(user.Email)
                && _passwordValidator.IsValid(user.Password)
                && _phoneValidator.IsValid(user.PhoneNumber))
            {
                try
                {
                    _dbContext.Users.Add(_mapper.Map<User>(user));
                    _dbContext.Users.Add(_mapper.Map<User>(user));
                    _dbContext.Users.Select(x => x).ToList();
                    return Ok(user);
                }
                catch
                {

                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
