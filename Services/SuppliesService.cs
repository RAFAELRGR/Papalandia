using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface ISuppliesService
    {
        Task<List<Supplies>> getSupplies();
        Task<Supplies> getSupply(int SuppliesId);
        Task<Supplies> createSupply(string SuppliesName, string SuppliesDescription, int TypeSuppliesId);
        Task<Supplies> updateSupply(int SuppliesId, string? SuppliesName = null, string? SuppliesDescription = null, int? TypeSuppliesId = null);
        Task<Supplies> deleteSupply(int SuppliesId);
    }
    public class SuppliesService : ISuppliesService
    {
        private readonly ISuppliesRepository _SuppliesRepository;

        public SuppliesService(ISuppliesRepository SuppliesRepository)
        {

            _SuppliesRepository = SuppliesRepository;

        }

        public async Task<Supplies> createSupply(string SuppliesName, string SuppliesDescription, int TypeSuppliesId)
        {
            return await _SuppliesRepository.createSupply(SuppliesName, SuppliesDescription, TypeSuppliesId);
        }

        public async Task<Supplies> deleteSupply(int SuppliesId)
        {
            return await _SuppliesRepository.deleteSupply(SuppliesId);
        }

        public async Task<List<Supplies>> getSupplies()
        {
            return await _SuppliesRepository.getSupplies();
        }

        public async Task<Supplies> getSupply(int SuppliesId)
        {
            return await _SuppliesRepository.getSupply(SuppliesId);
        }

        public async Task<Supplies> updateSupply(int SuppliesId, string? SuppliesName = null, string? SuppliesDescription = null, int? TypeSuppliesId = null)
        {
            Supplies supplies = await _SuppliesRepository.getSupply(SuppliesId);
            if (supplies == null)
            {
                return null;
            }
            else
                if (SuppliesName != null)
            {
                supplies.SuppliesName = SuppliesName;
            }
            else
                if (SuppliesDescription != null)
            {
                supplies.SuppliesDescription = SuppliesDescription;
            }
            else
                if (TypeSuppliesId != null)
            {
                supplies.TypeSuppliesId = TypeSuppliesId;
            }

            return await _SuppliesRepository.updateSupply(supplies);
        }
    }

}
