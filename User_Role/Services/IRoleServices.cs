using User_Role.DTOs;

namespace User_Role.Services
{
    public interface IRoleServices
    {
        Task<List<RolesResponse>> GetAllRolesAsync();
        Task<RolesResponse?> GetRoleByIdAsync(int id);
        Task<RolesResponse?> GetRoleByNameAsync(string name);
        Task<RolesResponse> AddRoleAsync(CreateRoleRequest roleRequest);
        Task<bool> UpdateRoleAsync(int id, UpdateRoleRequest role);
        Task<bool> DeleteRoleAsync(int id);
    }
}
