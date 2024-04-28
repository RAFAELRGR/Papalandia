using Microsoft.AspNetCore.Mvc;
using Papalandia.Models;
using Papalandia.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Papalandia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateGamesController : ControllerBase
    {
        private readonly IStateGameService _stateGameService;

        public StateGamesController(IStateGameService stateGameService)
        {
            _stateGameService = stateGameService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StateGames>>> getStateGames()
        {
            var stateGames = await _stateGameService.getStateGames();
            return Ok(stateGames);
        }

        [HttpGet("{StateGameId}")]
        public async Task<ActionResult<StateGames>> getStateGame(int StateGameId)
        {
            var stateGame = await _stateGameService.getStateGame(StateGameId);
            if (stateGame == null)
            {
                return NotFound();
            }
            return Ok(stateGame);
        }

        [HttpPost]
        public async Task<ActionResult<StateGames>> createStateGame(int PlayerLocationId)
        {
            if ( PlayerLocationId <= 0 )
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }
            try
            {
                var createdStateGame = await _stateGameService.createStateGame(PlayerLocationId);
                if (createdStateGame == null)
                {
                    return BadRequest("No se pudo crear la papa.");
                }

                return CreatedAtAction(nameof(getStateGame), new { StateGameId = createdStateGame.StateGameId }, createdStateGame);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la papa: {ex.Message}");
            }
        }

        [HttpPut("{StateGameId}")]
        public async Task<IActionResult> updateStateGame(int StateGameId, int? PlayerLocationId)
        {
            if (PlayerLocationId <= 0)
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }
            var updatedStateGame = await _stateGameService.updateStateGame(StateGameId, PlayerLocationId);
            if (updatedStateGame == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{StateGameId}")]
        public async Task<IActionResult> deleteStateGame(int StateGameId)
        {
            var deletedStateGame = await _stateGameService.deleteStateGame(StateGameId);
            if (deletedStateGame == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

