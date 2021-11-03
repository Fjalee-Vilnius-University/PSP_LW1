using Microsoft.AspNetCore.Mvc;

namespace UserCreationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserCreationController : ControllerBase
    {
        [HttpGet()]
        public void Test()
        {
            var temp = 0;
        }
    }
}
