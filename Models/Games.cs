using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Papalandia.Models
{
    public class Games
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }
        public DateTime? StartGame { get; set; }
        public DateTime? EndGame { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public Users? User { get; set; }
        public int? StateGameId { get; set; }

        [ForeignKey("StateGameId")]
        public StateGames? StateGame { get; set; }
       // public ICollection<GamesAchievements>? Achievements { get; set; }
    }
}
