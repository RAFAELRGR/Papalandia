using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface IPotatoesService
    {
        Task<List<Potatoes>> getPotatoes();
        Task<Potatoes> getPotato(int PotatoesId);
        Task<Potatoes> createPotato(string PotatoesName, string Description, decimal TimeGrowth, int TypePotatoesId);
        Task<Potatoes> updatePotato(int PotatoesId, string? PotatoesName=null, string? Description=null, decimal? TimeGrowth=null, int? TypePotatoesId=null);
        Task<Potatoes> deletePotato(int PotatoesId);
    }

    public class PotatoesService : IPotatoesService
    {

        private readonly IPotatoesRepository _potatoesRepository;

        public PotatoesService(IPotatoesRepository potatoesRepository)
        {

            _potatoesRepository = potatoesRepository;

        }

        public async Task<Potatoes> createPotato(string PotatoesName, string Description, decimal TimeGrowth, int TypePotatoesId)
        {
            return await _potatoesRepository.createPotato(PotatoesName, Description, TimeGrowth, TypePotatoesId);
        }

        public async Task<Potatoes> getPotato(int PotatoesId)
        {
            return await _potatoesRepository.getPotato(PotatoesId);
        }

        public async Task<List<Potatoes>> getPotatoes()
        {
            return await _potatoesRepository.getPotatoes();
        }

        public async Task<Potatoes> updatePotato(int PotatoesId, string? PotatoesName = null, string? Description = null, decimal? TimeGrowth = null, int? TypePotatoesId = null)
        {
            Potatoes potatoes = await _potatoesRepository.getPotato(PotatoesId);

            if (potatoes == null)
            {
                return null;
            }
            else
                if (PotatoesId != null)
            {
                potatoes.PotatoesId = PotatoesId;
            }
            if (PotatoesName != null)
            {
                potatoes.PotatoesName = PotatoesName;
            }
            if (Description != null)
            {
                potatoes.Description = Description;
            }
            if (TimeGrowth != null)
            {
                potatoes.TimeGrowth = TimeGrowth;
            }
            if (TypePotatoesId != null)
            {
                potatoes.TypePotatoesId = TypePotatoesId;
            }

            return await _potatoesRepository.updatePotato(potatoes);
        }

        public async Task<Potatoes> deletePotato(int PotatoesId)
        {
            return await _potatoesRepository.deletePotato(PotatoesId);
        }

    }
}
