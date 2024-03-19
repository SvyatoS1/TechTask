using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Task.DAL.EntityConfiguration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasIndex(s => s.Id).IsUnique();

            builder.Property(s => s.Name).IsRequired()
            .HasMaxLength(20);

            builder.Property(s => s.Surname).IsRequired()
                .HasMaxLength(20);
        }
    }
}
