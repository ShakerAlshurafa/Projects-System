﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<Models.project.Project> Projects { get; set; }
        public DbSet<ProjectFeatures> ProjectFeatures { get; set; }
        public DbSet<ProjectTechnology> ProjectTechnology { get; set; }
        public DbSet<ProjectGoal> ProjectGoals { get; set; }
        public DbSet<ProjectAudience> Audience { get; set; }
        public DbSet<Workgroup> Workgroups { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //new ProjectEntityTypeConfiguration().Configure(builder.Entity<Project>());
            builder.ApplyConfigurationsFromAssembly(typeof(Configurations.ProjectConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(Configurations.ProjectUserConfiguration).Assembly);

            builder.Entity<ApplicationUser>().HasQueryFilter(u => !u.IsDeleted);
            base.OnModelCreating(builder);
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
