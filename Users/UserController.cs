using Microsoft.AspNetCore.Mvc;
using MyApi.Business.UserServ;

using MyApi.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApi.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }



        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var newUser = await _userService.PostUser(user);
            if (newUser == null)
            {
                return Conflict(new { message = "Kullanıcı adı daha önce alınmış!" });
            }
            return CreatedAtAction("GetUser", new { id = newUser.id }, newUser);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(User loginUser)
        {
            var user = await _userService.Login(loginUser);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }

        [HttpPost("forgot")]
        public async Task<ActionResult<User>> Forgot(User forgotUser)
        {
            var user = await _userService.Forgot(forgotUser);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }


        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetUsersCount()
        {
            var count = await _userService.GetUsersCount();
            return Ok(count);
        }
   




        [HttpPut("userr/{id}")]
        public async Task<IActionResult> UpdateUserr(int id, User updatedUserr)
        {
            var result = await _userService.UpdateUserr(id, updatedUserr);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}