using Microsoft.AspNetCore.Mvc;
using UserCreationApi.BusinessLogic;
using UserCreationApi.Dto;

namespace UserCreationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserCreationController : ControllerBase
    {
        private IUserService _userService;

        public UserCreationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto user)
        {
            var validated = _userService.IsValid(user);
            if (validated)
            {
                try
                {
                    var addedUser = _userService.AddUser(user);
                    return Ok(addedUser);
                }
                catch
                {
                    return StatusCode(500);

                }
            }
            return BadRequest();
        }
    }
}
