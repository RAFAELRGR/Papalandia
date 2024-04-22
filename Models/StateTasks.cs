using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Papalandia.Models
{
    public class StateTasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateTasksId { get; set; }
        public string? StateTasksName { get; set; }
        public ICollection<Tasks>? Tasks { get; set; }
    }
}
