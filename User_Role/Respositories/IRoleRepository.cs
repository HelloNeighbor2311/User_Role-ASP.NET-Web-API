using User_Role.Models;

namespace User_Role.Respositories
{
    public interface IRoleRepository
    {
        Task<List<Roles>> GetAllRolesAsync();
        Task<Roles> GetRolesByIdAsync(int id);
        Task<Roles> CreatRoleAsync(Roles obj);
        Task<Roles> UpdateRoleAsync(Roles obj);
        Task DeleteRoleAsync(Roles role);
    }
}
