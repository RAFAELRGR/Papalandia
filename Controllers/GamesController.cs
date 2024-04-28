using Microsoft.AspNetCore.Mvc;
using Papalandia.Models;
using Papalandia.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Papalandia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGamesService _gamesService;

        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Games>>> getGames()
        {
            var games = await _gamesService.getGames();
            return Ok(games);
        }

        [HttpGet("{GameId}")]
        public async Task<ActionResult<Games>> getGame(int GameId)
        {
            var game = await _gamesService.getGame(GameId);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<Games>> CreateGame(DateTime startGame, DateTime endGame, int userId, int stateGameId)
        {
            if (startGame == null || endGame == null || userId <= 0 || stateGameId <= 0)
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }
            try
            {
                var createdGame = await _gamesService.createGame(startGame, endGame, userId, stateGameId);
                if (createdGame == null)
                {
                    return BadRequest("No se pudo crear el juego.");
                }

                return CreatedAtAction(nameof(getGames), new { GameId = createdGame.GameId }, createdGame);
            }
            catch (Exception ex)
            {
                string errorMessage = "Error al crear el juego.";
                if (ex.InnerException != null)
                {
                    errorMessage += " Detalles: " + ex.InnerException.Message;
                }
                return StatusCode(500, errorMessage);
            }

        }

        [HttpPut("{GameId}")]
        public async Task<IActionResult> updateGame(int GameId, DateTime? startGame = null, DateTime? endGame = null, int? userId = null, int? stateGameId = null)
        {
            if (startGame == null || endGame == null || userId <= 0 || stateGameId <= 0)
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }
            var updatedGame = await _gamesService.updateGame(GameId, startGame, endGame, userId, stateGameId);
            if (updatedGame == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{GameId}")]
        public async Task<IActionResult> deleteGame(int GameId)
        {
            var deletedGame = await _gamesService.deleteGame(GameId);
            if (deletedGame == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
