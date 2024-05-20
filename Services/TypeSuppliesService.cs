using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface ITypeSuppliesService
    {
        Task<List<TypeSupplies>> getTypeSupplies();
        Task<TypeSupplies> getTypeSupplie(int TypeSuppliesId);
        Task<TypeSupplies> createTypeSupplie(string NameTypeSupplies);
        Task<TypeSupplies> updateTypeSupplie(int TypeSuppliesId, string? NameTypeSupplies = null);
        Task<TypeSupplies> deleteTypeSupplie(int TypeSuppliesId);
    }

    public class TypeSuppliesService : ITypeSuppliesService
    {
        private readonly ITypeSuppliesRepository _TypeSuppliesRepository;

        public TypeSuppliesService(ITypeSuppliesRepository TypeSuppliesRepository)
        {

            _TypeSuppliesRepository = TypeSuppliesRepository;

        }
        public async Task<TypeSupplies> createTypeSupplie(string NameTypeSupplies)
        {
            return await _TypeSuppliesRepository.createTypeSupplie(NameTypeSupplies);
        }

        public async Task<TypeSupplies> deleteTypeSupplie(int TypeSuppliesId)
        {
            return await _TypeSuppliesRepository.deleteTypeSupplie(TypeSuppliesId);
        }

        public async Task<TypeSupplies> getTypeSupplie(int TypeSuppliesId)
        {
            return await _TypeSuppliesRepository.getTypeSupplie(TypeSuppliesId);
        }

        public async Task<List<TypeSupplies>> getTypeSupplies()
        {
            return await _TypeSuppliesRepository.getTypeSupplies();
        }

        public async Task<TypeSupplies> updateTypeSupplie(int TypeSuppliesId, string? NameTypeSupplies = null)
        {
            TypeSupplies typesupplies = await _TypeSuppliesRepository.getTypeSupplie(TypeSuppliesId);
            if (typesupplies == null)
            {
                return null;
            }
                if (typesupplies != null)
            {
                typesupplies.NameTypeSupplies = NameTypeSupplies;
            }


            return await _TypeSuppliesRepository.updateTypeSupplie(typesupplies);
        }
    }


}
