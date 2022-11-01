using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BackendRunningPlan.Models;

namespace BackendRunningPlan
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<PersonalCoach> PersonalCoaches { get; set; } = null!;
        public DbSet<TrainingDay> TrainingDays { get; set; } = null!;
        public DbSet<Training> Trainings { get; set; } = null!;
        public DbSet<TrainingList> TrainingList { get; set; } = null!;
    }
}
