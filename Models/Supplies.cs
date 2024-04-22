using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Papalandia.Models
{
    public class Supplies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SuppliesId { get; set;}
        public string? SuppliesName { get; set;}
        public string? SuppliesDescription { get; set;}
        public int? TypeSuppliesId { get; set; }

        [ForeignKey("TypeSuppliesId")]
        public TypeSupplies? TypeSupplies { get; set; }
    }
}
