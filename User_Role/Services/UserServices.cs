using System.Diagnostics;
using User_Role.DTOs;
using User_Role.Models;
using User_Role.Respositories;

namespace User_Role.Services
{
    public class UserServices (IUserRepository userRepository, IRoleRepository roleRepository): IUserServices
    {
        public async Task<UsersResponse> AddUserAsync(CreateUserRequest usersRequest)
        {
            if (usersRequest.RolesId != null && usersRequest.RolesId.Any())
            {
                var existingRole = await roleRepository.GetAllRolesAsync();
                var existingRoleId = existingRole.Select(s => s.Id).ToList();

                var invalidRoleId = usersRequest.RolesId.Where(s => !existingRoleId.Contains(s)).ToList();
                if (invalidRoleId.Any())
                {
                    return null;
                }
            }
            var user = new Users
            {
                Username = usersRequest.Username,
                Password = usersRequest.Password,
                Name = usersRequest.Name,
                CreatedDate = DateTime.UtcNow,
                userRoles = new List<UsersRoles>()
            };
            if (usersRequest.RolesId != null && usersRequest.RolesId.Any())
            {
                foreach (var item in usersRequest.RolesId)
                {
                    user.userRoles.Add(new UsersRoles { RolesId = item });
                }
            }
            var createdUserResponse = await userRepository.CreateUserAsync(user);
            return MapUserResponse(createdUserResponse);
        }

        public async Task<bool> AssignRoleForUserAsync(int userId, int roleId)
        {
            return await userRepository.AssignRoleForUser(userId, roleId);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var existedUser = await userRepository.GetUserByIdAsync(id);
            if (existedUser is null) return false;
            await userRepository.DeleteUserAsync(existedUser);
            return true;
        }

        public async Task<List<UsersResponse>> GetAllUsersAsync()
        {
            var users = await userRepository.GetAllUsersAsync();
            return users.Select(u => MapUserResponse(u)).ToList();
        }

        public async Task<UsersResponse?> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await userRepository.GetUserByIdAsync(id);
                return (MapUserResponse(user));
            }catch(NullReferenceException e)
            {
                return null;
            }
        }

        public async Task<PageResult<UsersResponse>> PaginationForUserAsync(PaginationParam param)
        {
            var users = await userRepository.GetPageResultUsersAsync(param.PageSize, param.PageNum);
            
            var listUserResponse =  users.Select(u => MapUserResponse(u)).ToList();
            var count = listUserResponse.Count;
            var pageResult = new PageResult<UsersResponse>(listUserResponse, count,param.PageNum, param.PageSize);
            return pageResult;
            
        }

        public async Task<bool> RemoveRoleForUserAsync(int userId, int roleId)
        {
            return await userRepository.RemoveRoleForUser(userId, roleId);
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserRequest users)
        {
            var existedUser = await userRepository.GetUserByIdAsync(id);
            if (existedUser is null) return false;
            existedUser.Name = users.Name;
            var updatedUser = await userRepository.UpdateUserAsync(existedUser);
            return true;
        }


        private UsersResponse MapUserResponse(Users user)
        {
            var userResponse = new UsersResponse
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                CreatedDate = user.CreatedDate,
                Roles = user.userRoles?.Select(s => s.role.RoleName).ToList() ?? new List<string?>()
            };
            return userResponse;

        }
    }
}
