using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;


namespace ProjectAPI
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext() { }
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }
        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity => 
            {
                entity.HasKey(e => e.GUID).HasName("projet_pk");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
