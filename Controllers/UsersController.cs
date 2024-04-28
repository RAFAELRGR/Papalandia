using Microsoft.AspNetCore.Mvc;
using Papalandia.Models;
using Papalandia.Services;


namespace Papalandia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Users>>> getUsers()
        {
            var users = await _userService.getUsers();
            return Ok(users);
        }

        [HttpGet("{UserId}")]
        public async Task<ActionResult<Users>> getUser(int UserId)
        {
            var user = await _userService.getUser(UserId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<Users>> createUser(string userName, string email, string password, int userRolId)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || userRolId <= 0)
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }
            try
            {
                var createdUser = await _userService.createUser(userName, email, password, userRolId);
                return CreatedAtAction(nameof(getUser), new { UserId = createdUser.UserId }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el usuario: {ex.Message}. Detalles: {ex.InnerException?.Message}");
            }
        }

        [HttpPut("{UserId}")]
        public async Task<IActionResult> updateUser(int UserId, string userName = null, string email = null, string password = null, int? userRolId = null)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || userRolId <= 0)
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }
            var updatedUser = await _userService.updateUser(UserId, userName, email, password, userRolId);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{UserId}")]
        public async Task<IActionResult> deleteUser(int UserId)
        {
            var deletedUser = await _userService.deleteUser(UserId);
            if (deletedUser == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
