using Papalandia.Models;
using Papalandia.Repositories;

namespace Papalandia.Services
{
    public interface IAchievementsService
    {
        Task<List<Achievements>> getAchievements();
        Task<Achievements> getAchievement(int AchievementsId);
        Task<Achievements> createAchievement(string AchievementsName , string AchievementsDescription );
        Task<Achievements> updateAchievement(int AchievementsId, string? AchievementsName = null, string? AchievementsDescription = null);
        Task<Achievements> deleteAchievement(int AchievementsId);
    }
    public class AchievementsService : IAchievementsService
    {

        private readonly IAchievementsRepository _achievementsRepository;

        public AchievementsService(IAchievementsRepository achievementsRepository)
        {

            _achievementsRepository = achievementsRepository;

        }

        public async Task<Achievements> createAchievement(string AchievementsName, string AchievementsDescription)
        {
            return await _achievementsRepository.createAchievement(AchievementsName, AchievementsDescription);
        }

        public async Task<Achievements> getAchievement(int AchievementsId)
        {
            return await _achievementsRepository.getAchievement(AchievementsId);
        }

        public async Task<List<Achievements>> getAchievements()
        {
            return await _achievementsRepository.getAchievements();
        }

        public async Task<Achievements> updateAchievement(int AchievementsId, string? AchievementsName = null, string? AchievementsDescription = null)
        {
            Achievements achievements = await _achievementsRepository.getAchievement(AchievementsId);

            if (achievements == null)
            {
                return null;
            }
            else
                if (AchievementsName != null)
            {
                achievements.AchievementsName = AchievementsName;
            }
            if (AchievementsDescription != null)
            {
                achievements.AchievementsDescription = AchievementsDescription;
            }

            return await _achievementsRepository.updateAchievement(achievements);
        }

        public async Task<Achievements> deleteAchievement(int AchievementsId)
        {
            return await _achievementsRepository.deleteAchievement(AchievementsId);
        }

    }
}
