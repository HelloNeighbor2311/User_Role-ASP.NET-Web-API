using User_Role.Models;
using User_Role.Datas;
using Microsoft.EntityFrameworkCore;

namespace User_Role.Respositories
{
    public class UserRespository(AppDbContext context) : IUserRepository
    {
        public async Task<Users> CreateUserAsync(Users obj)
        {
            context.users.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public Task<bool> DeleteUserAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Users>> GetAllUsersAsync() => await context.users.Include(u => u.userRoles).ThenInclude(u=>u.role).ToListAsync();
        
        

        public async Task<Users> GetUserByIdAsync(int id)
        {
            return await context.users.Include(u => u.userRoles).ThenInclude(u => u.role).FirstOrDefaultAsync(s=>s.Id == id);
        }

        public Task<bool> UpdateUserAsync(int id, Users obj)
        {
            throw new NotImplementedException();
        }
    }
}
