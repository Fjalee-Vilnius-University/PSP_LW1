using Database.Repository;
using Microsoft.AspNetCore.Mvc;
using UserCreationApi.BusinessLogic;

namespace UserCreationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public UserController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            try
            {
                var users = _userRepository.ReadAllUsers();
                return Ok(users);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                var user = _userRepository.ReadUser(id);

                if (user != null)
                {
                    return Ok(user);
                }
                return BadRequest();
            }
            catch
            {
                return StatusCode(500);

            }
        }

        //[HttpPost]
        //public IActionResult CreateUser([FromBody] UserDto user)
        //{
        //    var validated = _userService.IsValid(user);
        //    if (validated)
        //    {
        //        try
        //        {
        //            var addedUser = _userService.AddUser(user);
        //            return Ok(addedUser);
        //        }
        //        catch
        //        {
        //            return StatusCode(500);

        //        }
        //    }
        //    return BadRequest();
        //}

        //[HttpDelete]
        //public IActionResult DeleteUser(int id)
        //{
        //    try
        //    {
        //        var user = _userService.DeleteUser(id);

        //        if (user != null)
        //        {
        //            return Ok();
        //        }
        //        return BadRequest();
        //    }
        //    catch
        //    {
        //        return StatusCode(500);

        //    }
        //}

        //[HttpPut]
        //public IActionResult PutUser(int id, [FromBody] UserDto user)
        //{
        //    var validated = _userService.IsValid(user);
        //    if (validated)
        //    {
        //        try
        //        {
        //            var changedUser = _userService.UpdateUser(id, user);

        //            if (changedUser != null)
        //            {
        //                return Ok();
        //            }
        //            return BadRequest();
        //        }
        //        catch
        //        {
        //            return StatusCode(500);

        //        }
        //    }
        //    return BadRequest();
        //}
    }
}
