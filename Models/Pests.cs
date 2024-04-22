using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Papalandia.Models
{
    public class Pests
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PestsId { get; set; }
        public string? PestsName { get; set; }  
        public string? PestsDescription { get; set;}
        public int? SuppliesId { get; set; } 
        [ForeignKey("SuppliesId")]
        public Supplies? Supplies { get; set; }


    }

}

