using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Papalandia.Models;
using Papalandia.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Papalandia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesAchievementsController : ControllerBase
    {
        private readonly IGamesAchievementsService _gamesAchievementsService;

        public GamesAchievementsController(IGamesAchievementsService gamesAchievementsService)
        {
            _gamesAchievementsService = gamesAchievementsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GamesAchievements>>> GetGamesAchievements()
        {
            var achievements = await _gamesAchievementsService.getGamesAchievements();
            return Ok(achievements);
        }

        [HttpGet("{AchievementUnlockedId}")]
        public async Task<ActionResult<GamesAchievements>> GetGamesAchievement(int AchievementUnlockedId)
        {
            var achievement = await _gamesAchievementsService.getGamesAchievement(AchievementUnlockedId);
            if (achievement == null)
            {
                return NotFound();
            }
            return Ok(achievement);
        }

        [HttpPost]
        public async Task<ActionResult<GamesAchievements>> CreateGamesAchievement(DateTime AchievementUnlocked, int AchievementId, int GameId)
        {
            if (AchievementUnlocked == null || AchievementUnlocked <= DateTime.MinValue || AchievementId == null || AchievementId <= 0 || GameId == null || GameId <= 0)
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }
            try
            {
                var newAchievement = await _gamesAchievementsService.createGamesAchievement(AchievementUnlocked, AchievementId, GameId);
                if (newAchievement == null)
                {
                    return BadRequest("No se pudo crear el logro desbloqueado.");
                }
                return CreatedAtAction(nameof(GetGamesAchievement), new { AchievementUnlockedId = newAchievement.AchievementUnlockedId }, newAchievement);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la papa: {ex.Message}");
            }
        }

        [HttpPut("{AchievementUnlockedId}")]
        public async Task<ActionResult<GamesAchievements>> updateGamesAchievement(int AchievementUnlockedId, DateTime? AchievementUnlocked = null, int? AchievementId = null, int? GameId = null)
        {
            var updatedAchievement = await _gamesAchievementsService.updateGamesAchievement(AchievementUnlockedId, AchievementUnlocked, AchievementId, GameId);
            if (updatedAchievement == null)
            {
                return NotFound();
            }
            return Ok(updatedAchievement);
        }

        [HttpDelete("{AchievementUnlockedId}")]
        public async Task<ActionResult> DeleteGamesAchievement(int AchievementUnlockedId)
        {
            var deletedAchievement = await _gamesAchievementsService.deleteGamesAchievement(AchievementUnlockedId);
            if (deletedAchievement == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

