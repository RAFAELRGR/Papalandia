using Microsoft.AspNetCore.Mvc;
using Papalandia.Models;
using Papalandia.Services;


namespace Papalandia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PestsController : ControllerBase
    {
        private readonly IPestsService _pestsService;

        public PestsController(IPestsService pestsService)
        {
            _pestsService = pestsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pests>>> getPests()
        {
            var pests = await _pestsService.getPests();
            return Ok(pests);
        }

        [HttpGet("{PestsId}")]
        public async Task<ActionResult<Pests>> getPest(int PestsId)
        {
            var pest = await _pestsService.getPest(PestsId);
            if (pest == null)
            {
                return NotFound();
            }
            return Ok(pest);
        }

        [HttpPost]
        public async Task<ActionResult<Pests>> createPest(string PestsName, string PestsDescription, int SuppliesId)
        {
            if (string.IsNullOrEmpty(PestsName))
            {
                return BadRequest("El nombre de la plaga es obligatorio.");
            }
            try
            {
                var createdPest = await _pestsService.createPest(PestsName, PestsDescription, SuppliesId);
                if (createdPest == null)
                {
                    return BadRequest("No se pudo crear la plaga.");
                }

                return CreatedAtAction(nameof(getPest), new { PestsId = createdPest.PestsId }, createdPest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la plaga: {ex.Message}. Detalles: {ex.InnerException?.Message}");
            }
        }

        [HttpPut("{PestsId}")]
        public async Task<IActionResult> updatePest(int PestsId, string PestsName = null, string PestsDescription = null, int? SuppliesId = null)
        {
            if (string.IsNullOrEmpty(PestsName))
            {
                return BadRequest("El nombre de la plaga es obligatorio.");
            }
            var updatedPest = await _pestsService.updatePest(PestsId, PestsName, PestsDescription, SuppliesId);
            if (updatedPest == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{PestsId}")]
        public async Task<IActionResult> deletePest(int PestsId)
        {
            var deletedPest = await _pestsService.deletePest(PestsId);
            if (deletedPest == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
