using System.ComponentModel.DataAnnotations.Schema;

namespace BackendRunningPlan.Models
{
    public class Training
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Note { get; set; } = string.Empty;
        public TrainingDay? TrainingDay { get; set; }
        public int? TrainingDayId { get; set; }
    }
}
