using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface IPestsService
    {
        Task<List<Pests>> getPests();
        Task<Pests> getPest(int PestsId);
        Task<Pests> createPest(string PestsName, string PestsDescription, int SuppliesId);
        Task<Pests> updatePest(int PestsId, string? PestsName=null, string? PestsDescription=null, int? SuppliesId=null);
        Task<Pests> deletePest(int PestsId);
    }

    public class PestsService : IPestsService
    {

        private readonly IPestsRepository _pestsRepository;

        public PestsService(IPestsRepository pestsRepository)
        {

            _pestsRepository = pestsRepository;

        }

        public async Task<Pests> createPest(string PestsName, string PestsDescription, int SuppliesId)
        {
            return await _pestsRepository.createPest(PestsName, PestsDescription, SuppliesId);
        }

        public async Task<Pests> getPest(int PestsId)
        {
            return await _pestsRepository.getPest(PestsId);
        }

        public async Task<List<Pests>> getPests()
        {
            return await _pestsRepository.getPests();
        }

        public async Task<Pests> updatePest(int PestsId, string? PestsName = null, string? PestsDescription = null, int? SuppliesId = null)
        {
            Pests pests = await _pestsRepository.getPest(PestsId);

            if (pests == null)
            {
                return null;
            }
            else
                if (PestsName != null)
            {
                pests.PestsName = PestsName;
            }
            if (PestsDescription != null)
            {
                pests.PestsDescription = PestsDescription;
            }
            if (SuppliesId != null)
            {
                pests.SuppliesId = SuppliesId;
            }

            return await _pestsRepository.updatePest(pests);
        }

        public async Task<Pests> deletePest(int PestsId)
        {
            return await _pestsRepository.deletePest(PestsId);
        }

    }
}
