using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SPCS.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Models.project.Project>
    {
        public void Configure(EntityTypeBuilder<Models.project.Project> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            
        }
    }
}
