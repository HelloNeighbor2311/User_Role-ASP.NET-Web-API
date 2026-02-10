using Microsoft.EntityFrameworkCore;
using System.Reflection;
using User_Role.Models;

namespace User_Role.Datas
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<Users> users => Set<Users>();
        public DbSet<Roles> roles => Set<Roles>();
        public DbSet<UsersRoles> usersRoles => Set<UsersRoles>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //automatically apply all configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
