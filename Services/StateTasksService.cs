using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface IStateTasksService
    {
        Task<List<StateTasks>> getStateTasks();
        Task<StateTasks> getStateTask(int StateTasksId);
        Task<StateTasks> createStateTask(string StateTasksName);
        Task<StateTasks> updateStateTask(int StateTasksId, string? StateTasksName = null);
        Task<StateTasks> deleteStateTask(int StateTasksId);
    }
    public class StateTasksService : IStateTasksService
    {
        private readonly IStateTasksRepository _StateTasksRepository;

        public StateTasksService(IStateTasksRepository StateTasksRepository)
        {

            _StateTasksRepository = StateTasksRepository;

        }

        public async Task<StateTasks> createStateTask(string StateTasksName)
        {
            return await _StateTasksRepository.createStateTask(StateTasksName);
        }

        public async Task<StateTasks> deleteStateTask(int StateTasksId)
        {
            return await _StateTasksRepository.deleteStateTask(StateTasksId);
        }

        public async Task<StateTasks> getStateTask(int StateTasksId)
        {
            return await _StateTasksRepository.getStateTask(StateTasksId);
        }

        public async Task<List<StateTasks>> getStateTasks()
        {
            return await _StateTasksRepository.getStateTasks();
        }

        public async Task<StateTasks> updateStateTask(int StateTasksId, string? StateTasksName = null)
        {
            StateTasks statetasks = await _StateTasksRepository.getStateTask(StateTasksId);
            if (statetasks == null)
            {
                return null;
            }
            else
                if (StateTasksName != null)
            {
                statetasks.StateTasksName = StateTasksName;
            }
            return await _StateTasksRepository.updateStateTask(statetasks);
        }
    }

}