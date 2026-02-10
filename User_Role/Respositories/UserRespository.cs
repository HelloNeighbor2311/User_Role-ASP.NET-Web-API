using User_Role.Models;
using User_Role.Datas;
using Microsoft.EntityFrameworkCore;

namespace User_Role.Respositories
{
    public class UserRespository(AppDbContext context) : IUserRespository
    {
        public async Task<Users> CreateAsync(Users obj)
        {
            context.users.Add(obj);
            await context.SaveChangesAsync();
            return obj;
        }

        public Task<bool> DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Users>> GetAllAsync() => await context.users.Include(u => u.userRoles).ThenInclude(u=>u.role).ToListAsync();
        
        

        public Task<Users> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, Users obj)
        {
            throw new NotImplementedException();
        }
    }
}
