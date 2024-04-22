using Microsoft.EntityFrameworkCore;
using Papalandia.Models;
using Papalandia.Context;

namespace Papalandia.Repositories
{
    public interface ITypeSuppliesRepository
    {
        Task<List<TypeSupplies>> getTypeSupplies();
        Task<TypeSupplies> getTypeSupplie(int TypeSuppliesId);
        Task<TypeSupplies> createTypeSupplie(string NameTypeSupplies);
        Task<TypeSupplies> updateTypeSupplie(TypeSupplies typeSupplies);
        Task<TypeSupplies> deleteTypeSupplie(int TypeSuppliesId);
    }

    public class TypeSuppliesRepository : ITypeSuppliesRepository
    {

        private readonly PapalandiaDbContext _db;

        public TypeSuppliesRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<TypeSupplies> createTypeSupplie(string NameTypeSupplies)
        {

            TypeSupplies newTypeSupplies = new TypeSupplies
            {
                NameTypeSupplies = NameTypeSupplies,
            };

            _db.TypeSupplies.Add(newTypeSupplies);
            await _db.SaveChangesAsync();

            return newTypeSupplies;

        }

        public async Task<List<TypeSupplies>> getTypeSupplies()
        {
            return await _db.TypeSupplies.ToListAsync();
        }

        public async Task<TypeSupplies> getTypeSupplie(int TypeSuppliesId)
        {
            return await _db.TypeSupplies.Where(u => u.TypeSuppliesId == TypeSuppliesId).FirstOrDefaultAsync();
        }

        public async Task<TypeSupplies> updateTypeSupplie(TypeSupplies typeSupplies)
        {
            _db.TypeSupplies.Update(typeSupplies);
            await _db.SaveChangesAsync();
            return typeSupplies;
        }

        public async Task<TypeSupplies> deleteTypeSupplie(int typeSuppliesId)
        {
            TypeSupplies typeSupplies = await getTypeSupplie(typeSuppliesId);
            if (typeSupplies == null)
            {
                return null;
            }

            _db.TypeSupplies.Remove(typeSupplies);
            await _db.SaveChangesAsync();

            return typeSupplies;
        }


    }
}
