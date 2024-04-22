using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface ICropsService
    {

        Task<List<Crops>> getCrops();
        Task<Crops> getCrop(int CropsId);
        Task<Crops> createCrop(int PlotsId, int PotatoesId, int PestId, DateOnly SowingDate, int StateCropsId);
        Task<Crops> updateCrop(int CropsId, int? PlotsId=null, int? PotatoesId = null, int? PestId = null, DateOnly? SowingDate=null, int? StateCropsId = null);
        Task<Crops> deleteCrop(int CropsId);
    }

    public class CropsService : ICropsService
    {

        private readonly ICropsRepository _cropsRepository;

        public CropsService(ICropsRepository cropsRepository)
        {

            _cropsRepository = cropsRepository;

        }

        public async Task<Crops> createCrop(int PlotsId, int PotatoesId, int PestId, DateOnly SowingDate, int StateCropsId)
        {
            return await _cropsRepository.createCrop(PlotsId, PotatoesId, PestId, SowingDate, StateCropsId);
        }

        public async Task<Crops> getCrop(int CropsId)
        {
            return await _cropsRepository.getCrop(CropsId);
        }

        public async Task<List<Crops>> getCrops()
        {
            return await _cropsRepository.getCrops();
        }

        public async Task<Crops> updateCrop(int CropsId, int? PlotsId = null, int? PotatoesId = null, int? PestId = null, DateOnly? SowingDate = null, int? StateCropsId = null)
        {
            Crops crops = await _cropsRepository.getCrop(CropsId);

            if (crops == null)
            {
                return null;
            }
            else
                if (PlotsId != null)
            {
                crops.PlotsId = PlotsId;
            }
            if (PotatoesId != null)
            {
                crops.PotatoesId = PotatoesId;
            }
            if (PestId != null)
            {
                crops.PestId = PestId;
            }
            if (SowingDate != null)
            {
                crops.SowingDate = SowingDate;
            }
            if (StateCropsId != null)
            {
                crops.StateCropsId = StateCropsId;
            }

            return await _cropsRepository.updateCrop(crops);
        }

        public async Task<Crops> deleteCrop(int CropsId)
        {
            return await _cropsRepository.deleteCrop(CropsId);
        }

    }
}
