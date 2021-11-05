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
            try
            {
                var added = _userService.AddUser(user);

                if (added)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return StatusCode(500);

            }
        }
    }
}
