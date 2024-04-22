using Microsoft.AspNetCore.Mvc;
using Papalandia.Models;
using Papalandia.Services;


namespace Papalandia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliesController : ControllerBase
    {
        private readonly ISuppliesService _suppliesService;

        public SuppliesController(ISuppliesService suppliesService)
        {
            _suppliesService = suppliesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Supplies>>> getSupplies()
        {
            var supplies = await _suppliesService.getSupplies();
            return Ok(supplies);
        }

        [HttpGet("{SuppliesId}")]
        public async Task<ActionResult<Supplies>> getSupply(int SuppliesId)
        {
            var supply = await _suppliesService.getSupply(SuppliesId);
            if (supply == null)
            {
                return NotFound();
            }
            return Ok(supply);
        }

        [HttpPost]
        public async Task<ActionResult<Supplies>> createSupply(string suppliesName, string suppliesDescription, int typeSuppliesId)
        {
            if (string.IsNullOrEmpty(suppliesName) || string.IsNullOrEmpty(suppliesDescription))
            {
                return BadRequest("El nombre y la descripción del suministro son obligatorios.");
            }

            try
            {
                var createdSupply = await _suppliesService.createSupply(suppliesName, suppliesDescription, typeSuppliesId);
                if (createdSupply == null)
                {
                    return BadRequest("No se pudo crear el suministro.");
                }

                return CreatedAtAction(nameof(getSupply), new { SuppliesId = createdSupply.SuppliesId }, createdSupply);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el suministro: {ex.Message}. Detalles: {ex.InnerException?.Message}");
            }
        }

        [HttpPut("{SuppliesId}")]
        public async Task<IActionResult> UpdateSupply(int SuppliesId, string suppliesName = null, string suppliesDescription = null, int? typeSuppliesId = null)
        {
            var updatedSupply = await _suppliesService.updateSupply(SuppliesId, suppliesName, suppliesDescription, typeSuppliesId);
            if (updatedSupply == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{SuppliesId}")]
        public async Task<IActionResult> deleteSupply(int SuppliesId)
        {
            var deletedSupply = await _suppliesService.deleteSupply(SuppliesId);
            if (deletedSupply == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
