using Microsoft.EntityFrameworkCore;
using Papalandia.Models;
using Papalandia.Context;

namespace Papalandia.Repositories
{
    public interface IAchievementsRepository
    {

        Task<List<Achievements>> getAchievements();
        Task<Achievements> getAchievement(int AchievementsId);
        Task<Achievements> createAchievement (string AchievementsName, string AchievementsDescription);
        Task<Achievements> updateAchievement(Achievements achievements);
        Task<Achievements> deleteAchievement(int AchievementsId);
    }

    public class AchievementsRepository : IAchievementsRepository
    {

        private readonly PapalandiaDbContext _db;

        public AchievementsRepository(PapalandiaDbContext db)
        {
            _db = db;
        }

        public async Task<Achievements> createAchievement(string AchievementsName, string AchievementsDescription)
        {

            Achievements newAchievement = new Achievements
            {
                AchievementsName = AchievementsName,
                AchievementsDescription = AchievementsDescription,
            };

            _db.Achievements.Add(newAchievement);
            await _db.SaveChangesAsync();

            return newAchievement;

        }

        public async Task<List<Achievements>> getAchievements()
        {
            return await _db.Achievements.ToListAsync();
        }

        public async Task<Achievements> getAchievement(int AchievementsId)
        {
            return await _db.Achievements.Where(u => u.AchievementsId == AchievementsId).FirstOrDefaultAsync();
        }

        public async Task<Achievements> updateAchievement(Achievements achievements)
        {
            _db.Achievements.Update(achievements);
            await _db.SaveChangesAsync();
            return achievements;
        }

        public async Task<Achievements> deleteAchievement(int AchievementsId)
        {
            Achievements achievement = await getAchievement(AchievementsId);
            // student.IsDeleted = true;
            return await updateAchievement(achievement);
        }
    

    }
}
