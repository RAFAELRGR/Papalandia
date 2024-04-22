using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Papalandia.Models
{
    public class TypePotatoes
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int? TypePotatoesId { get; set; }
        public String? TypeNamePotatoes { get; set; }

    }
}
