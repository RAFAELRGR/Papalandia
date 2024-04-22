using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Papalandia.Models
{
    public class StateCrops
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? StateCropsId { get; set; }
        public string? StateCrop { get; set; }
        //public ICollection<Crops>? Crops { get; set; }
    }
}
