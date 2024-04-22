using Microsoft.EntityFrameworkCore;
using Papalandia.Models;
using Papalandia.Context;

namespace Papalandia.Repositories
{
    public interface IGamesAchievementsRepository
    {

        Task<List<GamesAchievements>> getGamesAchievements();
        Task<GamesAchievements> getGamesAchievement(int AchievementUnlockedId);
        Task<GamesAchievements> createGamesAchievement(DateTime AchievementUnlocked, int AchievementId, int GameId);
        Task<GamesAchievements> updateGamesAchievement(GamesAchievements gamesAchievements);
        Task<GamesAchievements> deleteGamesAchievement(int AchievementUnlockedId);
    }

    public class GamesAchievementsRepository : IGamesAchievementsRepository
    {

        private readonly PapalandiaDbContext _db;

        public GamesAchievementsRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<GamesAchievements> createGamesAchievement(DateTime AchievementUnlocked, int AchievementId, int GameId)
        {

            GamesAchievements newGamesAchievements = new GamesAchievements
            {
                AchievementUnlocked = AchievementUnlocked,
                AchievementId = AchievementId,
                GameId = GameId,
            };

            _db.GamesAchievements.Add(newGamesAchievements);
            await _db.SaveChangesAsync();

            return newGamesAchievements;

        }

        public async Task<List<GamesAchievements>> getGamesAchievements()
        {
            return await _db.GamesAchievements.ToListAsync();
        }

        public async Task<GamesAchievements> getGamesAchievement(int AchievementUnlockedId)
        {
            return await _db.GamesAchievements.Where(u => u.AchievementUnlockedId == AchievementUnlockedId).FirstOrDefaultAsync();
        }

        public async Task<GamesAchievements> updateGamesAchievement(GamesAchievements gamesAchievements)
        {
            _db.GamesAchievements.Update(gamesAchievements);
            await _db.SaveChangesAsync();
            return gamesAchievements;
        }

        public async Task<GamesAchievements> deleteGamesAchievement(int AchievementUnlockedId)
        {
            GamesAchievements gamesAchievements = await getGamesAchievement(AchievementUnlockedId);
            // student.IsDeleted = true;
            return await updateGamesAchievement(gamesAchievements);
        }

    }
}
