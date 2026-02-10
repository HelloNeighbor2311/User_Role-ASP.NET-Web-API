using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User_Role.Models;

namespace User_Role.Configuration
{
    public class RoleConfiguration: IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Desrciption)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.RoleName)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
