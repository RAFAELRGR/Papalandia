using Microsoft.AspNetCore.Mvc;
using Papalandia.Models;
using Papalandia.Services;


namespace Papalandia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolController : ControllerBase
    {
        private readonly IUserRolService _userRolService;

        public UserRolController(IUserRolService userRolService)
        {
            _userRolService = userRolService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserRol>>> getUserRols()
        {
            var userRols = await _userRolService.getUserRols();
            return Ok(userRols);
        }

        [HttpGet("{UserRolId}")]
        public async Task<ActionResult<UserRol>> GetUserRol(int UserRolId)
        {
            var userRol = await _userRolService.getUserRol(UserRolId);
            if (userRol == null)
            {
                return NotFound();
            }
            return Ok(userRol);
        }

        [HttpPost]
        public async Task<ActionResult<UserRol>> createUserRol(string userRolName)
        {
            try
            {
                var createdUserRol = await _userRolService.createUserRol(userRolName);
                return CreatedAtAction(nameof(GetUserRol), new { UserRolId = createdUserRol.UserRolId }, createdUserRol);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el rol de usuario: {ex.Message}. Detalles: {ex.InnerException?.Message}");
            }
        }

        [HttpPut("{UserRolId}")]
        public async Task<IActionResult> updateUserRol(int UserRolId, string userRolName)
        {
            var updatedUserRol = await _userRolService.updateUserRol(UserRolId, userRolName);
            if (updatedUserRol == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{UserRolId}")]
        public async Task<IActionResult> deleteUserRol(int UserRolId)
        {
            var deletedUserRol = await _userRolService.deleteUserRol(UserRolId);
            if (deletedUserRol == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
