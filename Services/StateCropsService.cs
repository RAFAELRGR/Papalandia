using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface IStateCropsService
    {
        Task<List<StateCrops>> getStateCrops();
        Task<StateCrops> getStateCrop(int StateCropsId);
        Task<StateCrops> createStateCrop(string StateCrop);
        Task<StateCrops> updateStateCrop(int StateCropsId, string? StateCrop = null);
        Task<StateCrops> deleteStateCrop(int StateCropsId);
    }

    public class StateCropsService : IStateCropsService
    {
        private readonly IStateCropsRepository _StateCropsRepository;

        public StateCropsService(IStateCropsRepository StateCropsRepository)
        {

            _StateCropsRepository = StateCropsRepository;

        }

        public async Task<StateCrops> createStateCrop(string StateCrop)
        {
            return await _StateCropsRepository.createStateCrop(StateCrop);
        }

        public async Task<StateCrops> deleteStateCrop(int StateCropsId)
        {
            return await _StateCropsRepository.deleteStateCrop(StateCropsId);
        }

        public async Task<StateCrops> getStateCrop(int StateCropsId)
        {
            return await _StateCropsRepository.getStateCrop(StateCropsId);
        }

        public async Task<List<StateCrops>> getStateCrops()
        {
            return await _StateCropsRepository.getStateCrops();
        }

        public async Task<StateCrops> updateStateCrop(int StateCropsId, string? StateCrop = null)
        {
            StateCrops statecrops = await _StateCropsRepository.getStateCrop(StateCropsId);

            if (statecrops == null)
            {
                return null;
            }
                if (StateCrop != null)
            {
                statecrops.StateCrop = StateCrop;
            }
            return await _StateCropsRepository.updateStateCrop(statecrops);
        }
    }

}
