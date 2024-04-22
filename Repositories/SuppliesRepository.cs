using Microsoft.EntityFrameworkCore;
using Papalandia.Models;
using Papalandia.Context;

namespace Papalandia.Repositories
{
    public interface ISuppliesRepository
    {
        Task<List<Supplies>> getSupplies();
        Task<Supplies> getSupply(int SuppliesId);
        Task<Supplies> createSupply(string SuppliesName, string SuppliesDescription, int TypeSuppliesId);
        Task<Supplies> updateSupply(Supplies supplies);
        Task<Supplies> deleteSupply(int SuppliesId);
    }

    public class SuppliesRepository : ISuppliesRepository
    {


        private readonly PapalandiaDbContext _db;

        public SuppliesRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<Supplies> createSupply(string SuppliesName, string SuppliesDescription, int TypeSuppliesId)
        {

            Supplies newSupplies = new Supplies
            {
                SuppliesName = SuppliesName,
                SuppliesDescription = SuppliesDescription,
                TypeSuppliesId = TypeSuppliesId,
            };

            _db.Supplies.Add(newSupplies);
            await _db.SaveChangesAsync();

            return newSupplies;

        }

        public async Task<List<Supplies>> getSupplies()
        {
            return await _db.Supplies.ToListAsync();
        }

        public async Task<Supplies> getSupply(int SuppliesId)
        {
            return await _db.Supplies.Where(u => u.SuppliesId == SuppliesId).FirstOrDefaultAsync();
        }

        public async Task<Supplies> updateSupply(Supplies supplies)
        {
            _db.Supplies.Update(supplies);
            await _db.SaveChangesAsync();
            return supplies;
        }

        public async Task<Supplies> deleteSupply(int suppliesId)
        {
            var supply = await getSupply(suppliesId);
            if (supply == null)
            {
                return null;
            }

            _db.Supplies.Remove(supply);
            await _db.SaveChangesAsync();

            return supply;
        }

    }
}
