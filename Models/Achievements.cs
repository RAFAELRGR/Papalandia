using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Papalandia.Models
{
    public class Achievements
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? AchievementsId { get; set;}
        public string? AchievementsName { get; set;}
        public string? AchievementsDescription { get; set;}
        public ICollection<GamesAchievements>? Unlocks { get; set; }
    }
}
