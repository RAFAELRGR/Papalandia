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
    public class TypeSuppliesController : ControllerBase
    {
        private readonly ITypeSuppliesService _typeSuppliesService;

        public TypeSuppliesController(ITypeSuppliesService typeSuppliesService)
        {
            _typeSuppliesService = typeSuppliesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TypeSupplies>>> getTypeSupplies()
        {
            var typeSupplies = await _typeSuppliesService.getTypeSupplies();
            return Ok(typeSupplies);
        }

        [HttpGet("{TypeSuppliesId}")]
        public async Task<ActionResult<TypeSupplies>> getTypeSupplie(int TypeSuppliesId)
        {
            var typeSupplie = await _typeSuppliesService.getTypeSupplie(TypeSuppliesId);
            if (typeSupplie == null)
            {
                return NotFound();
            }
            return Ok(typeSupplie);
        }

        [HttpPost]
        public async Task<ActionResult<TypeSupplies>> createTypeSupplie(string nameTypeSupplies)
        {
            if (string.IsNullOrEmpty(nameTypeSupplies))
            {
                return BadRequest("El nombre del tipo de suministro es obligatorio.");
            }

            try
            {
                var createdTypeSupplie = await _typeSuppliesService.createTypeSupplie(nameTypeSupplies);
                if (createdTypeSupplie == null)
                {
                    return BadRequest("No se pudo crear el tipo de suministro.");
                }

                return CreatedAtAction(nameof(getTypeSupplie), new { TypeSuppliesId = createdTypeSupplie.TypeSuppliesId }, createdTypeSupplie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el tipo de suministro: {ex.Message}. Detalles: {ex.InnerException?.Message}");
            }
        }

        [HttpPut("{TypeSuppliesId}")]
        public async Task<IActionResult> updateTypeSupplie(int TypeSuppliesId, string NameTypeSupplies = null)
        {

            var updatedTypeSupplie = await _typeSuppliesService.updateTypeSupplie(TypeSuppliesId, NameTypeSupplies);
            if (updatedTypeSupplie == null)
            {
                return NotFound();
            }

            return NoContent();
        }



        [HttpDelete("{TypeSuppliesId}")]
        public async Task<IActionResult> deleteTypeSupplie(int TypeSuppliesId)
        {
            var deletedTypeSupplie = await _typeSuppliesService.deleteTypeSupplie(TypeSuppliesId);
            if (deletedTypeSupplie == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
