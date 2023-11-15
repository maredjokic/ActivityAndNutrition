using System.ComponentModel.DataAnnotations.Schema;

namespace BackendRunningPlan.Models
{
    public class PersonalCoach
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string? Username { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public List<User>? User { get; set; }
    }
}
