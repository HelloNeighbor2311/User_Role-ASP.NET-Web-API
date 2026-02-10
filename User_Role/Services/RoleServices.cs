using User_Role.DTOs;
using User_Role.Models;
using User_Role.Respositories;

namespace User_Role.Services
{
    public class RoleServices(IRoleRepository repository) : IRoleServices
    {
        public async Task<RolesResponse> AddRoleAsync(CreateRoleRequest roleRequest)
        {
            var role = new Roles
            {
                RoleName = roleRequest.RoleName,
                Desrciption = roleRequest.Desrciption
            };
            var createdRole = await repository.CreatRoleAsync(role);
            return MapRoleResponse(createdRole);
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var existedRole = await repository.GetRolesByIdAsync(id);
            if (existedRole is null) return false;
            await repository.DeleteRoleAsync(existedRole);
            return true;
        }

        public async Task<List<RolesResponse>> GetAllRolesAsync()
        {
            var role = await repository.GetAllRolesAsync();
            return role.Select(u => MapRoleResponse(u)).ToList();
        }

        public async Task<RolesResponse?> GetRoleByIdAsync(int id)
        {
            try
            {
                var role = await repository.GetRolesByIdAsync(id);
                return MapRoleResponse(role);
            }catch(NullReferenceException e)
            {
                return null;
            }
        }

        public async Task<bool> UpdateRoleAsync(int id, UpdateRoleRequest role)
        {
            var existedRole = await repository.GetRolesByIdAsync(id);
            if (existedRole is null) return false;
            existedRole.Desrciption = role.Desrciption;
            await repository.UpdateRoleAsync(existedRole);
            return true;

        }

        private RolesResponse MapRoleResponse(Roles role)
        {
            var roleResponse = new RolesResponse
            {
                RoleName = role.RoleName,
                Desrciption = role.Desrciption,
                Users = role.userRoles?.Select(u => u.user.Name).ToList() ?? new List<string?>()

            };
            return roleResponse;

        }
    }
}
