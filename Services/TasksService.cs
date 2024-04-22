using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface ITasksService
    {
        Task<List<Tasks>> getTasks();
        Task<Tasks> getTask(int TasksId);
        Task<Tasks> createTask(int CropsId, string Description, DateOnly DateTask, int StateTasksId, int UserId);
        Task<Tasks> updateTask(int TasksId, int? CropsId = null, string? Description = null, DateOnly? DateTask = null, int? StateTasksId = null, int? UserId = null);
        Task<Tasks> deleteTask(int TasksId);
    }

    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _TasksRepository;

        public TasksService(ITasksRepository TasksRepository)
        {

            _TasksRepository = TasksRepository;

        }

        public async Task<Tasks> createTask(int CropsId, string Description, DateOnly DateTask, int StateTasksId, int UserId)
        {
            return await _TasksRepository.createTask(CropsId, Description, DateTask, StateTasksId, UserId);
        }

        public async Task<Tasks> deleteTask(int TasksId)
        {
            return await _TasksRepository.deleteTask(TasksId);
        }

        public async Task<Tasks> getTask(int TasksId)
        {
            return await _TasksRepository.getTask(TasksId);
        }

        public async Task<List<Tasks>> getTasks()
        {
            return await _TasksRepository.getTasks();
        }

        public async Task<Tasks> updateTask(int TasksId, int? CropsId = null, string? Description = null, DateOnly? DateTask = null, int? StateTasksId = null, int? UserId = null)
        {
            Tasks task = await _TasksRepository.getTask(TasksId);
            if (task == null)
            {
                return null;
            }
            else
                if (CropsId != null)
            {
                task.CropsId = CropsId;
            }
            else
                if (Description != null)
            {
                task.Description = Description;
            }
            else
                if (DateTask != null)
            {
                task.DateTask = DateTask;
            }
            else
                if (StateTasksId != null)
            {
                task.StateTasksId = StateTasksId;
            }
            else
                if (UserId != null)
            {
                task.UserId = UserId;
            }


            return await _TasksRepository.updateTask(task);
        }
    }
}
