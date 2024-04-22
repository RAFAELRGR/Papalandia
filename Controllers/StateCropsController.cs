using Microsoft.AspNetCore.Mvc;
using Papalandia.Models;
using Papalandia.Services;


namespace Papalandia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateCropsController : ControllerBase
    {
        private readonly IStateCropsService _stateCropsService;

        public StateCropsController(IStateCropsService stateCropsService)
        {
            _stateCropsService = stateCropsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StateCrops>>> getStateCrops()
        {
            var stateCrops = await _stateCropsService.getStateCrops();
            return Ok(stateCrops);
        }

        [HttpGet("{StateCropsId}")]
        public async Task<ActionResult<StateCrops>> getStateCrop(int StateCropsId)
        {
            var stateCrop = await _stateCropsService.getStateCrop(StateCropsId);
            if (stateCrop == null)
            {
                return NotFound();
            }
            return Ok(stateCrop);
        }

        [HttpPost]
        public async Task<ActionResult<StateCrops>> CreateStateCrop(string stateCrop)
        {
            try
            {
                var createdStateCrop = await _stateCropsService.createStateCrop(stateCrop);
                return CreatedAtAction(nameof(getStateCrop), new { StateCropsId = createdStateCrop.StateCropsId }, createdStateCrop);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el estado del cultivo: {ex.Message}. Detalles: {ex.InnerException?.Message}");
            }
        }

        [HttpPut("{StateCropsId}")]
        public async Task<IActionResult> updateStateCrop(int StateCropsId, string stateCrop)
        {
            var updatedStateCrop = await _stateCropsService.updateStateCrop(StateCropsId, stateCrop);
            if (updatedStateCrop == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{StateCropsId}")]
        public async Task<IActionResult> deleteStateCrop(int StateCropsId)
        {
            var deletedStateCrop = await _stateCropsService.deleteStateCrop(StateCropsId);
            if (deletedStateCrop == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
