using Microsoft.EntityFrameworkCore;
using Papalandia.Models;
using Papalandia.Context;

namespace Papalandia.Repositories
{
    public interface IPotatoesRepository
    {

        Task<List<Potatoes>> getPotatoes();
        Task<Potatoes> getPotato(int PotatoesId);
        Task<Potatoes> createPotato(string PotatoesName, string Description, decimal TimeGrowth, int TypePotatoesId);
        Task<Potatoes> updatePotato(Potatoes potatoes);
        Task<Potatoes> deletePotato(int PotatoesId);
    }

    public class PotatoesRepository : IPotatoesRepository
    {

        private readonly PapalandiaDbContext _db;

        public PotatoesRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<Potatoes> createPotato(string PotatoesName, string Description, decimal TimeGrowth, int TypePotatoesId)
        {

            Potatoes newPotatoes = new Potatoes
            {
                PotatoesName = PotatoesName,
                Description = Description,
                TimeGrowth = TimeGrowth,
                TypePotatoesId = TypePotatoesId,
            };

            _db.Potatoes.Add(newPotatoes);
            await _db.SaveChangesAsync();

            return newPotatoes;

        }

        public async Task<List<Potatoes>> getPotatoes()
        {
            return await _db.Potatoes.ToListAsync();
        }

        public async Task<Potatoes> getPotato(int PotatoesId)
        {
            return await _db.Potatoes.Where(u => u.PotatoesId == PotatoesId).FirstOrDefaultAsync();
        }

        public async Task<Potatoes> updatePotato(Potatoes potatoes)
        {
            _db.Potatoes.Update(potatoes);
            await _db.SaveChangesAsync();
            return potatoes;
        }

        public async Task<Potatoes> deletePotato(int PotatoesId)
        {
            Potatoes potatoes = await _db.Potatoes.FindAsync(PotatoesId);
            if (potatoes == null)
            {
                return null;
            }

            _db.Potatoes.Remove(potatoes);
            await _db.SaveChangesAsync();
            return potatoes;
        }

    }
}
