using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Papalandia.Models
{
    public class StateGames
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? StateGameId { get; set; }
        public int? PlayerLocationId { get; set; }

        [ForeignKey("PlayerLocationId")]
        public PlayerLocation? PlayerLocation { get; set; }
       // public ICollection<Games>? Games { get; set; }
    }
}
