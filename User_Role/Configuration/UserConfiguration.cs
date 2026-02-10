using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User_Role.Models;

namespace User_Role.Configuration
{
    public class UserConfiguration: IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Username)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.Password)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.CreatedDate)
                .HasColumnType("date");
        }
    }
}
