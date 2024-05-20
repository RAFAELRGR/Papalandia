using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface IUserService
    {
        Task<List<Users>> getUsers();
        Task<Users> getUser(int UserId);
        Task<Users> createUser(string UserName, string Email, string Password, int UserRolId);
        Task<Users> updateUser(int UserId, string? UserName = null, string? Email = null, string? Password = null, int? UserRolId = null);
        Task<Users> deleteUser(int UserId);
        Task<Users> Login(string Username, string Password);
    }
    public class UserService : IUserService
    {
        private readonly IUsersRepository _UserRepository;

        public UserService(IUsersRepository UserRepository)
        {

            _UserRepository = UserRepository;

        }
        public async Task<Users> createUser(string UserName, string Email, string Password, int UserRolId)
        {
            return await _UserRepository.createUser(UserName, Email, Password, UserRolId);
        }

        public async Task<Users> deleteUser(int UserId)
        {
            return await _UserRepository.deleteUser(UserId);
        }

        public async Task<Users> getUser(int UserId)
        {
            return await _UserRepository.getUser(UserId);
        }

        public async Task<List<Users>> getUsers()
        {
            return await _UserRepository.getUsers();
        }

        public async Task<Users> updateUser(int UserId, string? UserName = null, string? Email = null, string? Password = null, int? UserRolId = null)
        {
            Users users = await _UserRepository.getUser(UserId);
            if (users == null)
            {
                return null;
            }
                if (UserName != null)
            {
                users.UserName = UserName;
            }

                if (Email != null)
            {
                users.Email = Email;
            }

                if (Password != null)
            {
                users.Password = Password;
            }
                if (UserRolId != null)
            {
                users.UserRolId = UserRolId;
            }

            return await _UserRepository.updateUser(users);
        }
        public async Task<Users> Login(string userName, string password)
        {
            return await _UserRepository.Login(userName, password);
        }

    }
}
