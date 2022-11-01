using System.ComponentModel.DataAnnotations.Schema;

namespace BackendRunningPlan.Models
{
    public class TrainingList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string? Description { get; set; } = string.Empty;
        public List<TrainingDay>? TrainingDays { get; set; }
    }
}
