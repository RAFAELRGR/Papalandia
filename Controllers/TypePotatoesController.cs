using Microsoft.AspNetCore.Mvc;
using Papalandia.Models;
using Papalandia.Services;


namespace Papalandia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypePotatoesController : ControllerBase
    {
        private readonly ITypePotatoesService _typePotatoesService;

        public TypePotatoesController(ITypePotatoesService typePotatoesService)
        {
            _typePotatoesService = typePotatoesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TypePotatoes>>> getTypePotatoes()
        {
            var typePotatoes = await _typePotatoesService.getTypePotatoes();
            return Ok(typePotatoes);
        }

        [HttpGet("{TypePotatoesId}")]
        public async Task<ActionResult<TypePotatoes>> getTypePotato(int TypePotatoesId)
        {
            var typePotato = await _typePotatoesService.getTypePotato(TypePotatoesId);
            if (typePotato == null)
            {
                return NotFound();
            }
            return Ok(typePotato);
        }

        [HttpPost]
        public async Task<ActionResult<TypePotatoes>> createTypePotato(string TypeNamePotatoes)
        {
            if (string.IsNullOrEmpty(TypeNamePotatoes))
            {
                return BadRequest("El nombre del tipo de papa es obligatorio.");
            }
            try
            {
                var createdTypePotato = await _typePotatoesService.createTypePotato(TypeNamePotatoes);
                if (createdTypePotato == null)
                {
                    return BadRequest("No se pudo crear el tipo de papa.");
                }

                return CreatedAtAction(nameof(getTypePotato), new { TypePotatoesId = createdTypePotato.TypePotatoesId }, createdTypePotato);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el tipo de papa: {ex.Message}. Detalles: {ex.InnerException?.Message}");
            }

            
        }


        [HttpPut("{TypePotatoesId}")]
        public async Task<IActionResult> updateTypePotato(int TypePotatoesId, string TypeNamePotatoes = null )
        {
            if (string.IsNullOrEmpty(TypeNamePotatoes))
            {
                return BadRequest("El nombre del tipo de papa es obligatorio.");
            }

            var updatedTypePotato = await _typePotatoesService.updateTypePotato(TypePotatoesId, TypeNamePotatoes);
            if (updatedTypePotato == null)
            {
                return NotFound();
            }

            return NoContent();
        }



        [HttpDelete("{TypePotatoesId}")]
        public async Task<IActionResult> deleteTypePotato(int TypePotatoesId)
        {
            var deletedTypePotato = await _typePotatoesService.deleteTypePotato(TypePotatoesId);
            if (deletedTypePotato == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
