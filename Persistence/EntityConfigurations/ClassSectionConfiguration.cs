using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySchool.Core.Models;

namespace MySchool.Persistence.EntityConfigurations
{
    public class ClassSectionConfiguration : IEntityTypeConfiguration<ClassSection>
    {
        public void Configure(EntityTypeBuilder<ClassSection> builder)
        {
            builder.Property(cs => cs.Name).IsRequired().HasMaxLength(255);
        }
    }
}