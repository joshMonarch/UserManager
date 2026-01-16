using Microsoft.AspNetCore.Mvc;
using UserManager.Dtos;
using UserManager.Services;

namespace UserManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            if (users == null || users.Count == 0) return NotFound("No users found.");
            return Ok(users);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user is null) return NotFound($"User with ID {id} not found.");
            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto newUser)
        {
            var createdUser = await _userService.CreateUserAsync(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, [FromBody] UpdateUserDto updatedUser)
        {
            var updated = await _userService.UpdateUserByIdAsync(id, updatedUser);
            if (updated is null) return NotFound($"User with ID {id} not found.");
            return Ok(updated);
        }

        //DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var deleted = await _userService.DeleteUserByIdAsync(id);
            if (!deleted) return NotFound($"User with ID {id} not found.");
            return NoContent();
        }
    }
}