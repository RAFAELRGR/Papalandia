using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface IUserRolService
    {
        Task<List<UserRol>> getUserRols();
        Task<UserRol> getUserRol(int UserRolId);
        Task<UserRol> createUserRol(string UserRolName);
        Task<UserRol> updateUserRol(int UserId, string? UserRolName = null);
        Task<UserRol> deleteUserRol(int UserRolId);
    }

    public class UserRolService : IUserRolService
    {
        private readonly IUserRolRepository _UserRolRepository;

        public UserRolService(IUserRolRepository UserRolRepository)
        {

            _UserRolRepository = UserRolRepository;

        }
        public async Task<UserRol> createUserRol(string UserRolName)
        {
            return await _UserRolRepository.createUserRol(UserRolName);
        }

        public async Task<UserRol> deleteUserRol(int UserRolId)
        {
            return await _UserRolRepository.deleteUserRol(UserRolId);
        }

        public async Task<UserRol> getUserRol(int UserRolId)
        {
            return await _UserRolRepository.getUserRol(UserRolId);
        }

        public async Task<List<UserRol>> getUserRols()
        {
            return await _UserRolRepository.getUserRols();
        }

        public async Task<UserRol> updateUserRol(int UserRolId, string? UserRolName = null)
        {
            UserRol usersrol = await _UserRolRepository.getUserRol(UserRolId);
            if (usersrol == null)
            {
                return null;
            }
            else
                if (UserRolName != null)
            {
                usersrol.UserRolName = UserRolName;
            }


            return await _UserRolRepository.updateUserRol(usersrol);
        }
    }

}
