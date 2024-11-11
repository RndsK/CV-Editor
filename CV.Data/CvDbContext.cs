using Latvijas_Pasts.Models;
using Microsoft.EntityFrameworkCore;

namespace CV.Data
{
        public class CvDbContext : DbContext
        {
            public CvDbContext(DbContextOptions<CvDbContext> options) : base(options) { }
            public DbSet<Cv> Cv { get; set; }
            public DbSet<Education> Educations { get; set; }
            public DbSet<Experience> Experiences { get; set; }
            public DbSet<Address> Addresses { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Cv>()
                    .HasMany(c => c.EducationList)
                    .WithOne()
                    .HasForeignKey(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Cv>()
                    .HasMany(c => c.ExperienceList)
                    .WithOne()
                    .HasForeignKey(e => e.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            }
    }
}
