using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface IPlayerLocationService
    {
        Task<List<PlayerLocation>> getPlayerLocations();
        Task<PlayerLocation> getPlayerLocation(int PlayerLocationId);
        Task<PlayerLocation> createPlayerLocation(string CoordinateX, string CoordinateY, string CoordinateZ);
        Task<PlayerLocation> updatePlayerLocation(int PlayerLocationId, string? CoordinateX=null, string? CoordinateY=null, string? CoordinateZ=null);
        Task<PlayerLocation> deletePlayerLocation(int PlayerLocationId);
    }

    public class PlayerLocationService : IPlayerLocationService
    {

        private readonly IPlayerLocationRepository _playerLocationRepository;

        public PlayerLocationService(IPlayerLocationRepository playerLocationRepository)
        {

            _playerLocationRepository = playerLocationRepository;

        }

        public async Task<PlayerLocation> createPlayerLocation(string CoordinateX, string CoordinateY, string CoordinateZ)
        {
            return await _playerLocationRepository.createPlayerLocation(CoordinateX, CoordinateY, CoordinateZ);
        }

        public async Task<PlayerLocation> getPlayerLocation(int PlayerLocationId)
        {
            return await _playerLocationRepository.getPlayerLocation(PlayerLocationId);
        }

        public async Task<List<PlayerLocation>> getPlayerLocations()
        {
            return await _playerLocationRepository.getPlayerLocations();
        }

        public async Task<PlayerLocation> updatePlayerLocation(int PlayerLocationId, string? CoordinateX = null, string? CoordinateY = null, string? CoordinateZ = null)
        {
            PlayerLocation playerLocation = await _playerLocationRepository.getPlayerLocation(PlayerLocationId);

            if (playerLocation == null)
            {
                return null;
            }
            else
                if (CoordinateX != null)
            {
                playerLocation.CoordinateX = CoordinateX;
            }
            if (CoordinateY != null)
            {
                playerLocation.CoordinateY = CoordinateY;
            }
            if (CoordinateZ != null)
            {
                playerLocation.CoordinateZ = CoordinateZ;
            }

            return await _playerLocationRepository.updatePlayerLocation(playerLocation);
        }

        public async Task<PlayerLocation> deletePlayerLocation(int PlayerLocationId)
        {
            return await _playerLocationRepository.deletePlayerLocation(PlayerLocationId);
        }

    }
}
