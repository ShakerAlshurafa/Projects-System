using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SPCS.Configurations
{
    public class ProjectUserConfiguration : IEntityTypeConfiguration<Models.project.ProjectUser>
    {
        public void Configure(EntityTypeBuilder<Models.project.ProjectUser> builder)
        {
            builder.HasKey(x => new { x.UserId, x.ProjectId });

            builder.HasOne(x  => x.User)
                    .WithMany(u => u.ProjectUsers)
                    .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Project)
                    .WithMany(p => p.ProjectUsers)
                    .HasForeignKey(x => x.ProjectId);
        }
    }
}
