using Microsoft.EntityFrameworkCore;
using Papalandia.Models;
using Papalandia.Context;

namespace Papalandia.Repositories
{
    public interface ITypePotatoesRepository
    {
        Task<List<TypePotatoes>> getTypePotatoes();
        Task<TypePotatoes> getTypePotato(int TypePotatoesId);
        Task<TypePotatoes> createTypePotato(String TypeNamePotatoes);
        Task<TypePotatoes> updateTypePotato(TypePotatoes typePotatoes);
        Task<TypePotatoes> deleteTypePotato(int TypePotatoesId);
    }

    public class TypePotatoesRepository : ITypePotatoesRepository
    {

        private readonly PapalandiaDbContext _db;

        public TypePotatoesRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<TypePotatoes> createTypePotato(String TypeNamePotatoes)
        {

            TypePotatoes newTypePotatoes = new TypePotatoes
            {
                TypeNamePotatoes = TypeNamePotatoes,
            };

            _db.TypePotatoes.AddAsync(newTypePotatoes);
            await _db.SaveChangesAsync();

            return newTypePotatoes;

        }

        public async Task<List<TypePotatoes>> getTypePotatoes()
        {
            return await _db.TypePotatoes.ToListAsync();
        }

        public async Task<TypePotatoes> getTypePotato(int TypePotatoesId)
        {
            return await _db.TypePotatoes.Where(u => u.TypePotatoesId == TypePotatoesId).FirstOrDefaultAsync();
        }

        public async Task<TypePotatoes> updateTypePotato(TypePotatoes typePotatoes)
        {
            _db.TypePotatoes.Update(typePotatoes);
            await _db.SaveChangesAsync();
            return typePotatoes;
        }

        public async Task<TypePotatoes> deleteTypePotato(int TypePotatoesId)
        {
            TypePotatoes typePotatoes = await getTypePotato(TypePotatoesId);
            if (typePotatoes == null)
            {
                return null;
            }

            _db.TypePotatoes.Remove(typePotatoes);
            await _db.SaveChangesAsync();
            return typePotatoes;
        }
    

    }
}
