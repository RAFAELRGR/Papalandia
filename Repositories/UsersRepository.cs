﻿using Microsoft.EntityFrameworkCore;
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
        Task<Users> Login(string userName, string password);
    }

    public class UsersRepository : IUsersRepository
    {

        private readonly PapalandiaDbContext _db;

        public UsersRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<Users> createUser(string UserName, string Email, string Password, int UserRolId)
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
            Users users = await _db.Users.FindAsync(UserId);
            if (users == null)
            {
                return null;
            }
            _db.Users.Remove(users);
            await _db.SaveChangesAsync();
            return users;
        }

        public async Task<Users> Login(string userName, string password)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
        }

    }
}
