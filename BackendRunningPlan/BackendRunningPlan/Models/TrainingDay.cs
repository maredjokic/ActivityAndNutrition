namespace BackendRunningPlan.Models
{
    public class TrainingDay
    {
        string id { get; set; }
        string Number { get; set; }
        DateTime DateTime { get; set; }
        List<Training> Trainings { get; set; }
    }
}
