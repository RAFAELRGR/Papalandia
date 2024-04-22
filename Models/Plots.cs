using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Papalandia.Models
{
    public class Plots
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlotsId { get; set; } 
        public decimal? PlotsSize { get; set; }
        public decimal? Longitude {  get; set; }
        public decimal? Latitude { get; set; }

    }
}
