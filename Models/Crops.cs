using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Papalandia.Models
{
    public class Crops
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CropsId { get; set; }
        public int? PlotsId { get; set; }
        [ForeignKey("PlotsId")]
        public Plots? Plot { get; set; }
        public int? PotatoesId { get; set; }
        [ForeignKey("PotatoesId")]
        public Potatoes? Potatoes { get; set; }
        public  int? PestId { get; set; }
        [ForeignKey("PestId")]
        public Pests? Pest { get; set; }
        public DateOnly? SowingDate { get; set;}
        public int? StateCropsId { get; set; }
        [ForeignKey("StateCropsId")]
        public StateCrops? StateCrops { get; set; }



    }
}
