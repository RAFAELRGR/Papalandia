using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Papalandia.Models
{
    public class TypeSupplies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeSuppliesId { get; set; }
        public string? NameTypeSupplies {  get; set; }

    }
}
