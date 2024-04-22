using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Papalandia.Models
{
    public class Potatoes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PotatoesId { get; set; }

        public string? PotatoesName { get; set; }

        public string? Description { get; set; }

        public decimal? TimeGrowth { get; set; }

        public int? TypePotatoesId { get; set; }
        [ForeignKey("TypePotatoesId")]
        public TypePotatoes? TypePotatoes { get; set; }
    }
}


