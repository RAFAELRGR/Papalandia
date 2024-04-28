using Microsoft.AspNetCore.Mvc;
using Papalandia.Models;
using Papalandia.Services;

namespace Papalandia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementsController : ControllerBase
    {
        private readonly IAchievementsService _achievementsService;

        public AchievementsController(IAchievementsService achievementsService)
        {
            _achievementsService = achievementsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Achievements>>> getAchievements()
        {
            var achievements = await _achievementsService.getAchievements();
            return Ok(achievements);
        }

        [HttpGet("{AchievementsId}")]
        public async Task<ActionResult<Achievements>> getAchievement(int AchievementsId)
        {
            var achievement = await _achievementsService.getAchievement(AchievementsId);
            if (achievement == null)
            {
                return NotFound();
            }
            return Ok(achievement);
        }

        [HttpPost]
        public async Task<ActionResult<Achievements>> createAchievement(string AchievementsName, string AchievementsDescription)
        {
            if (string.IsNullOrEmpty(AchievementsName) || string.IsNullOrEmpty(AchievementsDescription))
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }
            try
            {
                var createdAchievement = await _achievementsService.createAchievement(AchievementsName, AchievementsDescription);
                return CreatedAtAction(nameof(getAchievements), new { AchievementsId = createdAchievement.AchievementsId }, createdAchievement);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el logro: {ex.Message}. Detalles: {ex.InnerException?.Message}");
            }

        }

        [HttpPut("{AchievementsId}")]
        public async Task<IActionResult> updateAchievement(int AchievementsId, string AchievementsName = null, string AchievementsDescription = null)
        {
            if (string.IsNullOrEmpty(AchievementsName) || string.IsNullOrEmpty(AchievementsDescription))
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }
            var updatedAchievement = await _achievementsService.updateAchievement(AchievementsId, AchievementsName, AchievementsDescription);
            if (updatedAchievement == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{AchievementsId}")]
        public async Task<IActionResult> deleteAchievement(int AchievementsId)
        {
            var deletedAchievement = await _achievementsService.deleteAchievement(AchievementsId);
            if (deletedAchievement == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
