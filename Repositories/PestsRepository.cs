using Microsoft.EntityFrameworkCore;
using Papalandia.Models;
using Papalandia.Context;

namespace Papalandia.Repositories
{
    public interface IPestsRepository
    {
        Task<List<Pests>> getPests();
        Task<Pests> getPest(int PestsId);
        Task<Pests> createPest(string PestsName, string PestsDescription, int SuppliesId);
        Task<Pests> updatePest(Pests pests);
        Task<Pests> deletePest(int PestsId);
    }

    public class PestsRepository : IPestsRepository
    {

        private readonly PapalandiaDbContext _db;

        public PestsRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<Pests> createPest(string PestsName, string PestsDescription, int SuppliesId)
        {

            Pests newPests = new Pests
            {
                PestsName = PestsName,
                PestsDescription = PestsDescription,
                SuppliesId = SuppliesId,
            };

            _db.Pests.Add(newPests);
            await _db.SaveChangesAsync();

            return newPests;

        }

        public async Task<List<Pests>> getPests()
        {
            return await _db.Pests.ToListAsync();
        }

        public async Task<Pests> getPest(int PestsId)
        {
            return await _db.Pests.Where(u => u.PestsId == PestsId).FirstOrDefaultAsync();
        }

        public async Task<Pests> updatePest(Pests pests)
        {
            _db.Pests.Update(pests);
            await _db.SaveChangesAsync();
            return pests;
        }

        public async Task<Pests> deletePest(int PestsId)
        {
            Pests pests = await _db.Pests.FindAsync(PestsId);
            if (pests == null)
            {
                return null;
            }
            _db.Pests.Remove(pests);
            await _db.SaveChangesAsync();
            return pests;

        }

    }
}
