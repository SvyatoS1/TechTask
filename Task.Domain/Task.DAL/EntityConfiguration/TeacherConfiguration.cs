using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Task.Domain;

namespace Task.DAL.EntityConfiguration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.TeacherId);
            builder.HasIndex(t => t.TeacherId).IsUnique();

            builder.Property(t => t.Name).IsRequired()
                .HasMaxLength(20);

            builder.Property(t => t.Surname).IsRequired()
                .HasMaxLength(20);

            builder.Property(t => t.Speciality).HasMaxLength(50);
        }
    }
}
