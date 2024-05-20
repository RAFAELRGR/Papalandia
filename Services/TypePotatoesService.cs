using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface ITypePotatoesService
    {
        Task<List<TypePotatoes>> getTypePotatoes();
        Task<TypePotatoes> getTypePotato(int TypePotatoesId);
        Task<TypePotatoes> createTypePotato(string TypeNamePotatoes);
        Task<TypePotatoes> updateTypePotato(int TypePotatoesId, string? TypeNamePotatoes = null);
        Task<TypePotatoes> deleteTypePotato(int TypePotatoesId);
    }

    public class TypePotatoesService : ITypePotatoesService
    {
        private readonly ITypePotatoesRepository _TypePotatoesRepository;

        public TypePotatoesService(ITypePotatoesRepository TypePotatoesRepository)
        {

            _TypePotatoesRepository = TypePotatoesRepository;

        }

        public async Task<TypePotatoes> createTypePotato(string TypeNamePotatoes)
        {
            return await _TypePotatoesRepository.createTypePotato(TypeNamePotatoes);
        }


        public async Task<TypePotatoes> deleteTypePotato(int TypePotatoesId)
        {
            return await _TypePotatoesRepository.deleteTypePotato(TypePotatoesId);
        }

        public async Task<TypePotatoes> getTypePotato(int TypePotatoesId)
        {
            return await _TypePotatoesRepository.getTypePotato(TypePotatoesId);
        }

        public async Task<List<TypePotatoes>> getTypePotatoes()
        {
            return await _TypePotatoesRepository.getTypePotatoes();
        }

        public async Task<TypePotatoes> updateTypePotato(int TypePotatoesId, string? TypeNamePotatoes = null)
        {
            TypePotatoes typepotatoes = await _TypePotatoesRepository.getTypePotato(TypePotatoesId);
            if (typepotatoes == null)
            {
                return null;
            }
                if (TypeNamePotatoes != null)
            {
                typepotatoes.TypeNamePotatoes = TypeNamePotatoes;
            }


            return await _TypePotatoesRepository.updateTypePotato(typepotatoes);
        }
    }


}
