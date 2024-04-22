using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Papalandia.Models
{
    public class PlayerLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerLocationId { get; set; }
        public string? CoordinateX { get; set; }
        public string? CoordinateY { get; set; }
        public string? CoordinateZ { get; set;}
        public StateGames StateGame { get; set; }
    }
}
