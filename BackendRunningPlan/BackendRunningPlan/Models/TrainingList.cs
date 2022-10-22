namespace BackendRunningPlan.Models
{
    public class TrainingList
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public List<TrainingDay> TrainingDays { get; set; }
    }
}
