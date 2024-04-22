
using Microsoft.AspNetCore.Mvc;
using Papalandia.Models;
using Papalandia.Services;

namespace Papalandia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PotatoesController : ControllerBase
    {
        private readonly IPotatoesService _potatoesService;

        public PotatoesController(IPotatoesService potatoesService)
        {
            _potatoesService = potatoesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Potatoes>>> getPotatoes()
        {
            var potatoes = await _potatoesService.getPotatoes();
            return Ok(potatoes);
        }

        [HttpGet("{PotatoesId}")]
        public async Task<ActionResult<Potatoes>> getPotato(int PotatoesId)
        {
            var potato = await _potatoesService.getPotato(PotatoesId);
            if (potato == null)
            {
                return NotFound();
            }
            return Ok(potato);
        }

        [HttpPost]
        public async Task<ActionResult<Potatoes>> createPotato(string PotatoesName, string Description, decimal TimeGrowth, int TypePotatoesId)
        {
            // Validar la entrada
            if (string.IsNullOrEmpty(PotatoesName) || string.IsNullOrEmpty(Description) || TimeGrowth <= 0 || TypePotatoesId <= 0)
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }

            try
            {
                var createdPotato = await _potatoesService.createPotato(PotatoesName, Description, TimeGrowth, TypePotatoesId);
                if (createdPotato == null)
                {
                    return BadRequest("No se pudo crear la papa.");
                }

                return CreatedAtAction(nameof(getPotatoes), new { PotatoesId = createdPotato.PotatoesId }, createdPotato);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la papa: {ex.Message}");
            }
        }


        [HttpPut("{PotatoesId}")]
        public async Task<IActionResult> updatePotato(int PotatoesId, string PotatoesName = null, string Description = null, decimal TimeGrowth = 0, int? TypePotatoesId = null)
        {
            var updatedPotato = await _potatoesService.updatePotato(PotatoesId, PotatoesName, Description, TimeGrowth, TypePotatoesId);
            if (updatedPotato == null)
            {
                return NotFound();
            }

            return NoContent();
        }



        [HttpDelete("{PotatoesId}")]
        public async Task<IActionResult> Delete(int PotatoesId)
        {
            var deletedPotato = await _potatoesService.deletePotato(PotatoesId);
            if (deletedPotato == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
