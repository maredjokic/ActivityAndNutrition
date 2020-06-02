using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore; 
using TrainingFoodAnalyser.Models; 

namespace TrainingFoodAnalyser.Data
{     
    public class ApplicationDbContext : IdentityDbContext  
    {         
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

 
        public DbSet<Food> Food { get; set; }    
        public DbSet<Training> Training { get; set; }    
        public DbSet<Korisnik> Korisnik { get; set; }   
        public DbSet<DnevnaEvidencija> Evidencija { get; set; }
        public DbSet<DnevnoTrcanje> Trcanja { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Food>().ToTable("Food");
                modelBuilder.Entity<Training>().ToTable("Training");
                modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
                modelBuilder.Entity<DnevnoTrcanje>().ToTable("DnevnoTrcanje");
                modelBuilder.Entity<DnevnaEvidencija>().ToTable("DnevnaEvidencija");

                modelBuilder.Entity<DnevnoTrcanje>()
                    .HasOne(vt => vt.Korisnik)
                    .WithMany(v => v.Trcanja)
                    .HasForeignKey(vt => vt.KorisnikId);
                
                modelBuilder.Entity<DnevnaEvidencija>()
                    .HasOne(vt => vt.Korisnik)
                    .WithMany(v => v.Evidencije)
                    .HasForeignKey(vt => vt.KorisnikId);
        } 
    }
}