using Microsoft.AspNetCore.Mvc;

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
        public void CreateUser()
        {

        }
    }
}
