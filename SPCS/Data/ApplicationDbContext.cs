using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SPCS.Models;

namespace SPCS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Project> Projects { get; set; } 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
