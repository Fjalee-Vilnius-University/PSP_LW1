using Microsoft.AspNetCore.Mvc;
using UserCreationApi.Dto;

namespace UserCreationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserCreationController : ControllerBase
    {
        [HttpGet]
        public void Get()
        {
            var x = 0;
        }

        [HttpPost]
        public void CreateUser([FromBody] UserDto user)
        {
            var x = 0;
        }
    }
}
