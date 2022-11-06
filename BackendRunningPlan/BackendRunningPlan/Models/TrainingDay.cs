using System.ComponentModel.DataAnnotations.Schema;

namespace BackendRunningPlan.Models
{
    public class TrainingDay
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public int? Number { get; set; }
        public DateTime DateTime { get; set; }
        public List<Training>? Trainings { get; set; }
        public TrainingPlan? TrainingList { get; set; }
        public int? TrainingPlanId { get; set; }
    }
}
