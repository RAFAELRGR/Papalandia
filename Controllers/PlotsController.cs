using Microsoft.AspNetCore.Mvc;
using Papalandia.Models;
using Papalandia.Services;


namespace Papalandia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlotsController : ControllerBase
    {
        private readonly IPlotsService _plotsService;

        public PlotsController(IPlotsService plotsService)
        {
            _plotsService = plotsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Plots>>> getPlots()
        {
            var plots = await _plotsService.getPlots();
            return Ok(plots);
        }

        [HttpGet("{PlotsId}")]
        public async Task<ActionResult<Plots>> getPlot(int PlotsId)
        {
            var plot = await _plotsService.getPlot(PlotsId);
            if (plot == null)
            {
                return NotFound();
            }
            return Ok(plot);
        }

        [HttpPost]
        public async Task<ActionResult<Plots>> createPlot(decimal PlotsSize, decimal Longitude, decimal Latitude)
        {
            if (PlotsSize <= 0 || Longitude <= 0 || Latitude <= 0)
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }
            try
            {
                var createdPlot = await _plotsService.createPlot(PlotsSize, Longitude, Latitude);
                return CreatedAtAction(nameof(getPlot), new { PlotsId = createdPlot.PlotsId }, createdPlot);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la parcela: {ex.Message}. Detalles: {ex.InnerException?.Message}");
            }
        }

        [HttpPut("{PlotsId}")]
        public async Task<IActionResult> updatePlot(int PlotsId, decimal? PlotsSize = null, decimal? Longitude = null, decimal? Latitude = null)
        {
            if (PlotsSize <= 0 || Longitude <= 0 || Latitude <= 0)
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }
            var updatedPlot = await _plotsService.updatePlot(PlotsId, PlotsSize, Longitude, Latitude);
            if (updatedPlot == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{PlotsId}")]
        public async Task<IActionResult> deletePlot(int PlotsId)
        {
            var deletedPlot = await _plotsService.deletePlot(PlotsId);
            if (deletedPlot == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
