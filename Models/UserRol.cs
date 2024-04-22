using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Papalandia.Models
{
    public class UserRol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserRolId { get; set; }
        public string? UserRolName { get; set; }
        public ICollection<Users>? Users { get; set; }
    }
}
