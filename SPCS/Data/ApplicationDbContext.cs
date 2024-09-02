using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SPCS.Configurations;
using SPCS.Models;
using SPCS.Models.project;
using SPCS.Models.user;
using System.Reflection.Emit;

namespace SPCS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectFeatures> ProjectFeatures { get; set; }
        public DbSet<ProjectTechnology> ProjectTechnology { get; set; }
        public DbSet<ProjectGoal> ProjectGoals { get; set; }
        public DbSet<ProjectAudience> Audience { get; set; }
        public DbSet<Workgroup> Workgroups { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //new ProjectEntityTypeConfiguration().Configure(builder.Entity<Project>());
            builder.ApplyConfigurationsFromAssembly(typeof(ProjectEntityTypeConfiguration).Assembly);

            base.OnModelCreating(builder);
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
