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
    public class CropsController : ControllerBase
    {
        private readonly ICropsService _cropsService;

        public CropsController(ICropsService cropsService)
        {
            _cropsService = cropsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Crops>>> GetCrops()
        {
            var crops = await _cropsService.getCrops();
            return Ok(crops);
        }

        [HttpGet("{CropsId}")]
        public async Task<ActionResult<Crops>> GetCrop(int CropsId)
        {
            var crop = await _cropsService.getCrop(CropsId);
            if (crop == null)
            {
                return NotFound();
            }
            return Ok(crop);
        }

        [HttpPost]
        public async Task<ActionResult<Crops>> createCrop(int PlotsId, int PotatoesId, int PestId, string SowingDate, int StateCropsId)
        {
            if (PlotsId <= 0 || PotatoesId <= 0 || PestId <= 0 || string.IsNullOrEmpty(SowingDate) || StateCropsId <= 0)
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }
            try
            {
                DateOnly parsedSowingDate = DateOnly.Parse(SowingDate);
                var createdCrop = await _cropsService.createCrop(PlotsId, PotatoesId, PestId, parsedSowingDate, StateCropsId);
                return CreatedAtAction(nameof(GetCrops), new { CropsId = createdCrop.CropsId }, createdCrop);
            }
            catch (FormatException)
            {
                return BadRequest("El formato de fecha proporcionado no es válido.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear el cultivo: {ex.Message}");
            }
        }

        [HttpPut("{CropsId}")]
        public async Task<IActionResult> updateCrop(int CropsId, int? PlotsId = null, int? PotatoesId = null, int? PestId = null, string SowingDate = null, int? StateCropsId = null)
        {
            if (PlotsId <= 0 || PotatoesId <= 0 || PestId <= 0 || string.IsNullOrEmpty(SowingDate) || StateCropsId <= 0)
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }
            try
            {
                DateOnly? parsedSowingDate = null;
                if (SowingDate != null)
                {
                    parsedSowingDate = DateOnly.Parse(SowingDate);
                }
                var updatedCrop = await _cropsService.updateCrop(CropsId, PlotsId, PotatoesId, PestId, parsedSowingDate, StateCropsId);
                if (updatedCrop == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (FormatException)
            {
                return BadRequest("El formato de fecha proporcionado no es válido.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el cultivo: {ex.Message}");
            }
        }

        [HttpDelete("{CropsId}")]
        public async Task<IActionResult> deleteCrop(int CropsId)
        {
            var deleteCrop = await _cropsService.deleteCrop(CropsId);
            if (deleteCrop == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
