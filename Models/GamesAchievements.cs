using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Papalandia.Models
{
    public class GamesAchievements
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AchievementUnlockedId { get; set; }
        public DateTime? AchievementUnlocked { get; set; }
        public int? AchievementId { get; set; }
        public int? GameId { get; set; }

        [ForeignKey("AchievementId")]
        public Achievements? Achievement { get; set; }

        [ForeignKey("GameId")]
        public Games? Game { get; set; }
    }
}
