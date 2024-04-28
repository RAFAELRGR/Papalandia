using Microsoft.AspNetCore.Mvc;
using Papalandia.Models;
using Papalandia.Services;


namespace Papalandia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerLocationController : ControllerBase
    {
        private readonly IPlayerLocationService _playerLocationService;

        public PlayerLocationController(IPlayerLocationService playerLocationService)
        {
            _playerLocationService = playerLocationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlayerLocation>>> getPlayerLocations()
        {
            var playerLocations = await _playerLocationService.getPlayerLocations();
            return Ok(playerLocations);
        }

        [HttpGet("{PlayerLocationId}")]
        public async Task<ActionResult<PlayerLocation>> getPlayerLocation(int PlayerLocationId)
        {
            var playerLocation = await _playerLocationService.getPlayerLocation(PlayerLocationId);
            if (playerLocation == null)
            {
                return NotFound();
            }
            return Ok(playerLocation);
        }

        [HttpPost]
        public async Task<ActionResult<PlayerLocation>> createPlayerLocation(string CoordinateX, string CoordinateY, string CoordinateZ)
        {
            if (string.IsNullOrEmpty(CoordinateX) || string.IsNullOrEmpty(CoordinateY) || string.IsNullOrEmpty(CoordinateZ) )
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }
            try
            {
                var createdPlayerLocation = await _playerLocationService.createPlayerLocation(CoordinateX, CoordinateY, CoordinateZ);
                if (createdPlayerLocation == null)
                {
                    return BadRequest("No se pudo crear la locacion.");
                }

                return CreatedAtAction(nameof(getPlayerLocations), new { PlayerLocationId = createdPlayerLocation.PlayerLocationId }, createdPlayerLocation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la locacion: {ex.Message}");
            }
        }

        [HttpPut("{PlayerLocationId}")]
        public async Task<IActionResult> updatePlayerLocation(int PlayerLocationId, string CoordinateX = null, string CoordinateY = null, string CoordinateZ = null)
        {
            if (string.IsNullOrEmpty(CoordinateX) || string.IsNullOrEmpty(CoordinateY) || string.IsNullOrEmpty(CoordinateZ))
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }
            var updatedPlayerLocation = await _playerLocationService.updatePlayerLocation(PlayerLocationId, CoordinateX, CoordinateY, CoordinateZ);
            if (updatedPlayerLocation == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{PlayerLocationId}")]
        public async Task<IActionResult> deletePlayerLocation(int PlayerLocationId)
        {
            var deletedPlayerLocation = await _playerLocationService.deletePlayerLocation(PlayerLocationId);
            if (deletedPlayerLocation == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
