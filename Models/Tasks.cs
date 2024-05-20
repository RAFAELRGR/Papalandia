using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Papalandia.Models
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TasksId { get; set; }
        public int? CropsId { get; set; }
        [ForeignKey("CropsId")]
        public Crops? Crops { get; set; }
        public string? Description { get; set; }
        public DateOnly? DateTask { get; set; }
        public int? StateTasksId { get; set; }
        [ForeignKey("StateTasksId")]
        public StateTasks? StateTasks { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public Users? User { get; set; }
    }
}
