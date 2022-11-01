using System.ComponentModel.DataAnnotations.Schema;

namespace BackendRunningPlan.Models
{
    public class TrainingDay
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string? Number { get; set; }
        public DateTime DateTime { get; set; }
        public List<Training>? Trainings { get; set; }
        public TrainingList? TrainingList { get; set; }
        public int? TrainingListId { get; set; }
    }
}
