using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface IGamesAchievementsService
    {
        Task<List<GamesAchievements>> getGamesAchievements();
        Task<GamesAchievements> getGamesAchievement(int AchievementUnlockedId);
        Task<GamesAchievements> createGamesAchievement(DateTime AchievementUnlocked, int AchievementId, int GameId);
        Task<GamesAchievements> updateGamesAchievement(int AchievementUnlockedId, DateTime? AchievementUnlocked=null, int? AchievementId=null, int? GameId=null);
        Task<GamesAchievements> deleteGamesAchievement(int AchievementUnlockedId);
    }

    public class GamesAchievementsService: IGamesAchievementsService
    {

        private readonly IGamesAchievementsRepository _gamesAchievementsRepository;

        public GamesAchievementsService(IGamesAchievementsRepository gamesAchievementsRepository)
        {

            _gamesAchievementsRepository = gamesAchievementsRepository;

        }

        public async Task<GamesAchievements> createGamesAchievement(DateTime AchievementUnlocked, int AchievementId, int GameId)
        {
            return await _gamesAchievementsRepository.createGamesAchievement(AchievementUnlocked, AchievementId, GameId);
        }

        public async Task<GamesAchievements> getGamesAchievement(int AchievementUnlockedId)
        {
            return await _gamesAchievementsRepository.getGamesAchievement(AchievementUnlockedId);
        }

        public async Task<List<GamesAchievements>> getGamesAchievements()
        {
            return await _gamesAchievementsRepository.getGamesAchievements();
        }

        public async Task<GamesAchievements> updateGamesAchievement(int AchievementUnlockedId, DateTime? AchievementUnlocked = null, int? AchievementId = null, int? GameId = null)
        {
            GamesAchievements gamesAchievements = await _gamesAchievementsRepository.getGamesAchievement(AchievementUnlockedId);

            if (gamesAchievements == null)
            {
                return null;
            }
            else
                if (AchievementUnlocked != null)
            {
                gamesAchievements.AchievementUnlocked = AchievementUnlocked;
            }
            if (AchievementId != null)
            {
                gamesAchievements.AchievementId = AchievementId;
            }
            if (GameId != null)
            {
                gamesAchievements.AchievementId = GameId;
            }

            return await _gamesAchievementsRepository.updateGamesAchievement(gamesAchievements);
        }

        public async Task<GamesAchievements> deleteGamesAchievement(int AchievementUnlockedId)
        {
            return await _gamesAchievementsRepository.deleteGamesAchievement(AchievementUnlockedId);
        }

    }
}
