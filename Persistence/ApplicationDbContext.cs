using Microsoft.EntityFrameworkCore;
using MySchool.Core.Models;
using MySchool.Persistence.EntityConfigurations;

namespace MySchool.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassSection> ClassSections { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new ClassConfiguration());
            modelBuilder.ApplyConfiguration(new ClassSectionConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}