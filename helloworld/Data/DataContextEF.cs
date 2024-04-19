using Microsoft.EntityFrameworkCore;
using helloworld.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace helloworld.Data
{
public class DataContextEF : DbContext
{
    public DbSet<Computer> Computer { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=True;Trusted_Connection=true",
                options => options.EnableRetryOnFailure());
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            {
                
                modelBuilder.HasDefaultSchema("TutorialAppSchema");
                modelBuilder.Entity<Computer>().HasKey(c => c.ComputerId);
                // .ToTable("Computer", "TutorialAppSchema");
                // .ToTable("TableName", "SchemaName");
            }
        }
    }
}