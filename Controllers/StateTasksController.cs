using Microsoft.AspNetCore.Mvc;
using Papalandia.Models;
using Papalandia.Services;


namespace Papalandia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateTasksController : ControllerBase
    {
        private readonly IStateTasksService _stateTasksService;

        public StateTasksController(IStateTasksService stateTasksService)
        {
            _stateTasksService = stateTasksService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StateTasks>>> getStateTasks()
        {
            var stateTasks = await _stateTasksService.getStateTasks();
            return Ok(stateTasks);
        }

        [HttpGet("{StateTasksId}")]
        public async Task<ActionResult<StateTasks>> getStateTask(int StateTasksId)
        {
            var stateTask = await _stateTasksService.getStateTask(StateTasksId);
            if (stateTask == null)
            {
                return NotFound();
            }
            return Ok(stateTask);
        }

        [HttpPost]
        public async Task<ActionResult<StateTasks>> CreateStateTask(string stateTaskName)
        {
            try
            {
                var createdStateTask = await _stateTasksService.createStateTask(stateTaskName);
                return CreatedAtAction(nameof(getStateTask), new { StateTasksId = createdStateTask.StateTasksId }, createdStateTask);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la tarea de estado: {ex.Message}. Detalles: {ex.InnerException?.Message}");
            }
        }

        [HttpPut("{StateTasksId}")]
        public async Task<IActionResult> UpdateStateTask(int StateTasksId, string stateTaskName)
        {
            var updatedStateTask = await _stateTasksService.updateStateTask(StateTasksId, stateTaskName);
            if (updatedStateTask == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{StateTasksId}")]
        public async Task<IActionResult> deleteStateTask(int StateTasksId)
        {
            var deletedStateTask = await _stateTasksService.deleteStateTask(StateTasksId);
            if (deletedStateTask == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
