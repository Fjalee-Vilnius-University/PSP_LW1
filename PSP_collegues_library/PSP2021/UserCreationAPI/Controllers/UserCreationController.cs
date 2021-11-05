using Microsoft.AspNetCore.Mvc;
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

        public UserCreationController(IEmailValidator emailValidator, IPasswordValidator passwordValidator, IPhoneValidator phoneValidator)
        {
            _emailValidator = emailValidator;
            _passwordValidator = passwordValidator;
            _phoneValidator = phoneValidator;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto user)
        {
            if (_emailValidator.IsValid(user.Email)
                && _passwordValidator.IsValid(user.Password)
                && _phoneValidator.IsValid(user.PhoneNumber))
            {
                //add to db

                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
