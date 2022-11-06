using System.ComponentModel.DataAnnotations.Schema;

namespace BackendRunningPlan.Models
{
    public class TrainingPlan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string? Type { get; set; }
        public int? Level { get; set; }
        public int? DurationInWeeks { get; set; }
        public DateTime? StartDate { get; set; }
        public string? Description { get; set; } = string.Empty;
        public List<TrainingDay>? TrainingDays { get; set; }
    }
}
