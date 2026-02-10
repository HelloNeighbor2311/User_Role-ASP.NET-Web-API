using Microsoft.EntityFrameworkCore;
using System.Reflection;
using User_Role.Models;

namespace User_Role.Datas
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        DbSet<Users> users => Set<Users>();
        DbSet<Roles> roles => Set<Roles>();
        DbSet<UsersRoles> usersRoles => Set<UsersRoles>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //automatically apply all configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
