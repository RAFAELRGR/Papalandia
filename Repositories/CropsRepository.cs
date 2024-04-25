using Microsoft.EntityFrameworkCore;
using Papalandia.Models;
using Papalandia.Context;

namespace Papalandia.Repositories
{
    public interface ICropsRepository
    {

        Task<List<Crops>> getCrops();
        Task<Crops> getCrop(int CropsId);
        Task<Crops> createCrop(int PlotsId, int PotatoesId, int PestId, DateOnly SowingDate, int StateCropsId);
        Task<Crops> updateCrop(Crops crops);
        Task<Crops> deleteCrop(int CropsId);
    }

    public class CropsRepository: ICropsRepository
    {

        private readonly PapalandiaDbContext _db;

        public CropsRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<Crops> createCrop(int PlotsId, int PotatoesId, int PestId, DateOnly SowingDate, int StateCropsId)
        {

            Crops newCrops = new Crops
            {
                PlotsId = PlotsId,
                PotatoesId = PotatoesId,
                PestId = PestId,
                SowingDate = SowingDate,
                StateCropsId = StateCropsId
            };

            _db.Crops.Add(newCrops);
            await _db.SaveChangesAsync();

            return newCrops;

        }

        public async Task<List<Crops>> getCrops()
        {
            return await _db.Crops.ToListAsync();
        }

        public async Task<Crops> getCrop(int CropsId)
        {
            return await _db.Crops.Where(u => u.CropsId == CropsId).FirstOrDefaultAsync();
        }

        public async Task<Crops> updateCrop(Crops crops)
        {
            _db.Crops.Update(crops);
            await _db.SaveChangesAsync();
            return crops;
        }

        public async Task<Crops> deleteCrop(int CropsId)
        {
            Crops Cropsdelete = await _db.Crops.FindAsync(CropsId);
            if (Cropsdelete == null)
            {
                return null;
            }

            _db.Crops.Remove(Cropsdelete);
            await _db.SaveChangesAsync();
            return Cropsdelete;

        }

    }
}
