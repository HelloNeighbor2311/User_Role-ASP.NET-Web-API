using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User_Role.Models;

namespace User_Role.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UsersRoles>
    {
        public void Configure(EntityTypeBuilder<UsersRoles> builder)
        {
            builder.HasKey(ur => new { ur.UsersId, ur.RolesId });
            builder.HasOne(ur => ur.user).WithMany(u => u.userRoles).HasForeignKey(s => s.UsersId);
            builder.HasOne(ur => ur.role).WithMany(u => u.userRoles).HasForeignKey(s => s.RolesId);
        }
    }
}
