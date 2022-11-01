using System.ComponentModel.DataAnnotations.Schema;

namespace BackendRunningPlan.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string? Username { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
    }
}
