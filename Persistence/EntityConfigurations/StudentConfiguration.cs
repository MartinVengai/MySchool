using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySchool.Core.Models;

namespace MySchool.Persistence.EntityConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.ClassSectionId).IsRequired();
            builder.Property(s => s.Email).IsRequired().HasMaxLength(255);
            builder.Property(s => s.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(s => s.IdNumber).IsRequired().HasMaxLength(255);
            builder.Property(s => s.LastName).IsRequired().HasMaxLength(255);
            builder.Property(s => s.Phone).HasMaxLength(255);
            builder.Property(s => s.Sex).IsRequired().HasMaxLength(6);

            builder.OwnsOne(s => s.Address, ownershipBuilder =>
            {
                ownershipBuilder.Property(a => a.Street).IsRequired().HasMaxLength(255);
                ownershipBuilder.Property(a => a.City).IsRequired().HasMaxLength(255);
                ownershipBuilder.Property(a => a.Country).HasMaxLength(255);
                ownershipBuilder.Property(a => a.Zip).IsRequired().HasMaxLength(10);
            });

        }
    }
}