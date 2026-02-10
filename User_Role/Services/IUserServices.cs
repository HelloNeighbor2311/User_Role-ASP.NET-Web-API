using User_Role.DTOs;
using User_Role.Models;

namespace User_Role.Services
{
    public interface IUserServices
    {
        Task<List<UsersResponse>> GetAllUsersAsync();

        Task<UsersResponse?> GetUserByIdAsync(int id);
        Task<UsersResponse> AddUserAsync(CreateUserRequest usersRequest);
        Task<bool> UpdateUserAsync(int id, Users users);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> AssignRoleForUserAsync(int userId, int roleId);
        Task<bool> RemoveRoleForUserAsync(int userId, int roleId);


    }
}
