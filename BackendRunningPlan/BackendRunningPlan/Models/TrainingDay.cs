namespace BackendRunningPlan.Models
{
    public class TrainingDay
    {
        public string id { get; set; }
        public string Number { get; set; }
        public DateTime DateTime { get; set; }
        public List<Training> Trainings { get; set; }
    }
}
