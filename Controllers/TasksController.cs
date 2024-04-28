using Microsoft.AspNetCore.Mvc;
using Papalandia.Models;
using Papalandia.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Papalandia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tasks>>> getTasks()
        {
            var tasks = await _tasksService.getTasks();
            return Ok(tasks);
        }

        [HttpGet("{TasksId}")]
        public async Task<ActionResult<Tasks>> GetTask(int TasksId)
        {
            var task = await _tasksService.getTask(TasksId);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<Tasks>> createTask(int CropsId, string Description, string DateTask, int StateTasksId, int UserId)
        {
            if (CropsId <= 0 || string.IsNullOrEmpty(Description) || string.IsNullOrEmpty(Description) || string.IsNullOrEmpty(DateTask)|| StateTasksId <= 0 || UserId <= 0)
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }
            try
            {
                DateOnly parsedDateTask = DateOnly.Parse(DateTask);

                var createdTask = await _tasksService.createTask(CropsId, Description, parsedDateTask, StateTasksId, UserId);
                return CreatedAtAction(nameof(getTasks), new { TasksId = createdTask.TasksId }, createdTask);
            }
            catch (FormatException)
            {
                return BadRequest("El formato de fecha proporcionado no es válido dd/MM/yyyy.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la tarea: {ex.Message}");
            }
        }

        [HttpPut("{TasksId}")]
        public async Task<ActionResult<Tasks>> updateTask(int TasksId, int? CropsId = null, string Description = null, string DateTask = null, int? StateTasksId = null, int? UserId = null)
        {
            if (CropsId <= 0 || string.IsNullOrEmpty(Description) || string.IsNullOrEmpty(Description) || string.IsNullOrEmpty(DateTask) || StateTasksId <= 0 || UserId <= 0)
            {
                return BadRequest("Todos los campos son obligatorios y deben tener valores válidos.");
            }
            DateOnly? parsedDate = null;

            if (DateTask != null)
            {
                if (!DateOnly.TryParseExact(DateTask, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var tempParsedDate))
                {
                    return BadRequest("Formato de fecha no válido. Utilice el formato dd-MM-yyyy.");
                }
                parsedDate = tempParsedDate;
            }
            var updatedTask = await _tasksService.updateTask(TasksId, CropsId, Description, parsedDate, StateTasksId, UserId);
            if (updatedTask == null)
            {
                return NotFound();
            }
            return Ok(updatedTask);
        }


        [HttpDelete("{TasksId}")]
        public async Task<IActionResult> deleteTask(int TasksId)
        {
            var deletedTask = await _tasksService.deleteTask(TasksId);
            if (deletedTask == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
