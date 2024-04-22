using Microsoft.EntityFrameworkCore;
using Papalandia.Models;
using Papalandia.Context;

namespace Papalandia.Repositories
{
    public interface IUsersRepository
    {
        Task<List<Users>> getUsers();
        Task<Users> getUser(int UserId);
        Task<Users> createUser(string UserName, string Email, string Password, int UserRolId);
        Task<Users> updateUser(Users users);
        Task<Users> deleteUser(int UserId);
    }

    public class UsersRepository
    {

        private readonly PapalandiaDbContext _db;

        public UsersRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<Users> createUsers(string UserName, string Email, string Password, int UserRolId)
        {

            Users newUsers = new Users
            {
                UserName = UserName,
                Email = Email,
                Password = Password,
                UserRolId = UserRolId
            };

            _db.Users.Add(newUsers);
            await _db.SaveChangesAsync();

            return newUsers;

        }

        public async Task<List<Users>> getUsers()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<Users> getUser(int UserId)
        {
            return await _db.Users.Where(u => u.UserId == UserId).FirstOrDefaultAsync();
        }

        public async Task<Users> updateUser(Users users)
        {
            _db.Users.Update(users);
            await _db.SaveChangesAsync();
            return users;
        }

        public async Task<Users> deleteUser(int UserId)
        {
            Users users = await getUser(UserId);
            // student.IsDeleted = true;
            return await updateUser(users);
        }

    }
}
