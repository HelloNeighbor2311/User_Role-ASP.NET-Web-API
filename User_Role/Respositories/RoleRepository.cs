using Microsoft.EntityFrameworkCore;
using User_Role.Datas;
using User_Role.Models;

namespace User_Role.Respositories
{
    public class RoleRepository(AppDbContext context) : IRoleRepository
    {
        public async Task<Roles> CreatRoleAsync(Roles obj)
        {
            context.roles.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }
        public Task DeleteRoleAsync(Roles user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Roles>> GetAllRolesAsync()
        {
            return await context.roles.Include(u=>u.userRoles).ThenInclude(u=>u.user).ToListAsync();
        }
        public async Task<Roles> GetRolesByIdAsync(int id)
        {
            return await context.roles.Include(u => u.userRoles).ThenInclude(u => u.user).FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<Roles> UpdateRoleAsync(Roles obj)
        {
            context.roles.Update(obj);
            await context.SaveChangesAsync();
            return obj;
        }
    }
}
