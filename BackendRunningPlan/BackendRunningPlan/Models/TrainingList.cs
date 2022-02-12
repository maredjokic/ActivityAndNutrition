namespace BackendRunningPlan.Models
{
    public class Training
    {
        string id { get; set; }
        List<RunningTraining> RunningTrainings { get; set; }
        List<StrengthTraining> StrengthTrainings { get; set; }
    }
}
