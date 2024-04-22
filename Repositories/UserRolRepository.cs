using Microsoft.EntityFrameworkCore;
using Papalandia.Models;
using Papalandia.Context;

namespace Papalandia.Repositories
{
    public interface IUserRolRepository
    {
        Task<List<UserRol>> getUserRols();
        Task<UserRol> getUserRol(int UserRolId);
        Task<UserRol> createUserRol(string UserRolName);
        Task<UserRol> updateUserRol(UserRol userRol);
        Task<UserRol> deleteUserRol(int UserRolId);
    }

    public class UserRolRepository : IUserRolRepository
    {
        private readonly PapalandiaDbContext _db;

        public UserRolRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<UserRol> createUserRol(string UserRolName)
        {

            UserRol newUserRol = new UserRol
            {
                UserRolName = UserRolName,
            };

            _db.UserRols.Add(newUserRol);
            await _db.SaveChangesAsync();

            return newUserRol;

        }

        public async Task<List<UserRol>> getUserRols()
        {
            return await _db.UserRols.ToListAsync();
        }

        public async Task<UserRol> getUserRol(int UserRolId)
        {
            return await _db.UserRols.Where(u => u.UserRolId == UserRolId).FirstOrDefaultAsync();
        }

        public async Task<UserRol> updateUserRol(UserRol userRol)
        {
            _db.UserRols.Update(userRol);
            await _db.SaveChangesAsync();
            return userRol;
        }

        public async Task<UserRol> deleteUserRol(int UserRolId)
        {
            UserRol userRol = await _db.UserRols.FindAsync(UserRolId);
            if (userRol == null)
            {
                return null;
            }
            _db.UserRols.Remove(userRol);
            await _db.SaveChangesAsync();
            return userRol;

         

        }

    }
}
