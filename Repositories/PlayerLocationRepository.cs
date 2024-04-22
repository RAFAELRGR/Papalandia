using Microsoft.EntityFrameworkCore;
using Papalandia.Models;
using Papalandia.Context;

namespace Papalandia.Repositories
{
    public interface IPlayerLocationRepository
    {

        Task<List<PlayerLocation>> getPlayerLocations();
        Task<PlayerLocation> getPlayerLocation(int PlayerLocationId);
        Task<PlayerLocation> createPlayerLocation(string CoordinateX, string CoordinateY, string CoordinateZ);
        Task<PlayerLocation> updatePlayerLocation(PlayerLocation playerLocation);
        Task<PlayerLocation> deletePlayerLocation(int PlayerLocationId);
    }

    public class PlayerLocationRepository : IPlayerLocationRepository
    {

        private readonly PapalandiaDbContext _db;

        public PlayerLocationRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<PlayerLocation> createPlayerLocation(string CoordinateX, string CoordinateY, string CoordinateZ)
        {

            PlayerLocation newplayerLocation = new PlayerLocation
            {
                CoordinateX = CoordinateX,
                CoordinateY = CoordinateY,
                CoordinateZ = CoordinateZ,
            };

            _db.PlayerLocation.Add(newplayerLocation);
            await _db.SaveChangesAsync();

            return newplayerLocation;

        }

        public async Task<List<PlayerLocation>> getPlayerLocations()
        {
            return await _db.PlayerLocation.ToListAsync();
        }

        public async Task<PlayerLocation> getPlayerLocation(int PlayerLocationId)
        {
            return await _db.PlayerLocation.Where(u => u.PlayerLocationId == PlayerLocationId).FirstOrDefaultAsync();
        }

        public async Task<PlayerLocation> updatePlayerLocation(PlayerLocation playerLocation)
        {
            _db.PlayerLocation.Update(playerLocation);
            await _db.SaveChangesAsync();
            return playerLocation;
        }

        public async Task<PlayerLocation> deletePlayerLocation(int PlayerLocationId)
        {
            PlayerLocation playerLocation = await getPlayerLocation(PlayerLocationId);
            // student.IsDeleted = true;
            return await updatePlayerLocation(playerLocation);
        }

    }
}
