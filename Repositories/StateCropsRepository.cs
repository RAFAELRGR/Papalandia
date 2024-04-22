using Microsoft.EntityFrameworkCore;
using Papalandia.Models;
using Papalandia.Context;

namespace Papalandia.Repositories
{
    public interface IStateCropsRepository
    { 
        Task<List<StateCrops>> getStateCrops();
        Task<StateCrops> getStateCrop(int StateCropsId);
        Task<StateCrops> createStateCrop(string StateCrop);
        Task<StateCrops> updateStateCrop(StateCrops stateCrops);
        Task<StateCrops> deleteStateCrop(int StateCropsId);
    }

    public class StateCropsRepository: IStateCropsRepository
    {

        private readonly PapalandiaDbContext _db;

        public StateCropsRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<StateCrops> createStateCrop(string StateCrop)
        {

            StateCrops newStateCrops = new StateCrops
            {
                StateCrop = StateCrop,
            };

            _db.StateCrops.Add(newStateCrops);
            await _db.SaveChangesAsync();

            return newStateCrops;

        }

        public async Task<List<StateCrops>> getStateCrops()
        {
            return await _db.StateCrops.ToListAsync();
        }

        public async Task<StateCrops> getStateCrop(int StateCropsId)
        {
            return await _db.StateCrops.Where(u => u.StateCropsId == StateCropsId).FirstOrDefaultAsync();
        }

        public async Task<StateCrops> updateStateCrop(StateCrops stateCrops)
        {
            _db.StateCrops.Update(stateCrops);
            await _db.SaveChangesAsync();
            return stateCrops;
        }

        public async Task<StateCrops> deleteStateCrop(int StateCropsId)
        {
            StateCrops stateCrops = await _db.StateCrops.FindAsync(StateCropsId);
            if (stateCrops == null)
            {
                return null;
            }
            _db.StateCrops.Remove(stateCrops);
            await _db.SaveChangesAsync();
            return stateCrops;

        }

    }
}
